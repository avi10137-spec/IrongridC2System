using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System.Text.Json;
namespace IrongridProducer.Serivces
{
    public class ProducerService
    {
        private readonly string _bootstrapServer;
        private readonly IProducer<Null, string> _producer;
        public ProducerService(string bootstrapserver)
        {
            _bootstrapServer = bootstrapserver;
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapserver
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task<DeliveryResult<Null, string>> SendAsync<T>(string topic, T objekt)
        {
            string jsonMassege = JsonSerializer.Serialize(objekt);
            var kafkaMessage = new Message<Null, string>
            {
                Value = jsonMassege
            };
            var result = await _producer.ProduceAsync(topic, kafkaMessage);

            Console.WriteLine($" send for topic {topic} : {kafkaMessage.Value}");
            return result;
        }
        public async Task EnsureTopicExistsAsync(string topicName, string bootstrapserver, int numPartitions = 1, short

  replicationFactor = 1)
        {
            var config = new AdminClientConfig
            {

                BootstrapServers = _bootstrapServer
            };
            using var adminClient = new AdminClientBuilder(config).Build();
            try
            {
                await adminClient.CreateTopicsAsync(new[]
                {
                            new TopicSpecification
                            {
                                Name = topicName,
                                NumPartitions = numPartitions,
                                ReplicationFactor = replicationFactor

                            }
                        });
                Console.WriteLine($" Topic '{topicName}' created successfully.");
            }
            catch (CreateTopicsException e)
            {
                if (e.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
                {
                    Console.WriteLine($" Topic '{topicName}' already exists.");
                }
                else
                {
                    throw new Exception($"Failed to create topic: {e.Results[0].Error.Reason}");
                }
            }
        }
                 public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
            _producer.Dispose();
        }

 
            
}
    }



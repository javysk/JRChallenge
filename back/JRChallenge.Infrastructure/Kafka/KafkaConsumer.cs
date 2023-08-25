using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace JRChallenge.Infrastructure.Kafka
{
    public class KafkaConsumer
    {
        private readonly IOptions<KafkaSettings> _settings;
        public KafkaConsumer(IOptions<KafkaSettings> settings)
        {
            _settings = settings;
        }
        public IEnumerable<string> GetMessages() {
           
            var config = new ConsumerConfig
            {
                BootstrapServers = _settings.Value.Url,
                GroupId = "test-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(_settings.Value.Topic);

            while (true)
            {
                var consumeResult = consumer.Consume();

                Console.WriteLine($"Received message: {consumeResult.Message.Value}");
            }
        }
    }
}

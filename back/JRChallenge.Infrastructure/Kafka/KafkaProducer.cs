using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace JRChallenge.Infrastructure.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IOptions<KafkaSettings> _settings;
        public KafkaProducer(IOptions<KafkaSettings> settings)
        {
            _settings = settings;
        }

        public async Task PublishAsync(KafkaDTO dto)
        {
            try
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = _settings.Value.Url,
                };

                var producer = new ProducerBuilder<string, string>(config).Build();

                var topic = _settings.Value.Topic;

                var message = new Message<string, string>
                {
                    Key = dto.Id.ToString(),
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject(dto),
                };

                var deliveryReport = await producer.ProduceAsync(topic, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

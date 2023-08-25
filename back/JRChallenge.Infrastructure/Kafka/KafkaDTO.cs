namespace JRChallenge.Infrastructure.Kafka
{
    public class KafkaDTO
    {
        public KafkaDTO(Guid id, string nameOperation)
        {
            Id = id;
            NameOperation = nameOperation;
        }
        public Guid Id { get; set; }
        public string NameOperation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRChallenge.Infrastructure.Kafka
{
    public interface IKafkaProducer
    {
        public  Task PublishAsync(KafkaDTO dto);
    }
}

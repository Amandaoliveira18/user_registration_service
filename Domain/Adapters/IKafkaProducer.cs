using Confluent.Kafka;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface IKafkaProducer<Tkey, TValue>
    {
        public Task<bool> TopicSubmission(string topico, Message<Tkey, TValue> message);
    }
}

using Confluent.Kafka;
using Domain.Adapters;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase.Broker
{
    public class KafkaProducer<TKey, Tvalue> : IKafkaProducer<TKey, Tvalue>
    {
        public async Task<bool> TopicSubmission(string topico, Message<TKey, Tvalue> message)
        {
            try
            {
                var config = new ProducerConfig { BootstrapServers = "localhost:29092" };
                var producer = new ProducerBuilder<TKey, Tvalue>(config).Build();

                var result = await producer.ProduceAsync(topico, message);

                return result.Status == PersistenceStatus.Persisted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}

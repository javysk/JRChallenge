using JRChallenge.Domain;
using JRChallenge.Domain.Entities;
using JRChallenge.Infrastructure.Elasticsearch;
using JRChallenge.Infrastructure.Kafka;

namespace JRChallenge.Infrastructure
{
    public class PermissionsRepository : Repository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(JRChallengeContext dbContext, IElasticsearchService elastic, IKafkaProducer kafka) : base(dbContext, elastic, kafka) { }
    }
    public class PermissionTypeRepository : Repository<Domain.Entities.PermissionTypes>, IPermissionsTypeRepository
    {
        public PermissionTypeRepository(JRChallengeContext dbContext, IElasticsearchService elastic, IKafkaProducer kafka) : base(dbContext, elastic, kafka) { }
    }
}

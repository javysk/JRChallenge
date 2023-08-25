using JRChallenge.Domain;
using JRChallenge.Infrastructure.Elasticsearch;
using JRChallenge.Infrastructure.Extensions;
using JRChallenge.Infrastructure.Kafka;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JRChallenge.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly JRChallengeContext _context;
        private readonly DbSet<T> _entitiySet;
        private readonly IElasticsearchService _elasticsearchService;
        private readonly IKafkaProducer _kafka;
        public Repository(JRChallengeContext dbContext,
            IElasticsearchService elasticsearchService,
            IKafkaProducer kafka)
        {
            _context = dbContext;
            _entitiySet = _context.Set<T>();
            _elasticsearchService = elasticsearchService;
            _kafka = kafka;
        }
        #region Get
        public T Get(Expression<Func<T, bool>> expression)
        {
            _kafka.PublishAsync(new KafkaDTO(new Guid(), "get"));
            return _entitiySet.FirstOrDefault(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            await _kafka.PublishAsync(new KafkaDTO(new Guid(), "getall"));
            return await _entitiySet.IncludeAll().ToListAsync(cancellationToken);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            await _kafka.PublishAsync(new KafkaDTO(new Guid(), "get"));
            return await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);
        }
        #endregion

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return SaveAndPublish(entity, "add");
        }
        public void Remove(T entity) => _context.Remove(entity);

        public T Update(T entity)
        {
            _context.Update(entity);
            return SaveAndPublish(entity, "modify");
        }

        private T SaveAndPublish(T entity, string action)
        {            
            _context.SaveChanges();
            _kafka.PublishAsync(new KafkaDTO(new Guid(), action));
            _elasticsearchService.IndexDocument(entity, entity.Id.ToString());
            return entity;
        }
    }
}

using JRChallenge.Domain;
using JRChallenge.Domain.UOW;
using JRChallenge.Infrastructure.Elasticsearch;
using JRChallenge.Infrastructure.Kafka;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JRChallenge.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JRChallengeContext _context;
        private readonly IElasticsearchService _elastic;
        private readonly IKafkaProducer _kafka;
        private IPermissionsRepository _permission;
        private IPermissionsTypeRepository _permissionType;

        public UnitOfWork(JRChallengeContext context, 
            IElasticsearchService elastic,
            IKafkaProducer kafka) {
            _context = context; 
            _elastic = elastic;
            _kafka = kafka;
        }

        public IPermissionsRepository PermissionsRepository =>  _permission ?? new PermissionsRepository(_context, _elastic, _kafka);

        public IPermissionsTypeRepository PermissionsTypeRepository => _permissionType ?? new PermissionTypeRepository(_context, _elastic, _kafka);

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}

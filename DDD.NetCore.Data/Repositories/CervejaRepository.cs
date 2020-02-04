using DDD.NetCore.Data.Contexts;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Data.Repositories
{
    public class CervejaRepository : RepositoryBase<CervejaEntity>
    {
        public CervejaRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}

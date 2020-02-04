using DDD.NetCore.Data.Contexts;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Data.Repositories
{
    public class RevendedorRepository : RepositoryBase<RevendedorEntity>
    {
        public RevendedorRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}

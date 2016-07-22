using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApi.Common.Domain;

namespace WebApi.Common.DataAccess
{
    public interface IAnyDbContext
    {        
        IDbSet<Eventlog> Eventlogs { get; set; }
        IDbSet<T> EntitieSet<T>() where T : Entity;
        DbEntityEntry GetEntry(object entity);
        void Save();
    }
}

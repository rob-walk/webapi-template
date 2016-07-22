using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApi.Common.Domain;

namespace WebApi.Common.DataAccess
{
    public class AnyDbContext : DbContext, IAnyDbContext
    {
        public AnyDbContext() : base(string.Format("name={0}", Constants.AnyDatabaseConnectionStringKey))
        {
            Database.SetInitializer<AnyDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IDbSet<Eventlog> Eventlogs { get; set; }

        public IDbSet<T> EntitieSet<T>() where T : Entity
        {
            return Set<T>();
        }

        public void Save()
        {
            SaveChanges();
        }

        public DbEntityEntry GetEntry(object entity)
        {
            return Entry(entity);
        }
    }
}

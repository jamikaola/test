using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace NHiber.Models.NHibernate
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            var cfg = new Configuration()
            .DataBaseIntegration(db =>
            {
                string connectionString = @"Data Source=|DataDirectory|\db\data.db";
                //string connectionString = string.Format("Data Source={0}", @"|DataDirectory|\db\data.db");
                db.ConnectionString = connectionString;
                //db.ConnectionString = @"Data Source = App_Data\data.db;";
                db.Dialect<SQLiteDialect>();
            });
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);
            new SchemaUpdate(cfg).Execute(true, true);
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
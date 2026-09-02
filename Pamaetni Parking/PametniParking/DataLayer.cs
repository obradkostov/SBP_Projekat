using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace PametniParkingLibrary;

internal static class DataLayer
{
    private static ISessionFactory? _factory = null;
    private static readonly object objLock = new();

    // Funkcija na zahtev otvara sesiju
    public static ISession? GetSession()
    {
        if (_factory == null)
        {
            lock (objLock)
            {
                _factory ??= CreateSessionFactory();
            }
        }

        return _factory?.OpenSession();
    }

    // Konfiguracija i kreiranje session factory
    private static ISessionFactory? CreateSessionFactory()
    {
        try
        {
            string connectionString = DbConfig.ConnectionString;

            var cfg = OracleManagedDataClientConfiguration.Oracle10
                        .ShowSql()
                        .ConnectionString(c => c.Is(connectionString));

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
        catch (Exception e)
        {
            ErrorHandler.HandleError(e);
            return null;
        }
    }
}

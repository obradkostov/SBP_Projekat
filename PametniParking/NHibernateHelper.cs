using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PametniParking.Mapiranja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace PametniParking
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    // Čitamo konekcioni string iz App.config-a
                    string connectionString = ConfigurationManager.ConnectionStrings["PametniParking"].ConnectionString;

                    _sessionFactory = Fluently.Configure()
                        // 1. Konfiguracija za Oracle bazu (koristi ODP.NET managed drajver)
                        .Database(OracleManagedDataClientConfiguration.Oracle10
                        .ConnectionString(connectionString)
                        .ShowSql()
                        )
                        // 2. Učitavanje tvojih mapiranja
                        .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}

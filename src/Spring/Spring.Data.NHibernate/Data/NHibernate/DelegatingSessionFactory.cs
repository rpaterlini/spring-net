using System;
using System.Collections.Generic;

#if NH_5_0
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
#else
using System.Data;
#endif

using NHibernate;
using NHibernate.Engine;
using NHibernate.Metadata;
using NHibernate.Stat;

namespace Spring.Data.NHibernate
{
#pragma warning disable 1591
    /// <summary>
    /// DelegatingSessionFactory class
    /// </summary>
    public abstract class DelegatingSessionFactory : ISessionFactory
    {
        public ICollection<string> DefinedFilterNames
        {
            get { return TargetSessionFactory.DefinedFilterNames; }
        }

        public bool IsClosed
        {
            get { return TargetSessionFactory.IsClosed; }
        }

        public IStatistics Statistics
        {
            get { return TargetSessionFactory.Statistics; }
        }

        public abstract ISessionFactory TargetSessionFactory
        {
            get;
        }

        public void Close()
        {
            TargetSessionFactory.Close();
        }

        public void Dispose()
        {
            TargetSessionFactory.Dispose();
        }

        public void Evict(Type persistentClass)
        {
            TargetSessionFactory.Evict(persistentClass);
        }

        public void EvictCollection(string roleName, object id)
        {
            TargetSessionFactory.EvictCollection(roleName, id);
        }

        public void EvictCollection(string roleName)
        {
            TargetSessionFactory.EvictCollection(roleName);
        }

        public void EvictEntity(string entityName)
        {
            TargetSessionFactory.EvictEntity(entityName);
        }

        public void EvictEntity(string entityName, object id)
        {
            TargetSessionFactory.EvictEntity(entityName, id);
        }

        public void EvictQueries(string cacheRegion)
        {
            TargetSessionFactory.EvictQueries(cacheRegion);
        }

        public void EvictQueries()
        {
            TargetSessionFactory.EvictQueries();
        }

        public IClassMetadata GetClassMetadata(Type persistentType)
        {
            return TargetSessionFactory.GetClassMetadata(persistentType);
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            return TargetSessionFactory.GetClassMetadata(entityName);
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            return TargetSessionFactory.GetCollectionMetadata(roleName);
        }

        public ISession GetCurrentSession()
        {
            return TargetSessionFactory.GetCurrentSession();
        }

        public FilterDefinition GetFilterDefinition(string filterName)
        {
            return TargetSessionFactory.GetFilterDefinition(filterName);
        }

        public ISession OpenSession(IInterceptor interceptor)
        {
            return TargetSessionFactory.OpenSession(interceptor);
        }

        public ISession OpenSession()
        {
            return TargetSessionFactory.OpenSession();
        }

        public IStatelessSession OpenStatelessSession()
        {
            return TargetSessionFactory.OpenStatelessSession();
        }


        IDictionary<string, IClassMetadata> ISessionFactory.GetAllClassMetadata()
        {
            return TargetSessionFactory.GetAllClassMetadata();
        }

        IDictionary<string, ICollectionMetadata> ISessionFactory.GetAllCollectionMetadata()
        {
            return TargetSessionFactory.GetAllCollectionMetadata();
        }

        public void Evict(Type persistentClass, object id)
        {
            TargetSessionFactory.Evict(persistentClass, id);
        }


#if NH_5_0

        public IStatelessSession OpenStatelessSession(DbConnection connection)
        {
            throw new NotImplementedException();
        }

        public Task CloseAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.CloseAsync(cancellationToken);
        }

        public Task EvictAsync(Type persistentClass, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictAsync(persistentClass, cancellationToken);
        }

        public Task EvictAsync(Type persistentClass, object id, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictAsync(persistentClass, id, cancellationToken);
        }

        public Task EvictEntityAsync(string entityName, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictEntityAsync(entityName, cancellationToken);
        }

        public Task EvictEntityAsync(string entityName, object id, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictEntityAsync(entityName, id, cancellationToken);
        }

        public Task EvictCollectionAsync(string roleName, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictCollectionAsync(roleName, cancellationToken);
        }

        public Task EvictCollectionAsync(string roleName, object id, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictCollectionAsync(roleName, id, cancellationToken);
        }

        public Task EvictQueriesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictQueriesAsync(cancellationToken);
        }

        public Task EvictQueriesAsync(string cacheRegion, CancellationToken cancellationToken = new CancellationToken())
        {
            return TargetSessionFactory.EvictQueriesAsync(cacheRegion, cancellationToken);
        }

        public ISessionBuilder WithOptions()
        {
            return TargetSessionFactory.WithOptions();
        }

        public ISession OpenSession(DbConnection connection)
        {
            return TargetSessionFactory.OpenSession(connection);
        }
        
                public ISession OpenSession(DbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            return TargetSessionFactory.OpenSession(conn, sessionLocalInterceptor);
        }

        public IStatelessSessionBuilder WithStatelessOptions()
        {
            return TargetSessionFactory.WithStatelessOptions();
        }
#else

        public IStatelessSession OpenStatelessSession(IDbConnection connection)
        {
            return TargetSessionFactory.OpenStatelessSession(connection);
        }

        public ISession OpenSession(IDbConnection conn, IInterceptor interceptor)
        {
            return TargetSessionFactory.OpenSession(conn, interceptor);
        }

        public ISession OpenSession(IDbConnection conn)
        {
            return TargetSessionFactory.OpenSession(conn);
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            return TargetSessionFactory.GetAllClassMetadata();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            return TargetSessionFactory.GetAllCollectionMetadata();
        }
#endif

    }
}

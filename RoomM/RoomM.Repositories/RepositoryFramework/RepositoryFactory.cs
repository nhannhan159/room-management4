using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RoomM.Model.RepositoryFramework
{
    public static class RepositoryFactory
    {
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();

        private static Dictionary<string, string> RepositoryMappings
            = new Dictionary<string, string>
            {
                {"IRoomRepository" , "RoomM.Repositories.Rooms.RoomRepository, RoomM.Repositories, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"},
            };

        public static T GetRepository<T, TEntity>()
            where T : class, IRepository<TEntity>
            where TEntity : EntityBase
        {
            T repository = default(T);
            string interfaceShortName = typeof(T).Name;
            if (!RepositoryFactory.repositories.ContainsKey(interfaceShortName))
            {
                Type repositoryType = Type.GetType(RepositoryMappings[interfaceShortName]);
                object[] constructorArgs = new object[] { StaticRoomContext.Context };
                repository = Activator.CreateInstance(repositoryType, constructorArgs) as T;
                RepositoryFactory.repositories.Add(interfaceShortName, repository);
            }
            else repository = (T)RepositoryFactory.repositories[interfaceShortName];
            return repository;
        }
    }
}

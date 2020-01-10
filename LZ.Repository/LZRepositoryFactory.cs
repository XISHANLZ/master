using LZ.IRepository;
using LZ.Model.EntityContext;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LZ.Repository
{
    public  class LZRepositoryFactory
    {
        public static ConcurrentDictionary<string, AsyncLocal<object>> State;

        public static ConcurrentDictionary<string, AsyncLocal<object>> GetState()
        {
            if (State == null)
            {
                State = new ConcurrentDictionary<string, AsyncLocal<object>>();
            }
            return State;
        }
        public static EntityContext GetDataContext()
        {
            //var state = new ConcurrentDictionary<string, AsyncLocal<object>>();
            var libraryDataContext = GetState().TryGetValue("SqlContext", out var data) ? data.Value : null;
            if (libraryDataContext == null)
            {
                libraryDataContext = new EntityContext();
                GetState().GetOrAdd("SqlContext", _ => new AsyncLocal<object>()).Value = libraryDataContext;
            }
            return (EntityContext)libraryDataContext;
        }

        public ILZRepository<T> CreateRepository<T>(EntityContext mydbcontext) where T : class
        {
            return new LZRepository<T>();
        }
    }
}

using LZ.Model.EntityContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.IRepository
{
    public interface ILZRepositoryFactory
    {
        ILZRepository<T> CreateRepository<T>(EntityContext mydbcontext) where T : class;
    }
}

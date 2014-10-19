using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.RepositoryFramework
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> GetAll();
        T GetByID(object id);
    }
}

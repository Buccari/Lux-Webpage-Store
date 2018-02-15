using LuxWebpageStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxWebpageStore.Data.interfaces
{
    public interface IUserRepository
    {
        User GetUserByID(int userID);
        IEnumerable<User> Users { get; }
    }
}

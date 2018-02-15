﻿using LuxWebpageStore.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace LuxWebpageStore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<User> Users => _appDbContext.UsersData;

        public User GetUserByID(int userID)=> _appDbContext.UsersData.FirstOrDefault(user => user.UserID == userID);
    }
}

﻿using Statsenko_Module3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsenko_Module3.Data
{
    static public class UsersData
    {
        private static List<User> UserList = new List<User>();
        public static List<User> GetUsers()
        {
            if (UserList.Count == 0)
            {
                UserList.Add(new User()
                {
                    Id = 0,
                    LastName = "Попов",
                    FirstName = "Павел",
                    Login = "admin",
                    Password = "12345",
                    Status = UserStatus.Active,
                    LastDateLogin = DateTime.Now,
                    Role = UserRole.Client
                });
                UserList.Add(new User()
                {
                    Id = 1,
                    LastName = "Петров",
                    FirstName = "Петр",
                    Login = "user1",
                    Password = "12345",
                    Status = UserStatus.Active,
                    LastDateLogin = DateTime.Now,
                    Role = UserRole.Admin
                }); 
                UserList.Add(new User()
                {
                    Id = 2,
                    LastName = "Сидоров",
                    FirstName = "Павел",
                    Login = "user2",
                    Password = "12345",
                    Status = UserStatus.Active,
                    LastDateLogin = new DateTime(2025,3,2),
                    Role = UserRole.Client
                });
                UserList.Add(new User()
                {
                    Id = 3,
                    LastName = "Сидоров",
                    FirstName = "Павел",
                    Login = "user2",
                    Password = "12345",
                    Status = UserStatus.Active,
                    Role = UserRole.Client
                });
            }

            return UserList;
        }
    }
}

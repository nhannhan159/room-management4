using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomM.Business.Rooms;
using RoomM.Models.Users;

namespace RoomM.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetUserTest()
        {
            User u = UserService.GetByID(1);
            Console.WriteLine(u.ToString());

            Console.WriteLine("Check pass1: " + UserService.CheckPassword(u, "123"));
            Console.WriteLine("Check pass2: " + UserService.CheckPassword(u, "admin"));

            Console.WriteLine("Check user exists1: " + UserService.CheckUserExists("admin"));
            Console.WriteLine("Check user exists2: " + UserService.CheckUserExists("adminaaaa"));

        }
    }
}

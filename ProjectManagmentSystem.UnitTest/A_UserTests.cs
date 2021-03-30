using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagmentSystem.BusinessLayer;
using System;
using System.Collections.Generic;

namespace ProjectManagmentSystem.UnitTest
{
    [TestClass]
    public class A_UserTests
    {


        [TestMethod]
        public void A_IsUsernameUnique_CanGetInformationAbouthThat_ReturnsFalse()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "lazarkosti";

            var result = userLogic.isUsernameUnique(user.Username);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void B_createUser_CanCreateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "lazarkosti";
            u.Password = "laza";
            u.Email = "laza@gmail";
            u.Role = 1;


            var result = userLogic.createUser(u);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void C_updateUser_CanUpdateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "lazarkostic";

            u.Password = "lazar";
            u.Email = "lazar@gmail";
            u.Role = 0;

            var result = userLogic.updateUser(u, "lazarkosti");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void D_IsUsernameUnique2_CanGetInformationAbouthThat_ReturnsFalse()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "igorpani";

            var result = userLogic.isUsernameUnique(user.Username);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void E_createUser2_CanCreateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "igorpani";
            u.Password = "igo";
            u.Email = "igo@gmail";
            u.Role = 2;


            var result = userLogic.createUser(u);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void F_updateUser2_CanUpdateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "igorpanic";

            u.Password = "igor";
            u.Email = "igor@gmail";
            u.Role = 1;

            var result = userLogic.updateUser(u, "igorpani");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void G_Login_CanLogAdmin_ReturnsTrue()
        {
            var user = new User();
            user.Username = "lazarkostic";
            user.Password = "lazar";
            var userLogic = new UsersLogic();

            var result = userLogic.Login(user.Username, user.Password);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void H_Login_CanLogPM_ReturnsTrue()
        {
            var user = new User();
            user.Username = "igorpanic";
            user.Password = "igor";
            var userLogic = new UsersLogic();

            var result = userLogic.Login(user.Username, user.Password);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void I_createUser2_CanCreateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "jovanjovic";
            u.Password = "jovan";
            u.Email = "jovan@gmail";
            u.Role = 2;


            var result = userLogic.createUser(u);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void J_Login_CanLogDeveloper_ReturnsTrue()
        {
            var user = new User();
            user.Username = "jovanjovic";
            user.Password = "jovan";
            var userLogic = new UsersLogic();

            var result = userLogic.Login(user.Username, user.Password);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void K_GetAllUsersWithRoleAdmin_CanGetAllUsers_ReturnsTrue()
        {
           
            var userLogic = new UsersLogic();

            List<User> result = (List<User>)userLogic.getAllUsersWithRole(0);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void L_GetAllUsersWithRolePM_CanGetAllUsers_ReturnsTrue()
        {

            var userLogic = new UsersLogic();

            List<User> result = (List<User>)userLogic.getAllUsersWithRole(1);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void M_GetAllUsersWithRoleDeveloper_CanGetAllUsers_ReturnsTrue()
        {

            var userLogic = new UsersLogic();

            List<User> result = (List<User>)userLogic.getAllUsersWithRole(2);

            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void N_ReturnAllUsers_CanGetAllUsers_ReturnsTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();

            List<User> expected = (List<User>)broker.reaturnAllUsers();
            List<User> result = (List<User>)userLogic.reaturnAllUsers();

            Assert.AreEqual(result.Count, expected.Count);
        }

        [TestMethod]
        public void O_IsUsernameUnique3_CanGetInformationAbouthThat_ReturnsFalse()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "masa123";

            var result = userLogic.isUsernameUnique(user.Username);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void P_createUser3_CanCreateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "masa123";
            u.Password = "masa123";
            u.Email = "masa123@gmail";
            u.Role = 2;


            var result = userLogic.createUser(u);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Q_updateUser3_CanUpdateUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "masa1235";

            u.Password = "masa1";
            u.Email = "masa12@gmail";
            u.Role = 2;

            var result = userLogic.updateUser(u, "masa123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void R_RemoveUser3_CanRemovelUser_ReturnsTrue()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "masa1235";

            var result = userLogic.removeUser(user);

            Assert.IsTrue(result);
        }

        

        [TestMethod]
        public void S_returnAllTasksForUser_CanReturnAllTasksForUser_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var userLogic = new UsersLogic();
            User u = new User();
            u.Username = "jovanjovic";

            List<Task> expected = broker.returnAllTasksForUser(u);
            List<Task> result = (List<Task>)userLogic.returnAllTasksForUser(u);

            Assert.AreEqual(result.Count, expected.Count);
        }
       
        
    }
}

using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagmentSystem.BusinessLayer;
using System;

namespace ProjectManagmentSystem.UnitTest
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void A_removeTask()
        {
            var taskLogic = new TaskLogic();
            Task task = new Task();
            task.TaskID = 1;
            task.ProjectCode = "AAA111";

            var result = taskLogic.removeTask(task);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void B_removeProject_CanRemoveProject()
        {
            ProjectLogic projectLogic = new ProjectLogic();
            Project project = new Project();
            project.ProjectCode = "AAA111";

            var result= projectLogic.removeProject(project);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void C_RemoveUserIgor_CanRemovelUser_ReturnsTrue()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "igorpanic";

            var result = userLogic.removeUser(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void D_RemoveUserLazar_CanRemovelUser_ReturnsTrue()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "lazarkostic";

            var result = userLogic.removeUser(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void E_RemoveUserJovan_CanRemovelUser_ReturnsTrue()
        {
            var userLogic = new UsersLogic();
            User user = new User();
            user.Username = "jovanjovic";

            var result = userLogic.removeUser(user);

            Assert.IsTrue(result);
        }

    }
}

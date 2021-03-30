using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagmentSystem.BusinessLayer;
using System;
using System.Collections.Generic;

namespace ProjectManagmentSystem.UnitTest
{
    [TestClass]
    public class C_TaskTest
    {
        public int taskIDTest;
        public string projectCodeTest = "AAA111";
        [TestMethod]
        public void returnAllTasksForProject_CanGetAllTasksForProject()
        {
            DBBroker broker = new DBBroker();
            var taskLogic = new TaskLogic();
            Project project = new Project()
            {
                ProjectCode = projectCodeTest
            };
            

            List<Task> expected = (List<Task>)broker.returnAllTasksForProject(project);
            List<Task> result = (List<Task>)taskLogic.returnAllTasksForProject(project);
           

            Assert.AreEqual(result.Count, expected.Count);
        }

        [TestMethod]
        public void returnTaskId_CanReturnTaskID_ReturnNotNull()
        {
            var taskLogic = new TaskLogic();
            
            taskIDTest = taskLogic.returnTaskId();

            Assert.IsNotNull(taskIDTest);
        }

        [TestMethod]
        public void U_createTask_CanCreateTask_ReturnTrue()
        {
            var taskLogic = new TaskLogic();
            Task task = new Task();
            task.TaskID = taskIDTest;
            task.ProjectCode = projectCodeTest;
            task.Assignee = "jovanjovic";
            task.Status = 1;
            task.Progress =Convert.ToDecimal(0.5) ;
            task.Deadline = DateTime.Now;
            task.Description = "sasa";

            var result = taskLogic.createTask(task);

            Assert.IsTrue(result);


        }

        [TestMethod]
        public void updateTask_CanUpdateTask_ReturnTrue()
        {
            var taskLogic = new TaskLogic();
            Task task = new Task();
            task.TaskID = taskIDTest;
            task.ProjectCode = projectCodeTest;
            task.Assignee = "masa1235";
            task.Status = 1;
            task.Progress = Convert.ToDecimal(0.6);
            task.Deadline = DateTime.Now;
            task.Description = "sasa11";

            var result = taskLogic.updateTask(task);

            Assert.IsTrue(result);
        }

        

        

      
        
    }
}

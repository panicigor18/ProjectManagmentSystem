using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagmentSystem.BusinessLayer;
using System;
using System.Collections.Generic;

namespace ProjectManagmentSystem.UnitTest
{
    [TestClass]
    public class B_ProjectTest
    {
        public string ProjectCodeTest="AAA111";

        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void returnAllProjectForPM_CanReturnAllProjectForPM_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var projectLogic = new ProjectLogic();
            User projectManager = new User();
            projectManager.Username = "igorpanic1";

            List<Project> expected = (List<Project>)broker.returnAllProjectForPM(projectManager);
            List<Project> result = (List<Project>)projectLogic.returnAllProjectForPM(projectManager);

            Assert.AreEqual(result.Count, expected.Count);
        }
        [TestMethod]
        public void returnAllProject_CanGetAllProjects_ReturnTrue()
        {
            DBBroker broker = new DBBroker();
            var projectLogic = new ProjectLogic();
           

            List<Project> expected = (List<Project>)broker.returnAllProject();
            List<Project> result = (List<Project>)projectLogic.returnAllProject();

            Assert.AreEqual(result.Count, expected.Count);
        }


        [TestMethod]
        public void randomCodeForProjectCode_GetUniqueCode_ReturnTrue()
        {
  
            var projectLogic = new ProjectLogic();

            var projectCode = projectLogic.randomCodeForProjectCode();

            Assert.IsNotNull(projectCode);
        }

        [TestMethod]
        public void T_createProject_CanCreateProject_ReturnTrue()
        {
            var projectLogic = new ProjectLogic();
            Project project = new Project();
            project.ProjectCode = ProjectCodeTest;
            project.Name = "ProjectTest";
            project.User = new User()
            {
                Username = "igorpanic"
            };
            project.ProjectManager = "igorpanic";
           

            var result = projectLogic.createProject(project);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void updateProject_CanUpdateProject_ReturnTrue()
        {
            var projectLogic = new ProjectLogic();
            Project project = new Project();
            project.ProjectCode = ProjectCodeTest;
            project.Name = "ProjectTest1";
            project.ProjectManager = "igorpanic";


            var result = projectLogic.updateProject(project);

            Assert.IsTrue(result);
        }

        
    }
}

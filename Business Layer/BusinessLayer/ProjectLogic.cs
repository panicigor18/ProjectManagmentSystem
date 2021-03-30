using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace ProjectManagmentSystem.BusinessLayer
{
    public class ProjectLogic
    {
       

        public IList<Project> returnAllProjectForPM(User userLogged)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.returnAllProjectForPM(userLogged);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<Project> returnAllProject()
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.returnAllProject();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool removeProject(Project project)
        {
            try
            {
                DBBroker broker = new DBBroker();

                return broker.removeProject(project);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string randomCodeForProjectCode()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            letters = letters.ToUpper();

            string random = "";
            bool pass = false;
            while (!pass)
            {
                random = "";
                Random rn = new Random();
                for (int i = 0; i < 3; i++)
                {
                    random += letters[rn.Next(0, 25)] + "" + (rn.Next(0, 9));
                }
                Project project = IsProjectCodeUnique(random);
                if (project == null)
                {
                    pass = true;
                }

            }


            return random;
        }

        public Project IsProjectCodeUnique(string random)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.IsProjectCodeUnique(random);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool createProject(Project project)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.createProject(project);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool updateProject(Project project)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.updateProject(project);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

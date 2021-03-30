using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace ProjectManagmentSystem.BusinessLayer
{
    public class TaskLogic
    {
        

        public IList<Task> returnAllTasksForProject(Project project)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.returnAllTasksForProject(project);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool removeTask(Task task)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.removeTask(task);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int returnTaskId()
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.returnTaskId();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool createTask(Task task)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.createTask(task);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool updateTask(Task task)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.updateTask(task);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

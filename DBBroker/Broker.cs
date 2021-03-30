using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagmentSystem;
namespace DBBroker
{
    public class Broker
    {
        public List<Project> returnAllProject()
        {
            List<Project> projects = new List<Project>();
            using (var context = new ProjectManagementSystemEntities())
            {
                projects = context.Database.SqlQuery<Project>("select * from Project").ToList<Project>();
                foreach (var pr in projects)
                {
                    pr.User = context.Database.SqlQuery<User>($"select * from Users where Username='{pr.ProjectManager}'").FirstOrDefault();
                    pr.Tasks = context.Database.SqlQuery<ProjectManagmentSystem.Task>($"select * from Tasks where ProjectCode = '{pr.ProjectCode}'").ToList<Task>();
                    
                }
                /*(from p in context.Projects
                         select new {
                            ProjectCode=p.ProjectCode,
                            Name=p.Name,
                            ProjectManager=p.ProjectManager,
                            Tasks=(from t in context.Tasks where t.ProjectCode==p.ProjectCode select new {TaskID=t.TaskID }).ToList()
                         }).ToList();
            projects = new BindingList<Project>(dataa);*/
                BindingList<Project> projectssss = new BindingList<Project>(projects);
                dvgProjects.DataSource = projectssss;

            }
        }

        
    }
}

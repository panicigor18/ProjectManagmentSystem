using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagmentSystem;
using ProjectManagmentSystem;

namespace ProjectManagmentSystem
{
    public class DBBroker
    {
        public List<Project> returnAllProjectForPM(User userLogged)
        {
            List<Project> projects;
            using (var context = new ProjectManagementSystemEntities())
            {
                projects = context.Database.SqlQuery<Project>($"select * from Project where ProjectManager='{userLogged.Username}'").ToList<Project>();
                foreach (var pr in projects)
                {
                    pr.User = context.Database.SqlQuery<User>($"select * from Users where Username='{pr.ProjectManager}'").FirstOrDefault();
                    pr.Tasks = context.Database.SqlQuery<ProjectManagmentSystem.Task>($"select * from Tasks where ProjectCode = '{pr.ProjectCode}'").ToList<Task>();
                    pr.Progress = 0;
                    foreach (Task task in pr.Tasks)
                    {
                        pr.Progress = (decimal)(pr.Progress + task.Progress);
                    }
                    if (pr.Tasks.Count() > 0)
                        pr.Progress = pr.Progress / pr.Tasks.Count() * 100;
                }



                return projects;


            }
            
        }

        internal List<Task> returnAllTasksForUser(User user)
        {
            List<Task> tasks;
            using (var context = new ProjectManagementSystemEntities())
            {
                tasks = context.Database.SqlQuery<Task>($"select * from Tasks where Assignee='{user.Username}' or Assignee='' order by Assignee desc").ToList<Task>();
            }
            return tasks;
        }

        internal bool isUsernameUnique(string text)
        {
            User user;
            using (var context = new ProjectManagementSystemEntities())
            {
                user = (from u in context.Users
                           where u.Username == text
                           select u
                   ).FirstOrDefault<User>();
                
                
                
            }
            if (user != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool removeUser(User user)
        {
            using (var context = new ProjectManagementSystemEntities())
            {
                try
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlCommand($"DELETE FROM Users WHERE  Username='{user.Username}'");

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    return true;
                }
                catch (Exception)
                {

                    throw;
                    return false;
                }

            }
        }

        internal List<Project> returnAllProject()
        {
            List<Project> projects;
            using (var context = new ProjectManagementSystemEntities())
            {
                projects = context.Database.SqlQuery<Project>("select * from Project").ToList<Project>();
                foreach (var pr in projects)
                {
                    pr.User = context.Database.SqlQuery<User>($"select * from Users where Username='{pr.ProjectManager}'").FirstOrDefault();
                    pr.Tasks = context.Database.SqlQuery<ProjectManagmentSystem.Task>($"select * from Tasks where ProjectCode = '{pr.ProjectCode}'").ToList<Task>();
                    pr.Progress = 0;
                    foreach (Task task in pr.Tasks)
                    {
                        pr.Progress = (decimal)(pr.Progress + task.Progress);
                    }
                    if (pr.Tasks.Count() > 0)
                        pr.Progress = pr.Progress / pr.Tasks.Count() * 100;
                }



                return projects;


            }
        }

        public List<User> reaturnAllUsers()
        {
            List<User> users;
            using(var context=new ProjectManagementSystemEntities())
            {
                users = context.Users.ToList<User>();
                
            }
          

            return users;
        }

        internal int returnTaskId()
        {
            int id;
            using (var context=new ProjectManagementSystemEntities())
            {
                id = context.Tasks.Max(t => t.TaskID)+1;
            }
            return id;
        }

        internal bool updateUser(User user, string oldUsername)
        {
            try
            {
                using (var context = new ProjectManagementSystemEntities())
                {

                    context.Database.ExecuteSqlCommand($"UPDATE Users " +
                                                       $"SET Username ='{user.Username}', Password = '{user.Password}',Email='{user.Email}',Name='{user.Name}', Surname='{user.Surname}',Role='{user.Role}'" +
                                                       $" WHERE  Username='{oldUsername}' ");
                    context.Database.ExecuteSqlCommand($"UPDATE Tasks " +
                                                       $"SET Assignee='{user.Username}'"+
                                                       $" WHERE  Assignee='{oldUsername}' ");

                    context.SaveChanges();


                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        internal bool removeTask(Task task)
        {
            using (var context = new ProjectManagementSystemEntities())
            {
                try
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlCommand($"DELETE FROM Tasks WHERE ProjectCode='{task.ProjectCode}' and TaskID={task.TaskID}");

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    return true;
                }
                catch (Exception)
                {

                    throw;
                    return false;
                }

            }
        }

        public bool createUser(User user)
        {
            try
            {
                using (var context = new ProjectManagementSystemEntities())
                {
                    context.Database.ExecuteSqlCommand($"insert into Users values('{user.Username}','{user.Password}','{user.Email}','{user.Name}','{user.Surname}',{user.Role})");

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool createTask(Task task)
        {
            try
            {
                using (var context = new ProjectManagementSystemEntities())
                {
                    context.Database.ExecuteSqlCommand($"insert into Tasks values({task.TaskID},'{task.ProjectCode}','{task.Assignee}',{task.Status},{task.Progress},'{task.Deadline}','{task.Description}')");

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public List<Task> returnAllTasksForProject(Project project)
        {
            List<Task> tasks;
            using (var context=new ProjectManagementSystemEntities())
            {
                tasks = context.Database.SqlQuery<Task>($"select * from Tasks where ProjectCode='{project.ProjectCode}'").ToList<Task>();
            }
            return tasks;
        }

        internal bool updateTask(Task task)
        {
            try
            {
                using (var context = new ProjectManagementSystemEntities())
                {

                    context.Database.ExecuteSqlCommand($"UPDATE Tasks " +
                                                       $"SET TaskID ={task.TaskID}, ProjectCode = '{task.ProjectCode}',Assignee='{task.Assignee}',Status={task.Status},Progress={task.Progress}, Deadline='{task.Deadline}',Description='{task.Description}'" +
                                                       $" WHERE ProjectCode='{task.ProjectCode}' and TaskID={task.TaskID}; ");

                    context.SaveChanges();


                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        internal bool updateProject(Project project)
        {
            try
            {
                using (var context = new ProjectManagementSystemEntities())
                {
                   
                        context.Database.ExecuteSqlCommand($"UPDATE Project SET Name = '{project.Name}', ProjectManager = '{project.ProjectManager}' WHERE ProjectCode='{project.ProjectCode}'; ");
                       
                        context.SaveChanges();
                        
                    
                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public Project IsProjectCodeUnique(string random)
        {
            Project project;
            using (var context = new ProjectManagementSystemEntities())
            {
                project = (from p in context.Projects
                           where p.ProjectCode == random
                           select p
                   ).FirstOrDefault<Project>();
                return project;
            }
        }

        public List<User> getAllUsersWithRole(int x)
        {
            using(var context =new ProjectManagementSystemEntities())
            {
                List<User> projectManagers = (from u in context.Users
                                              where u.Role==x
                                              select u
                                              ).ToList<User>();
                return projectManagers;
            }
            
            
        }

        public bool createProject(Project project)
        {
            try
            {
                using (var context = new ProjectManagementSystemEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlCommand($"insert into Project values('{project.ProjectCode}','{project.Name}','{project.User.Username}')");
                        
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }

                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
            
            
        }

        internal bool removeProject(Project project)
        {
            using (var context = new ProjectManagementSystemEntities())
            {
                try
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlCommand($"DELETE FROM Tasks WHERE ProjectCode='{project.ProjectCode}'");
                        context.Database.ExecuteSqlCommand($"DELETE FROM Project WHERE ProjectCode='{project.ProjectCode}'");
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                   }
                    return true;
                }
                catch (Exception)
                {

                    throw;
                    return false;
                }
                
            }


        }

        public User Login(string username, string password)
        {
            User user;
            using (var context = new ProjectManagementSystemEntities())
            {

                var query = from us in context.Users
                            where us.Username == username && us.Password == password
                            select us;
                user = query.FirstOrDefault<User>();
            }
            return user;
        }
    }
}

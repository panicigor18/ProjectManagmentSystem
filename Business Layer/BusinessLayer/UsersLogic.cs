using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DataLayer;
namespace ProjectManagmentSystem.BusinessLayer
{
    public class UsersLogic
    {
        

        public User Login(string username, string password)
        {
            
            
                DBBroker broker = new DBBroker();
                return broker.Login(username, password);
            
            
        }

        public bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{5,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                return false;
            }
            /*else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                return false;
            }*/
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 5 or greater than 15 characters.";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return false;
            }
            /*
            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                return false;
            }*/
            else
            {
                return true;
            }
        }

        public object getAllUsersWithRole(int v)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.getAllUsersWithRole(v);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<User> reaturnAllUsers()
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.reaturnAllUsers();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool removeUser(User user)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.removeUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool isUsernameUnique(string text)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.isUsernameUnique(text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Task> returnAllTasksForUser(User user)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.returnAllTasksForUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool updateUser(User user, string oldUsername)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.updateUser(user, oldUsername);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool createUser(User user)
        {
            try
            {
                DBBroker broker = new DBBroker();
                return broker.createUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

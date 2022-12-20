using DayEndTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DayEndTask.Models
{

    public delegate User UserDataGenDelegate(User user);
    public delegate void LoggerDelegate(string arg);
    public class Company:ILogger
    {
  
        public string? Name { get; set; }
       

        public static List<User> userList = new List<User>();
        LoggerDelegate loggerDelegate;
        UserDataGenDelegate userDataGenDelegate;
        string msg = " false";
        public Company()
        {
            userDataGenDelegate = new UserDataGenDelegate(GenerateData);
            loggerDelegate = new LoggerDelegate(SetLogger);
        }

        public  User  GenerateData(  User user )
        {
            user.Username = user.Name + user.Surname;
            user.Email = $"{user.Name}.{user.Surname}@gmail.com";
            return user;
        }
        public void Register(string name,string surname ,string password)
        {
            if (name.Trim()!=string.Empty &surname.Trim() != string.Empty&  password!= string.Empty)
            {
                User user = new User();
                user.Name = name;   
                user.Username = name+surname;
                user.Email = $"{name}.{surname}@gmail.com";
                user.Surname = surname; 
                user.Password = password;
                user = GenerateData(user);
                userList.Add(user);
                userDataGenDelegate.Invoke(user);

                msg = $"Qeydiyyat ugurlu .new user / username:{user.Username} |password: {user.Password} {user.Id}";
            }
            else
            {
                msg = "Qeydiyyat ugursuz oldu";

            }
            loggerDelegate.Invoke(msg);
           
        }

        public void Login(string username,string password)
        {
            string msg = $"asd";
            if (username.Trim() != string.Empty & password != string.Empty)
            {
             var user= userList.FindAll(u=>u.Username==username &u.Password==password).FirstOrDefault();
                if (user!=null)
                {
                    msg = $" user finded sucess / Username:{user.Username} | Email:{user.Email}";
                }
                else
                {
                    msg="Not Such as User";
                }
            }
            else
            {
                msg = "Field cannot be empty";
            }
            loggerDelegate.Invoke(msg);
        }


      
        public void SetLogger(string msg)
        {
            Console.WriteLine($" Company Logger {msg}");
        }

    }
}

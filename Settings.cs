using System;
using System.Windows.Forms;

namespace Assessments
{
     class Settings
    {
       static bool isLoggedIn;
        static string connectionString= @"Data source=add you database engine name;
                                           initial catalog=Database_name;
                                           integrated security=true";
        static int userId;
        static string userName;
        static int role;
        static int statusId;
       


        //Property for login Option in the home page in order to show the login only once at clicked
         static public bool IsLoggedIn
        {
            set
            {
                isLoggedIn = value;
            }
            get
            {
                return isLoggedIn;
            }
        }

        //Property for connecting to the database 
        static public  string ConnectionString
        {
            
            get
            {
                return connectionString;
            }
        }
        // userId property
        static public int UserId
        {
            set
            {
                userId = value;
            }
            get
            {
                return userId;
            }
        }
        //username property
        static public string UserName
        {
            set
            {
                userName = value;

            }
            get
            {
                return userName;
            }
        }

        //Role property
        static public int Role
        {
            set
            {
                role = value;
            }
            get
            {
                return role;
            }
        }

        //StatusiD property
        static public int StatusId
        {
            set
            {
                statusId = value;
            }
            get
            {
                return statusId;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spizy.UserModule
{
    class User
    {
        private string UserName, UserMail, UserPass, UserType;
        

        public User(string userName, string userMail, string password)
        {
            UserName = userName;
            UserMail = userMail;
            UserPass = password;
        }

        /*public User(string userName, string userMail, string userPass)
        {
            UserName = userName;
            UserMail = userMail;
            UserPass = userPass;
        }

        public User(string UserName, string UserMail, string UserPass, string UserType)
        {
            this.UserName = UserName;
            this.UserMail = UserMail;
            this.UserPass = UserPass;
            this.UserType = UserType;
        }*/

        public string User_name { get => UserName; set => UserName = value; }
        public string User_mail { get => UserMail; set => UserMail = value; }
        public string User_pass { get => UserPass; set => UserPass = value; }
        public string User_type { get => UserType; set => UserType = value; }

        public override string ToString()
        {
            return string.Format(this.UserName + " " + this.UserMail + " " + this.UserPass + " " + this.UserType);
        }
    }
}

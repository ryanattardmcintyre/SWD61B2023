using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroductionToClasses
{
    enum Reason {NoMatch, WeakPassword, Ok };

    class Person //is a definition (template) which defines
                 //an entity by grouping a list members/behaviours which best describe that particular entity
    {
        //fields: characteristics which describe the entity (containers for data)
        //note 1: a data type + an identifier
        //note 2: fields are private
        //note 3: (to adopt a good practice you must use) camel casing naming convention
        
        string firstName;
        string password;

        //properties: facilitate control of what goes inside the field and what is read from the field
        //note 1: access modifier + data type + identifier + get + set
        //note 2: properties are normally public
        //note 3: (good practice) pascal case naming convention
        public string FirstName
        {
            get { return firstName; }
            set
            { 
                firstName = value[0].ToString().ToUpper() + value.ToString().ToLower().Substring(1);
            }
        }
        public string Password
        {
            get
            {
                string outgoingpassword = "";
                foreach (char c in password)
                {
                    outgoingpassword += "*";
                }
                return outgoingpassword;
            }
            
        }
        public string LastName { get; set; } //shorthand notation implied you must not declare the field (because it assumes that there's the field hidden)
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string FullName
        {
            get { return firstName + ' ' + LastName;  }
        }


        //methods

        //access modifiers:
        //public - accessible from everywhere
        //private - accessible only from within the same class (the most secure one)
        //protected - accessible only from within the same class and from within inherited classes
        //internal - accessible from within the same project

        //<access modifier> <return type> <method name> ([parameter1, parameter2, parameter3 ...])
        public Reason ResetPassword(string pwd, string confirmationPassword)
        {
            if (pwd == confirmationPassword)
            {
                //in C# we have special characters like these:
                //   \n : new line
                //   \t : tab
                //   \r : skips a line


                if (System.Text.RegularExpressions.Regex.IsMatch(pwd, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$"))
                {
                    password = pwd;
                    return Reason.Ok;
                }
                else return Reason.WeakPassword;


            }
            else return  Reason.NoMatch;
        }

        

    }
}

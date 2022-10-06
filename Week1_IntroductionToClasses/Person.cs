using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroductionToClasses
{
    class Person //is a definition (template) which defines
                 //an entity by grouping a list members/behaviours which best describe that particular entity
    {
        //fields: characteristics which describe the entity (containers for data)
        //note 1: a data type + an identifier
        //note 2: fields are private
        //note 3: (to adopt a good practice you must use) camel casing naming convention
        DateTime dob;
        string gender;
        string firstName;
        string lastName;
        string address;

        string id;
        string email;
        string mobile;
        string password;


        //properties: facilitate control of what goes inside the field and what is read from the field
        //note 1: access modifier + data type + identifier + get + set
        //note 2: properties are normally public
        //note 3: (good practice) pascal case naming convention
         public string FirstName { get; set; }
         public string LastName { get; set; } //shorthand notation

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

 

    }
}

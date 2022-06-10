using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    //This is an example of a composite class
    //A composite class uses other classes/structs in it's definition
    //It is recognized with the phrase "has a" class
    //This Person class "has a" resident address and a List<T> where <T> represents a data type
    //In this class, <T> is a collection of Employment instances and represents a person
    //Review video on Inheritance and Composition in Moodle

    public class Person
    {

        //fields
        private string _FirstName;
        private string _LastName;

        //properties

        public string FirstName
        {
            get { return _FirstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is required.");
                }

                _FirstName = value;
            }
        }

        public string LastName
        {
            get { return _LastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name is required.");
                }

                _LastName = value;
            }

        }

        //composition actually uses the other struct/class as a property/field within the definition of the class being specified
        //In this example, Address is a field (data member)

        public ResidentAddress Address;
        //This field is not a property
        //The data type is a developer-defined data-type (struct)

        public List<Employment> EmploymentPositions
        {
            get;
            private set;
        }

        public int NumberOfPositions
        {
            get { return EmploymentPositions.Count; }
        }

        //Option 1:
        //public Person()
        //{
        //    //the system will automatically assign default system values to
        //    //   our data members according to their data-type
        //    //strings -> null
        //    //objects -> null
        //    //
        //    // Firstname and Lastname have validation voiding a null value and set to default of "Unknown".
        //
        //    FirstName = "Unknown";
        //    LastName = "Unknown";
        //
        //    //if one tried to reference an instance's data and the instance is
        //    //   null THEN one would get a exception: null exception
        //    //even though you have no instances to store, you will at least have
        //    //  someplace to put the data ONCE it is supplied
        //
        //    EmploymentPositions = new List<Employment>();
        //}

        //Option 2
        //Do not code a "Default" constructor
        //Code ONLY the "Greedy" constructor
        //if only a greedy constructor exists for the class, the ONLY
        //  way to possibly create an instance for the class within
        //  the program would be to use the constructor when the class
        //  instance is created

        public Person(string firstname, string lastname, ResidentAddress address,
                        List<Employment> employmentpositions)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employmentpositions != null)
                EmploymentPositions = employmentpositions;
            else
                //allow a null parameter value and the class to have an empty List<T>
                EmploymentPositions = new List<Employment>();
        }

        //methods
        public void AddEmployment(Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException("You must supply an employment record for it to be add to this person");
            }
            EmploymentPositions.Add(employment);
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        // An instance of this class will hold data about a person's employment
        // The code of this class is the definition of that data
        // The characteristics (data) of the class holds data about
        //   Title, SupervisorLevl, Years of employment within the company

        // There are 4 components of a class definition
        //  1. Data fields (data members)
        //  2. Properties
        //  3. Constructors
        //  4. Behaviour (methods)

        // Data fields
        // These are storage areas in your class
        //  and are treated as variables
        // These can be public, private, public read-only

        private string _Title;
        private double _Years;

        //Properties
        // These are access techniques to retrieve data or set data in
        //  your class without directly touching the storage data field
        // A property is associated with a single instance of data
        // A property is public so it can be access by an outside user
        //  of the class
        // A property MUST have a get
        // A property MAY have a set
        // If no set, the property is not changeable by the user; read-only
        //      commonly used for calculated data of the class
        // The set can be either public or private
        //     public: the user can alter the contents of the data
        //     private: only code within the class can alter the contents of the data

        //Fully implemented properties

        // a) a declared storage area (data field)
        // b) a declared property signature (access rdt propertyname)
        // c) a coded accessor (get) coding block : public
        // d) an optional coded mutator (set) coding block :pubic or private
        //    if the set is private the only way to place data into this property is
        //    via the constructor or a behaviour (method)

        //When:
        //  a) if you are storing the associate data in an explicitly declared data field
        //  b) if you are doing validation on incoming data
        //  c) creating a property that generates output from other data sources
        //      within the class (read-only property); this property would ONLY have a
        //      accessor (get)

        public string Title
        {
            //a property is associated with a single piece of data
            get
            {
                //The accessor or get "coding block" will return the contents of a data field(s)
                //The return syntax is 'return expression'
                //Example:
                return _Title;
            }
            set
            {
                //The mutator or set "coding block" receives an incoming value and places it into the
                //  associated data field
                //During the setting, you might wish to validate the incoming data
                // or you might wish to do some type of logical processing using the data to set another field
                //The incoming piece of data is referred to using the keyword "value"

                //Ensure that the incoming string data is not null, empty, or just whitespace
                //Example:
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                //Once it has passed through validation, the data is considered valid and returned
                _Title = value;
            }
        }

        //Auto-implemented properties

        //These properties differ only in syntax
        //Each property is responsible for a single piece of data
        //These properties do not reference a declared private data member or field
        //The system generates an internal storage area of the return data type
        //The system manages the internal storage for the accessor and mutator
        //There is no additional logic applied to the data value!

        //Using an enum for this field will automatically restrict the values this property can contain
        //Syntax:  access rdt propertyname {get; [private] set;}
        //Example:
        public SupervisoryLevel Level { get; private set; }

        public double Years
        {
            get { return _Years; }
            private set
            {
                //Utilities.IsZeroPositive() is located in the Utilities class and used for validation
                if (!Utilities.IsZeroPositive(value))
                {
                    throw new ArgumentOutOfRangeException($"Years of {value} is invalid. Must be 0 or greater");
                }
                _Years = value;
            }
        }

        //Constructors

        //This is used to initialize the physical object (instance) during its creation
        //The result of creation is to ensure that the coder gets an instance in a valid
        //  "known state"

        //If your class definition has NO constructor coded, then the data members and/or
        //  auto-implemented properties are set to the C# default data-type value
        //
        //You can code one or more constructors in your class definition
        //If you code a constructor for the class,  you are responsible for all constructors
        //  used by the class.
        //
        //Generally, if you are going to code your own constructor(s) you can code two types
        //  Default: This constructor does NOT take in any parameters
        //           This constructor mimics the default system constructor
        //
        //  Greedy:  This constructor has a list of parameters, one for each property,
        //           declared for incoming data
        //
        //Syntax: accesstype classname([list of parameters]) {constructor code block}
        //
        //IMPORTANT: The constructor DOES NOT have a return datatype
        //           You DO NOT call a constructor direclty, it is called using the
        //              new command =>    new classname(....);
        //

        //Default constructor
        public Employment()
        {
            //Constructor body
            //  a) empty: values will be set to C# defaults
            //  b) you COULD assign literal values to your properties with this constructor

            //The values that you give your class data members/properties CAN be assigned directly to a data member
            //However, if you have validated properties, you SHOULD consider saving your data values via the property

            //You can code your validation logic within your constructors because objects run your constructor when it is created.
            //Placing your logic in the constructor could be done if your property has a private set
            // OR if your public data member is a read-only data member
            //Private sets and read-only data members can not have their data altered directly

            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        //Greedy (overloaded) Constructor
        public Employment(string title, SupervisoryLevel level, double years = 0.0)
        {
            //constructor body
            //  a) a parameter for each property
            //  b) you COULD could your validation in this constructor
            //  c) validation for public read-only data members MUST be done here
            //  d) validation for properties with a private set MUST be done here
            //      if not done in the property

            //default parameters
            //This allows the programmer to use the constructor/method by specifying all argument in the code to your constructor/method

            //Location: end of parameter list
            //How many: as many as you wish
            //values for your default parameters MUST be a valid value
            //position and order of specified default parameters are important when the
            //  program uses the constructor/method.
            //default parameters CAN be skipped, HOWEVER, you still must account for the
            //  skipped parameter in your argument call list using commas
            //by giving the default parameter an argument value on the call, the constructor/method
            //  default value is overridden

            //syntax: datatype parametername = default value
            //example: years on this constructor is a default parameter

            //example: skipped defaults (3 default parameters, second one skipped
            //    ...(string requiredparam, int requiredparam, int default1 = 0,
            //          int default2 = 0 , int default 3 = 1)
            //
            //call:  ...("required string", 25, 10, , 5)  default2 was skipped

            Title = title;
            Level = level;
            Years = years; //eventually the data will be placed in _Years

        }

        //Behaviours (a.k.a. methods)

        //a behaviour is any method in your class
        //behaviours can be private (for use by the class only); public (for use by the outside
        //  user)
        //all rules about methods are in effect

        //a special method may be placed in your class to reflect the data stored by the
        //  instance (object) based on this class definition
        //this method is part of the system software and can be overriden by your own
        //  version of the method

        public override string ToString()
        {
            //this string is known as a "comma separate values (csv)" string
            //this string uses the get; of the property
            return $"{Title},{Level},{Years}";
        }

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //this method, in this example would not be necessary as the access directly
            //  the Level (property) is public ( set; )
            //HOWEVER: IF the Level property had a private set;, the outsider user would NOT
            //  have direct access to changing the property.
            //THERFORE: a method (besides the constructor) would need to be supplied to allow
            //  the outsider user the ability to alter the property value (if they so desired)

            //this assignment uses the set; of the property
            Level = level;
        }

        //Parse(string)
        //  attempt to change the contents of string to another data type
        //  no condition was checked before doing the change
        //  example  string 55; int x = int.Parse(string); success
        //           string bob; int x = int.Parse(string); aborted

        //bool TryParse(string, out resultVariable)
        //  check to see if the Parse could actually be done
        //  the result of the attempt was
        //  a) true and the converted string value placed into the resultVariable
        //  b) false and no conversion of the string AND NO abort
        //
        //  int resultVariable = 0;
        //  if(TryParse(string, out resultVariable) { ....... }

        //Classes are a developer-defined data-type just like int, double, float, etc.
        //Therefore, should a class be able to take a string can convert it into
        //   an instance of the class?
        //Can a class have their own .Parse and .TryParse?
        //
        //string: "Boss,Owner,5.5" parsed into an instance of Employment
        //

        //Employment.Parse(string)
        //the method will:
        //  validate there are sufficient values for an instance
        //  will us primitive data type .Parse() to convert the individual values
        //  will return a loaded instance of the Employment class
        //  will use the FormatException() if insufficient data is supplied

        //as the instance is loaded on the return statement, the Employment constructor
        //  will be used thus any error generated by the constructor shall still be
        //  created

        //THIS METHOD WILL NOT RETAIN ANY DATA
        //THIS METHOD WILL BE A SHARED METHOD ( static )
        public static Employment Parse(string text)
        {
            //text is a string of csv (comma separated values) values (ex. "value1","value2,"value3"

            //Step 1: Separate the string of values into individual string values
            //The result will be an array of strings
            //Each array element represents a value "{value}"
            //The string class method .Split(delimiter) is used for this action
            //A delimiter can be ANY C# recognized character
            //In a csv string, the delimiter character is a comma

            string[] pieces = text.Split(',');

            //Step 2: Verify that sufficient values exist to create the Employment instance
            if (pieces.Length != 3)
            {
                throw new FormatException($"String not in expected format. Missing value {text}");
            }

            //Step 3: Return a new instance of the Employment class
            //Create a new instance on the return statement
            //As the instance is being created, the Employment constructor will be used
            //ANY validation occurring during the execution of the constructor will still be
            // done, whether the logic is in the constructor OR in the individual property
            //Use the primitive .Parse() methods for C# data-types (For example: int, double, etc.)

            return new Employment(
                        pieces[0],
                        (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]),
                        double.Parse(pieces[2]));
        }

        //The TryParse() method will receive a string AND output an instance of
        // Employment as an output parameter

        //Syntax of a .TryParse:      xxxx.TryParse(string, out receivingVariable)
        //          int example:       int.TryParse(inputData, out myIntegerNumber)
        //
        // xxxx can be any data-type
        //Can xxxx be a class? Yes. Why? Because a class is a developer defined data-type
        //
        //The method will return a boolean value to indicate if the action was successful
        //The action within the method will be to call the .Parse() method
        //This is the same concept of Parsing primitive data types already in C#

        public static bool TryParse(string text, out Employment result)
        {
            //The default value for any class instance (the object) is null

            result = null;
            bool valid = false;
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentNullException("Parsing string is empty");
                }
                //action : try to parse the string using .Parse()
                result = Parse(text);
                valid = true;
            }
            catch (FormatException ex)
            {
                //DO NOT print out the error
                //INSTEAD re throw the exception
                //think of this as a rely race, passing the baton
                //this method DOES NOT actual handle the display of the error
                //the display of an error messages is done by the driver routine (in
                //  out case is the code in Program.cs)
                throw new FormatException(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException(ex.Message);
            }
            catch (Exception ex)
            {
                //handle any other unexpected error
                throw new Exception($"TryParse Employment unexpected error: {ex.Message}");
            }
            return valid;
        }
    }
}

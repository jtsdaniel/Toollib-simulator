using System;


namespace Assignment
{
    public class Member : iMember, IComparable<Member>
    {
        //class fields
        private string firstname;
        private string lastname;
        private string contactnumber;
        private string pin;
        private string[] tools;
        private toolCollection toolsBorrowed;
        /// <summary>
        /// getter setter for member's tool collection (tools borrowed)
        /// </summary>
        public toolCollection ToolsBorrowed 
        {
            get { return toolsBorrowed;}
            set { toolsBorrowed = value;}
        }

        /// <summary>
        /// getter setter for member's first name
        /// </summary>
        public string FirstName { 
            get {return firstname;}
            set {firstname = value;}
         }

        /// <summary>
        /// getter setter for member's last name
        /// </summary>
        public string LastName { 
            get {return lastname;}
            set {lastname = value;}
         }

        /// <summary>
        /// getter setter for member's contact number
        /// </summary>
        public string ContactNumber { 
            get {return contactnumber;}
            set {contactnumber = value;}
        }

        /// <summary>
        /// getter setter for member's PIN
        /// </summary>
        public string PIN { 
            get {return pin;}
            set {pin = value;}
        }

        /// <summary>
        /// getter for member's tools (in string value type)
        /// </summary>
        public string[] Tools {
            get {return tools;}  
        }
        /// <summary>
        /// Constructor for member class
        /// </summary>
        /// <param name="firstname"> string firstname</param>
        /// <param name="lastname">string lastname</param>
        /// <param name="contactnumber">string contact number</param>
        /// <param name="pin">string pin</param>
        public Member(string firstname, string lastname, string contactnumber, string pin) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.contactnumber = contactnumber;
            this.pin = pin;
            tools = new string[3];
            toolsBorrowed = new toolCollection() { };
        }

        /// <summary>
        /// borrow an existed tool from library
        /// </summary>
        /// <param name="newtool"></param>
        public void addTool(Tool newtool)
        {
            //Check for member's storage and tools' stock quantity    
                if (toolsBorrowed.toArray().Length < 3 && newtool.AvailableQuantity > 0) 
                {
                    toolsBorrowed.add(newtool);
                    newtool.AvailableQuantity--;
                    newtool.NoBorrowings++;    
                    Console.WriteLine("Added tool into the inventory.");
                    
                }
                //print message if the member's storage is full
                else if (toolsBorrowed.toArray().Length == 3)
                {
                    Console.WriteLine("No more space to rent tools");
                    
                }
                //print message if the tool's quantity is 0
                else if (newtool.AvailableQuantity == 0) 
                {
                    Console.WriteLine("The tool is out of stock!");                  
                }            
        }
        /// <summary>
        /// delete a tool from the users' storage
        /// </summary>
        /// <param name="tool">tool wanted to remove</param>
        public void deleteTool(Tool tool)
        {
            toolsBorrowed.delete(tool);
            tool.AvailableQuantity++;
            Console.WriteLine("Returned tool.");
        }

        /// <summary>
        /// return string format of members' values
        /// </summary>
        /// <returns> string contain member's values </returns>
        public override string ToString()
        {
            return this.firstname +" "+ this.lastname +" phone number: "+ this.contactnumber;
        }

        /// <summary>
        /// Compare members's values
        /// </summary>
        /// <param name="other">another member wanted to compare</param>
        /// <returns> "0" if similar </returns>
        public int CompareTo(Member other)
        {
            if (this.lastname.CompareTo(other.lastname) < 0){
                return -1;
            } 
            else if (this.lastname.CompareTo(other.lastname) == 0
            && this.firstname.CompareTo(other.firstname) < 0) {
                return -1;
            }

            else if (this.lastname.CompareTo(other.lastname) == 0
            && this.firstname.CompareTo(other.firstname) == 0) {
                return 0;
            }
            else { return 1;}
        }
    }


}
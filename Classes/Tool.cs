namespace Assignment
{
    public  class Tool : iTool
    {
        //fields
        private int index;
        private string name;
        private int quantity;
        private int availablequantity;
        private int noborrowings;
        private MemberCollection borrowers;
        //Constructor
        public Tool(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
            availablequantity = quantity;
            borrowers = new MemberCollection();
        }
        //getter and setter for fields
        public int Index {
            get { return index; }
            set { index = value; }
        }
        public string Name { 
            get{ return name;}
            set{ name = value;}
        }
        public int Quantity {
            get{ return quantity;}
            set{ quantity = value;}
        }
        public int AvailableQuantity {
             get{return availablequantity;}
             set{ availablequantity = value;}
             }
        public int NoBorrowings { 
            get{ return noborrowings;}
            set{ noborrowings = value;}
        }

        public  MemberCollection GetBorrowers
        {
            get{return borrowers;}
        }

        /// <summary>
        /// add a member to the tool's collection of borrowers 
        /// </summary>
        /// <param name="A_member"></param>
        public void addBorrower(Member A_member)
        {
            borrowers.add(A_member);
        }
        /// <summary>
        /// delete a member from the tool's collection of borrowers 
        /// </summary>
        /// <param name="A_member"></param>
        public void deleteBorrower(Member A_member)
        {
            borrowers.delete(A_member);
        }
        /// <summary>
        /// turn tool object into string
        /// </summary>
        /// <returns>string version of the object</returns>
        public override string ToString()
        {
            return this.name +" "+ this.quantity;
        }

       
    }
}
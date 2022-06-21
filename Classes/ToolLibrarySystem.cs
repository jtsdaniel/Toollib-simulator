using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment 
{
    public class toolLibrarySystem : iToolLibrarySystem
    {
        //Needed variables to track the input from user while using system
        static int toolCategoryOption;
        static int toolTypeOption;
        static int toolOption;
        //variable for tracking current user
        static Member currentMember;

        //Tool types collections
        //gardening tools
        static toolCollection lineTrimmers = new toolCollection();
        static toolCollection lawnMowers = new toolCollection();
        static toolCollection handTools = new toolCollection();
        static toolCollection wheelBarrows = new toolCollection();
        static toolCollection gardenPowerTools = new toolCollection();
        //flooring tools
        static toolCollection scapers = new toolCollection();
        static toolCollection floorLasers = new toolCollection();
        static toolCollection floorLevelingTools = new toolCollection();
        static toolCollection floorLevelingMaterials = new toolCollection();
        static toolCollection floorHandsTools = new toolCollection();
        static toolCollection tilingTools = new toolCollection();

        //fencing tools
        static toolCollection fencingHandTools = new toolCollection();
        static toolCollection electricFencing = new toolCollection();
        static toolCollection steelFencingTools = new toolCollection();
        static toolCollection powerTools = new toolCollection();
        static toolCollection fencingAccessories = new toolCollection();
        //measuring tools
        static toolCollection distanceTools = new toolCollection();
        static toolCollection laserMeasurer = new toolCollection();
        static toolCollection measuringJugs = new toolCollection();
        static toolCollection temperatureHumidityTools = new toolCollection();
        static toolCollection levellingTools = new toolCollection();
        static toolCollection markers = new toolCollection();

        //cleaning tools
        static toolCollection draining = new toolCollection();
        static toolCollection carCleaning = new toolCollection();
        static toolCollection vacuum = new toolCollection();
        static toolCollection pressureCleaner = new toolCollection();
        static toolCollection poolCleaning = new toolCollection();
        static toolCollection floorCleaning = new toolCollection();

        //painting tools
        static toolCollection sandingTools = new toolCollection();
        static toolCollection brushes = new toolCollection();
        static toolCollection rollers = new toolCollection();
        static toolCollection paintRemovalTools = new toolCollection();
        static toolCollection paintScrapers = new toolCollection();
        static toolCollection spayers = new toolCollection();
        //electronic tools
        static toolCollection voltageTester = new toolCollection();
        static toolCollection oscilloscopes = new toolCollection();
        static toolCollection thermalImaging = new toolCollection();
        static toolCollection dataTestTool = new toolCollection();
        static toolCollection insulationTesters = new toolCollection();
        //electricity tools
        static toolCollection testEquipment = new toolCollection();
        static toolCollection safetyEquipment = new toolCollection();
        static toolCollection basicHandtools = new toolCollection();
        static toolCollection circuitProtection = new toolCollection();
        static toolCollection cableTools = new toolCollection();
        //automotive tools
        static toolCollection jacks = new toolCollection();
        static toolCollection airCompressors = new toolCollection();
        static toolCollection batteryChargers = new toolCollection();
        static toolCollection socketTools = new toolCollection();
        static toolCollection braking = new toolCollection();
        static toolCollection drivetrain = new toolCollection();

        //Tool category collections
        static toolCollection[] gardeningTools = new toolCollection[] { lineTrimmers, lawnMowers, handTools, wheelBarrows, gardenPowerTools };
        static toolCollection[] flooringTools = new toolCollection[] { scapers, floorLasers, floorLevelingTools, floorLevelingMaterials, floorHandsTools, tilingTools };
        static toolCollection[] fencingTools = new toolCollection[] { fencingHandTools, electricFencing, steelFencingTools, powerTools, fencingAccessories };
        static toolCollection[] measuringTools = new toolCollection[] { distanceTools, laserMeasurer, measuringJugs, temperatureHumidityTools, levellingTools, markers };
        static toolCollection[] cleaningTools = new toolCollection[] { draining, carCleaning, vacuum, pressureCleaner, poolCleaning, floorCleaning };
        static toolCollection[] paintingTools = new toolCollection[] { sandingTools, brushes, rollers, paintRemovalTools, paintScrapers, spayers };
        static toolCollection[] electronicTools = new toolCollection[] { voltageTester, oscilloscopes, thermalImaging, dataTestTool, insulationTesters };
        static toolCollection[] electricityTools = new toolCollection[] { testEquipment, safetyEquipment, basicHandtools, circuitProtection, cableTools };
        static toolCollection[] automotiveTools = new toolCollection[] { jacks, airCompressors, batteryChargers, socketTools, braking, drivetrain };
        //Member collection
        static MemberCollection membersInSystem = new MemberCollection();
        //Tool category collection
        static toolCollection[][] toolsCategory = new toolCollection[][] { gardeningTools, flooringTools,
        fencingTools, measuringTools, cleaningTools, paintingTools, electronicTools, electricityTools,
        automotiveTools};

        /// <summary>
        /// Add a new tool to system
        /// </summary>
        /// <param name="aTool"> Tool wanted to add </param>
        public void add(Tool aTool) 
        {
            //call method from toolcollection class
            toolsCategory[toolCategoryOption-1][toolTypeOption-1].add(aTool);
            Console.WriteLine("Successfully added tool into the Library! ");
        }

        /// <summary>
        /// provide more pieces of an existed tool
        /// </summary>
        /// <param name="aTool">tool wanted to add more pieces</param>
        /// <param name="quantity">quantity wanted to add</param>
        public void add(Tool aTool, int quantity)
        {
            //call methods from tool class
            aTool.AvailableQuantity += quantity;
            aTool.Quantity += quantity;
        }
        /// <summary>
        /// add a new member into system.
        /// </summary>
        /// <param name="aMember">member wanted to add</param>
        public void add(Member aMember)
        {
            membersInSystem.add(aMember);
        }

        /// <summary>
        /// borrow a tool from library
        /// </summary>
        /// <param name="aMember">Member doing the action</param>
        /// <param name="aTool">tool wanted to borrow</param>
        public void borrowTool(Member aMember, Tool aTool)
        {
            aMember.addTool(aTool);
        }

        /// <summary>
        /// delete a tool from system
        /// </summary>
        /// <param name="aTool"></param>
        public void delete(Tool aTool)
        {
            toolsCategory[toolCategoryOption - 1][toolTypeOption - 1].delete(aTool);
            Console.WriteLine("Successfully deleted tool from the Library! ");
        }
        /// <summary>
        /// Remove some pieces of a tool from the system
        /// </summary>
        /// <param name="aTool">Tool wanted to remove pieces</param>
        /// <param name="quantity">quantity wanted to remove</param>
        public void delete(Tool aTool, int quantity)
        {
            aTool.AvailableQuantity -= quantity;
            aTool.Quantity -= quantity;
        }
        /// <summary>
        /// Remove a memeber from system
        /// </summary>
        /// <param name="aMember">member wanted to remove</param>
        public void delete(Member aMember)
        {
            membersInSystem.delete(aMember);
        }
        /// <summary>
        /// Display the tools that a member is borrowing
        /// </summary>
        /// <param name="aMember">member wanted to display</param>
        public void displayBorrowingTools(Member aMember)
        {
            Tool[] memberTools = aMember.ToolsBorrowed.toArray();
            if (memberTools.Length < 1)
            {
                Console.WriteLine("You have not rented any tools.");
            }
            else
            {
                for (int i = 0; i < memberTools.Length; i++)
                {
                    Console.WriteLine((i+1) + ". " + memberTools[i].Name);
                }
            }
        }

        /// <summary>
        /// Display tools in a tool type
        /// </summary>
        /// <param name="aToolType">chosen tool type</param>
        public void displayTools(string aToolType)
        {

            Console.Clear();
            Console.WriteLine("==========Tools Menu========== \n");
            Tool[] toolCollection = toolsCategory[toolCategoryOption - 1][int.Parse(aToolType) - 1].toArray();
            foreach (Tool tool in toolCollection)
            {
                Console.WriteLine((Array.IndexOf(toolCollection, tool) + 1) + ". " + tool.Name + " | Quantity: " + tool.Quantity
                   + " | Available quantity: " + tool.AvailableQuantity + " | " + "Number of borrowers: " + tool.NoBorrowings);
            }
        }
        /// <summary>
        /// Return a list of tools hold by a member
        /// </summary>
        /// <param name="aMember">Member wanted to display</param>
        /// <returns>string array of tool's names</returns>
        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }
        
        /// <summary>
        /// Display top 3 most frequently borrowed tools 
        /// </summary>
        public void displayTopTHree()
        {
            //catch the exception when theres no tools in the library
            try
            {
                //This Heap Sort below is taken from practical materials.
                // convert a complete binary tree into a heap
                static void HeapBottomUp(Tool[] tools)
                {
                    int n = tools.Length;
                    for (int i = (n - 1) / 2; i >= 0; i--)
                    {
                        int k = i;
                        Tool v = tools[i];
                        bool heap = false;
                        while ((!heap) && ((2 * k + 1) <= (n - 1)))
                        {
                            int j = 2 * k + 1;  //the left child of k
                            if (j < (n - 1))   //k has two children
                                if (tools[j].NoBorrowings < tools[j + 1].NoBorrowings)
                                    j = j + 1;  //j is the larger child of k
                            if (v.NoBorrowings >= tools[j].NoBorrowings)
                                heap = true;
                            else
                            {
                                tools[k] = tools[j];
                                k = j;
                            }
                        }
                        tools[k] = v;
                    }
                }

                // sort the elements in an array 
                static void HeapSort(Tool[] tools)
                {
                    //Use the HeapBottomUp procedure to convert the array, data, into a heap
                    HeapBottomUp(tools);


                    //repeatly remove the maximum key from the heap and then rebuild the heap
                    for (int i = 0; i <= tools.Length - 2; i++)
                    {
                        MaxKeyDelete(tools, tools.Length - i);
                    }
                }

                //delete the maximum key and rebuild the heap
                static void MaxKeyDelete(Tool[] tools, int size)
                {
                    //1. Exchange the root’s key with the last key K of the heap;
                    Tool temp = tools[0];
                    tools[0] = tools[size - 1];
                    tools[size - 1] = temp;

                    //2. Decrease the heap’s size by 1;
                    int n = size - 1;

                    //3. “Heapify” the complete binary tree.
                    bool heap = false;
                    int k = 0;
                    Tool v = tools[0];
                    while ((!heap) && ((2 * k + 1) <= (n - 1)))
                    {
                        int j = 2 * k + 1; //the left child of k
                        if (j < (n - 1))   //k has two children
                            if (tools[j].NoBorrowings < tools[j + 1].NoBorrowings)
                                j = j + 1;  //j is the larger child of k
                        if (v.NoBorrowings >= tools[j].NoBorrowings)
                            heap = true;
                        else
                        {
                            tools[k] = tools[j];
                            k = j;
                        }
                    }
                    tools[k] = v;
                }
                //create an array of all the tools currently existed in the library
                toolCollection top3Tool = new toolCollection();
                foreach (toolCollection[] category in toolsCategory)
                {
                    foreach (toolCollection toolType in category)
                    {
                        foreach (Tool tool in toolType.toArray())
                        {
                            top3Tool.add(tool);
                        }
                    }
                }
                Tool[] ranking = top3Tool.toArray();
                //Sort the given array of all available tools in the library (based on its' number of borrows)
                HeapSort(ranking);
                //Display only 3 tools with highest number of borrows. 
                Console.WriteLine("Top 1" + " " + ranking[ranking.Length - 1].Name + " | Number of Borrowers: " + ranking[ranking.Length - 1].NoBorrowings);
                Console.WriteLine("Top 2" + " " + ranking[ranking.Length - 2].Name + " | Number of Borrowers: " + ranking[ranking.Length - 2].NoBorrowings);
                Console.WriteLine("Top 3" + " " + ranking[ranking.Length - 3].Name + " | Number of Borrowers: " + ranking[ranking.Length - 3].NoBorrowings);
            }
            catch (Exception) 
            {
                //Print exception case.
                Console.WriteLine("There's not enough tools in the Library for ranking.");
            }
        }
        /// <summary>
        /// return a tool to library
        /// </summary>
        /// <param name="aMember">member doing the action</param>
        /// <param name="aTool">tool wanted to return</param>
        public void returnTool(Member aMember, Tool aTool)
        {
            aMember.deleteTool(aTool);
        }


                         // Below are the designs for the menu of the application (appearance and the activiy flows.) //
        /// <summary>
        /// Check the input of the user until they give right input (A filter)
        /// </summary>
        /// <param name="input">input from user</param>
        /// <param name="options">a list of available options that the user can choose (most cases are integer number)</param>
        /// <returns> return a valid String input </returns>
        String CheckInput(String input, String[] options) 
        {
            while (!Array.Exists(options, option => option == input))//check user input
            {
                Console.Write("Input must be an integer value (between "+options[0]+" - "+options[options.Length-1]+" ): ");
                input = Console.ReadLine();
            }
            return input;
        }
        /// <summary>
        /// Print out the main menu of program
        /// </summary>
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Welcome to the Tool Library \n" +
                "==========Main Menu========== \n" +
                "1. Staff Login.\n" +
                "2. Member Login.\n" +
                "0. Exit. \n" +
                "=============================\n" +
                "Please make selection (1-2 or 0 to exit)"
                );
            //give the input
            String input = Console.ReadLine();
            //Options can choose from
            String[] options = { "0","1","2"};
            //check the input
            input = CheckInput(input, options);
            //cases based on input
            switch (input)
            {
                //Staff login
                case "1":
                    //Enter account and password 
                    Console.WriteLine("Enter your account name: ");
                    String accountname = Console.ReadLine();
                    Console.WriteLine("Enter your Password: ");
                    String password = Console.ReadLine();
                    //Check the account
                    if (accountname == "staff" && password == "today123")
                    {
                        PrintStaffMenu();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password or Account Name...");
                        Console.ReadLine();
                        PrintMainMenu();
                    }
                    break;

                //Member login
                case "2":
                    //Enter values
                    Console.WriteLine("Enter your account name: ");
                    String accountName = Console.ReadLine(); 
                    Console.WriteLine("Enter your Password: ");
                    password = Console.ReadLine();
                    //Authenticate the member
                    currentMember = LookForMember(accountName);
                    //Member doesn't exist
                    if (membersInSystem.search(currentMember) == false)
                    {
                        Console.WriteLine("Account doesn't exist!");
                        Console.ReadLine();
                        PrintMainMenu();
                    }
                    //Member existed in system
                    else if (membersInSystem.search(currentMember))
                    {
                        //Correct password + account name
                        if (currentMember.FirstName + currentMember.LastName == accountName && password == currentMember.PIN)
                        {
                            PrintMemberMenu();                          
                        }
                        //incorrect password
                        else 
                        {
                            Console.WriteLine("Incorrect Password!");
                            Console.ReadLine();
                            PrintMainMenu();
                        }
                    }
                    break;
                //exit program
                case "0":
                    Console.WriteLine("See you next time...");
                    Environment.Exit(0);
                    break;
            }
        }
        /// <summary>
        /// Print out tool category and track on users' category option
        /// </summary>
        /// <param name="menuType">2 types of menu ("Staff" and "Member")</param>
        void GetToolCategoryOption(String menuType) 
        {
            //choose category
            PrintToolCategory();
            Console.Write("Choose category (1-9 or 0 to turn back): ");
            //check user input
            String option = Console.ReadLine(); 
            String[] options = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            toolCategoryOption = int.Parse(CheckInput(option, options));
            //choose tool type
            switch (toolCategoryOption)
            {
                case 1:
                    Console.Clear();
                    PrintGardeningToolType();
                    break;
                case 2:
                    Console.Clear();
                    PrintFlooringToolType();
                    break;
                case 3:
                    Console.Clear();
                    PrintFencingToolType();
                    break;
                case 4:
                    Console.Clear();
                    PrintMeasuringToolType();
                    break;
                case 5:
                    Console.Clear();
                    PrintCleaningToolType();
                    break;
                case 6:
                    Console.Clear();
                    PrintPaintingToolType();
                    break;
                case 7:
                    Console.Clear();
                    PrintElectronicToolType();
                    break;
                case 8:
                    Console.Clear();
                    PrintElectricityToolType();
                    break;
                case 9:
                    Console.Clear();
                    PrintAutomotiveToolType();
                    break;
                //Print menu depended on which type of user using
                case 0:
                    if (menuType == "Staff")
                    {
                        PrintStaffMenu();
                    }
                    else if (menuType == "Member")
                    {
                        PrintMemberMenu();
                    }
                    break;
            }
        }

        /// <summary>
        /// Print tool types and track on users' tool type option
        /// </summary>
        /// <param name="menuType">2 types of menu ("Staff" and "Member")</param>
        void GetToolTypeOption()
        {
            Console.Write("Choose type of tool (1-" + (toolsCategory[toolCategoryOption - 1].Length) + "): ");
            string option = Console.ReadLine(); 
            //find the suitbale list of possible options for user to choose on.
            String[] typeOptions;
            List<String> optionList = new List<string>();
            for (int i = 1; i < toolsCategory[toolCategoryOption - 1].Length + 1; i++) 
            {
                optionList.Add(i.ToString());
            }
            typeOptions = optionList.ToArray();
            //Check user input until its good to go
            toolTypeOption = int.Parse(CheckInput(option,typeOptions));
            //demonstrate the tools inside tool type
            displayTools(toolTypeOption.ToString());
        }

        /// <summary>
        /// Print all available tools of a tool type and track on users' tool option
        /// </summary>
        /// <param name="menuType">2 types of menu ("Staff" and "Member")</param>
        void GetToolOption(String menuType) 
        {
            int elementInToolType = toolsCategory[toolCategoryOption - 1][toolTypeOption - 1].GetNumber();
            if (elementInToolType != 0)
            {
                //Choose tool options
                Console.Write("Choose tool (1-" + elementInToolType + "): ");
                String input = Console.ReadLine();
                //Check all available options for user to choose
                String[] toolOptions;
                List<String> options = new List<string>();
                for (int i = 1; i < elementInToolType + 1; i++) 
                {
                    options.Add(i.ToString());
                }
                toolOptions = options.ToArray();
                //check user input
                toolOption = int.Parse(CheckInput(input,toolOptions)); 
            }
            else
            {
                //print out if theres no tools to show
                Console.WriteLine("This tool type doesn't have any tools...");
                Console.ReadLine();
                //turn back to menu based on type of user
                if (menuType == "Member")
                {
                    PrintMemberMenu();
                }
                else if (menuType == "Staff")
                {
                    PrintStaffMenu();
                }
            }
        }

        /// <summary>
        /// Force user to give a valid quantity value
        /// </summary>
        /// <returns> a valid int quantity </returns>
        int InputValidQuantity() 
        {
            Boolean valid = false;
            int quantity = -1;
            while (valid == false)
            {
                try
                {
                    Console.Write("Enter quantity: ");
                    quantity = int.Parse(Console.ReadLine());
                    if (quantity >= 0)
                    {
                        valid = true;
                    }
                    else 
                    {
                        valid = false;
                        Console.WriteLine("Input must be positive integer!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be integer!");
                    valid = false;
                }
            }
            return quantity;
        }
        /// <summary>
        /// Print out staff menu
        /// </summary>
        void PrintStaffMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Staff Menu========== \n" +
                "1. Add a new tool.\n" +
                "2. Add new pieces of an existing Tool.\n" +
                "3. Remove some pieces of a Tool. \n" +
                "4. Register a new member.\n" +
                "5. Remove a member.\n" +
                "6. Find the contact number of a member. \n" +
                "0. Back to Main Menu. \n" +
                "=============================\n" +
                "Please make selection (1-6 or 0 to turn back to menu)"
                );
            //check user input
            String input = Console.ReadLine(); 
            String[] options = {"0", "1", "2", "3", "4", "5", "6"};
            input = CheckInput(input, options);
            //Cases from the menu
            switch (input)
            {
                //turn back main menu
                case "0":
                    PrintMainMenu();     
                    break;
                //add new tool to system
                case "1":
                    GetToolCategoryOption("Staff");
                    GetToolTypeOption();
                    //give variables to new tool object
                    Console.Write("Enter tool name: ");
                    String toolName = Console.ReadLine();
                    
                    int toolQuantity = InputValidQuantity(); //check user input
                    Tool newTool = new Tool(toolName, toolQuantity);
                    //add tool into system
                    add(newTool);
                    displayTools(toolTypeOption.ToString());
                    Console.ReadLine();
                    PrintStaffMenu();
                    break;
                //add more quantity of pieces to a tool
                case "2":
                    //"choose-option" flow
                    GetToolCategoryOption("Staff");
                    GetToolTypeOption();
                    GetToolOption("Staff");
                    
                    //check user input
                    int quantity = InputValidQuantity();
                    Tool chosenTool = toolsCategory[toolCategoryOption - 1][toolTypeOption - 1].toArray()[toolOption - 1];
                    add(chosenTool, quantity);
                    //display the tools again to check changes
                    displayTools(toolTypeOption.ToString());
                    Console.WriteLine("Successfully add more pieces to '" + chosenTool.Name + "' tool.");
                    Console.ReadLine();
                    //turn back to menu
                    PrintStaffMenu();
                    break;
                //remove a quantity of pieces from the tool
                case "3":
                    //"choose-option" flow
                    GetToolCategoryOption("Staff");
                    GetToolTypeOption();
                    GetToolOption("Staff");
                    //check input
                    Boolean valid = false;
                    while (valid == false)
                    {                       
                        quantity = InputValidQuantity();
                        chosenTool = toolsCategory[toolCategoryOption - 1][toolTypeOption - 1].toArray()[toolOption - 1];
                        //Check valid quantity to remove
                        if (quantity <= chosenTool.AvailableQuantity)
                        {
                            valid = true;
                            delete(chosenTool, quantity);
                            //Display tools again to check changes
                            displayTools(toolTypeOption.ToString());
                            Console.WriteLine("Successfully remove pieces of '" + chosenTool.Name + "' tool.");
                            Console.ReadLine();
                            //turn back 
                            PrintStaffMenu();
                            break;
                        }
                        else if (quantity > chosenTool.AvailableQuantity)
                        {
                            Console.WriteLine("quantity must be smaller or equal to available quantity: ");
                        }
                    }
                    break;

                //add new member to system
                case "4":
                    //set values
                    string firstName = "";
                    string lastName = "";
                    while (firstName == "")
                    {
                        Console.Write("Regist Account First Name (cannot be empty): ");
                        firstName = Console.ReadLine();
                    }
                    while (lastName == "") 
                    {
                        Console.Write("Regist Account Last Name (cannot be empty): ");
                        lastName = Console.ReadLine();
                    }

                    //check valid phone number
                    Boolean phoneValid = false;
                    String validPhoneNum = "";
                    while (phoneValid == false)
                    {
                        try
                        {
                            Console.Write("Regist Account Phone Number: ");
                            string phoneNum = Console.ReadLine();
                            validPhoneNum = phoneNum;
                            if (int.Parse(phoneNum) >= 0)
                            {
                                phoneValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Phone number cannot be negative integer!");
                                phoneValid = false;
                            }
                        }
                        catch (Exception) 
                        {
                            Console.WriteLine("Phone number must be integer!");
                            phoneValid = false;
                        }
                    }
                  
                    Console.Write("Regist Account PIN: ");
                    string pin = Console.ReadLine();
                    //added
                    Member newMem = new Member(firstName, lastName, validPhoneNum, pin);
                    add(newMem);
                    Console.ReadLine();
                    PrintStaffMenu();
                    break;

                //delete a member from system
                case "5":
                    //Print out user list
                    PrintMemberList();
                    Console.Write("Enter member account name to delete (Combination of first+last name): ");
                    string account = Console.ReadLine();
                    Member member = LookForMember(account);
                    delete(member);
                    Console.ReadLine();
                    PrintStaffMenu();
                    break;
                //return a member's phone number by giving their accountname
                case "6":
                    PrintMemberList();
                    //get accountname
                    Console.Write("Enter member account name (Combination of first+last name): ");
                    account = Console.ReadLine();
                    member = LookForMember(account);
                    //print phone number
                    if (membersInSystem.search(member))
                    {
                        Console.WriteLine(member.ToString());
                        Console.ReadLine();
                        PrintStaffMenu();
                    }
                    //if the member is not existed
                    if (!membersInSystem.search(member))
                    {
                        Console.WriteLine("Account doesn't exist!");
                        Console.ReadLine();
                        PrintStaffMenu();
                    }

                    break;
            }


        }
        /// <summary>
        /// Look for a member by using a given account name "A string with combination of first + last name (no space)"
        /// </summary>
        /// <param name="accountName">the account name</param>
        /// <returns>a member object with combination of first+last name similar to account name</returns>
        Member LookForMember(String accountName) 
        {
            Member wantedMem = null;
            foreach (Member member in membersInSystem.toArray())
            {
                if ((member.FirstName + member.LastName) == accountName)
                {
                    wantedMem = member;
                    break;
                }
            }
            return wantedMem;
        }
        /// <summary>
        /// Print member menu
        /// </summary>
        void PrintMemberMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Member Menu========== \n" +
                "1. Display tools of a Tool Type.\n" +
                "2. Borrow a tool.\n" +
                "3. Return a tool.\n" +
                "4. List all the tools that I am renting.\n" +
                "5. Display top 3 most frequently rented tools.\n" +
                "0. Back to Main Menu. \n" +
                "=============================\n" +
                "Please make selection (1-5 or 0 to turn back to menu)"
                );
            //check user option
            String[] options = {"0", "1", "2", "3", "4", "5"};
            String input = Console.ReadLine();
            input = CheckInput(input, options);
            //cases
            switch (input)
            {
                //turn back main menu
                case "0":
                    PrintMainMenu();
                    break;
                //view currently available tool categories, tool types and tools in library
                case "1":
                    //"choose-option" flow
                    GetToolCategoryOption("Member");
                    GetToolTypeOption();
                    Console.WriteLine("Press enter to turn back main menu...");
                    Console.ReadLine();
                    PrintMemberMenu();
                    break;

                //borrow a tool from library
                case "2":
                    //"choose-option" flow to find needed tool
                    GetToolCategoryOption("Member");
                    GetToolTypeOption();
                    GetToolOption("Member");
                    //borrow the tool
                    Tool chosenTool = toolsCategory[toolCategoryOption - 1][toolTypeOption - 1].toArray()[toolOption - 1];
                    borrowTool(currentMember, chosenTool);
                    Console.ReadLine();
                    //reset display to see the changes
                    displayTools(toolTypeOption.ToString());
                    Console.WriteLine("Press enter to turn back menu.");
                    Console.ReadLine();
                    PrintMemberMenu();
                    break;
                
                //Return a tool
                case "3":
                    Console.Clear();
                    //variables to adjust the U.I option numbers.
                    Tool[] toolBorrowed = currentMember.ToolsBorrowed.toArray();
                    int numOfBorrowTools = currentMember.ToolsBorrowed.GetNumber();
                    //Print U.I
                    Console.WriteLine("==========Members' Tool List========== \n");
                    //No tool in inventory
                    if (numOfBorrowTools == 0)
                    {
                        Console.WriteLine("You haven't borrowed any tools");
                    }
                    //exist tools in inventory
                    else if (numOfBorrowTools > 0)
                    {
                        displayBorrowingTools(currentMember);
                        Console.Write("Enter (1-"+toolBorrowed.Length+") to choose tool to return: ");
                        input = Console.ReadLine();
                        //Check all available options for user to choose
                        String[] toolOptions;
                        List<String> tempList = new List<string>();
                        for (int i = 0; i < toolBorrowed.Length; i++) 
                        {
                            tempList.Add((i + 1).ToString());
                        }
                        toolOptions = tempList.ToArray();
                        //check user input
                        toolOption = int.Parse(CheckInput(input, toolOptions));
                        toolBorrowed[toolOption-1].Index = toolOption-1;
                        returnTool(currentMember,toolBorrowed[toolOption-1]);
                    }
                    //turn back to menu
                    Console.ReadLine();
                    Console.WriteLine("\n Press enter to turn back to Menu...");
                    PrintMemberMenu();
                    break;

                //display members' tools
                case "4":
                    Console.Clear();
                    Console.WriteLine("==========Members' Tool List========== \n");
                    displayBorrowingTools(currentMember);
                    Console.ReadLine();
                    Console.WriteLine("\n Press enter to turn back to Menu...");
                    PrintMemberMenu();
                    break;
                //display top 3 tools
                case "5":
                    Console.Clear();
                    Console.WriteLine("==========TOP 3========== \n");
                    displayTopTHree();
                    Console.ReadLine();
                    Console.WriteLine("\n Press enter to turn back to Menu...");
                    PrintMemberMenu();
                    break;
            }

        }


        /// <summary>
        /// Print out a member list
        /// </summary>
        void PrintMemberList() 
        {
            Console.Clear();
            Member[] members = membersInSystem.toArray();
            Console.WriteLine("========== Member Menu ========== \n");
            foreach (Member mem in members)
            {
                Console.WriteLine(mem.ToString());
            }
        }
        /// <summary>
        /// print tool category
        /// </summary>
        void PrintToolCategory()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Tool Category========== \n" +
                "1. Gardening Tools.\n" +
                "2. Flooring Tools.\n" +
                "3. Fencing Tools. \n" +
                "4. Measuring Tools.\n" +
                "5. Cleaning Tools.\n" +
                "6. Painting Tools. \n" +
                "7. Electronic Tools.\n" +
                "8. Electricity Tools.\n" +
                "9. Automotive Tools. \n" +
                "0. Back to Menu. \n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: gardening
        /// </summary>
        void PrintGardeningToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Gardening Tool Type========== \n" +
                "1. Line Trimmers.\n" +
                "2. Lawn Mowers.\n" +
                "3. Hand Tools. \n" +
                "4. Wheelbarrows.\n" +
                "5. Garden Power Tools.\n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: flooring
        /// </summary>
        void PrintFlooringToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Flooring Tool Type========== \n" +
                "1. Scrapers.\n" +
                "2. Floor Lasers.\n" +
                "3. Floor Levelling Tools. \n" +
                "4. Floor Levelling Materials.\n" +
                "5. Floor Hand Tools.\n" +
                "6. Tiling Tools.\n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: fencing
        /// </summary>
        void PrintFencingToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Fencing Tool Type========== \n" +
                "1. Hand Tools.\n" +
                "2. Electric Fencing.\n" +
                "3. Steel Fencing Tools. \n" +
                "4. Power Tools.\n" +
                "5. Fencing Accessories.\n" +
                "=============================\n");
        }

        /// <summary>
        /// print tool type: measuring
        /// </summary>
        void PrintMeasuringToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Measuring Tool Type========== \n" +
                "1. Distance Tools.\n" +
                "2. Laser Measurer.\n" +
                "3. Measuring Jugs. \n" +
                "4. Temperature & Humidity Tools.\n" +
                "5. Levelling Tools.\n" +
                "6. Markers.\n" +
                "=============================\n");
        }

        /// <summary>
        /// print tool type: cleaning
        /// </summary>
        void PrintCleaningToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Cleaning Tool Type========== \n" +
                "1. Draining.\n" +
                "2. Car Cleaning.\n" +
                "3. Vacuum. \n" +
                "4. Pressure Cleaners.\n" +
                "5. Pool Cleaning.\n" +
                "6. Floor Cleaning.\n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: painting
        /// </summary>
        void PrintPaintingToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Painting Tool Type========== \n" +
                "1. Sanding Tools.\n" +
                "2. Brushes.\n" +
                "3. Rollers. \n" +
                "4. Paint Removal Tools.\n" +
                "5. Paint Scrapers.\n" +
                "6. Sprayers.\n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: electronic
        /// </summary>
        void PrintElectronicToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Electronic Tool Type========== \n" +
                "1. Voltage Tester.\n" +
                "2. Oscilloscopes.\n" +
                "3. Thermal Imaging. \n" +
                "4. Data Test Tool.\n" +
                "5. Insulation Testers.\n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: electricity
        /// </summary>
        void PrintElectricityToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Electricity Tool Type========== \n" +
                "1. Test Equipment.\n" +
                "2. Safety Equipment.\n" +
                "3. Basic Hand tools. \n" +
                "4. Circuit Protection.\n" +
                "5. Cable Tools.\n" +
                "=============================\n");
        }
        /// <summary>
        /// print tool type: automotive
        /// </summary>
        void PrintAutomotiveToolType()
        {
            Console.Clear();
            Console.WriteLine(
                "==========Automotive Tool Type========== \n" +
                "1. Jacks.\n" +
                "2. Air Compressors.\n" +
                "3. Battery Chargers. \n" +
                "4. Socket Tools.\n" +
                "5. Braking.\n" +
                "6. Drivetrain. \n" +
                "=============================\n");
        }
    }
}

using System;
using BSTreeInterface;
namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            toolLibrarySystem system = new toolLibrarySystem();
            Member Duy = new Member("Test", "User1", "091885", "123");
            Member Huy = new Member("Test", "User2", "091992", "123");
            Member Toan = new Member("Test", "User3", "09121123", "123");
            
            system.add(Duy);
            system.add(Huy);
            system.add(Toan);
            system.PrintMainMenu();
        }
    }
}



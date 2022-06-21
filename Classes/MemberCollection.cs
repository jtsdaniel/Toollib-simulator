using System;
using System.Collections.Generic;

namespace Assignment
{
    public class MemberCollection : iMemberCollection
    {
       //fields
        private int count = 0;
        private BSTree members;
        private Member[] memberList;
        private Stack<Member> stackList;

        //Class's constructor 
        public MemberCollection() {
            members = new BSTree();
        }

        /// <summary>
        /// add a new member to this member collection, make sure there are no duplicates in the member collection
        /// </summary>
        /// <param name="member"></param>
        public void add(Member member)
        {
            if (!search(member)) {
                members.Insert(member);
                Console.WriteLine("Added " + member.FirstName + " " + member.LastName + " to system!");
                count++;
            }
            else { Console.WriteLine("Account is already existed!"); }
            
        }
        /// <summary>
        /// delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        /// </summary>
        /// <param name="member"></param>
        public void delete(Member member)
        {
            
            if (search(member))
            {
                int numToolsBorrowed = member.ToolsBorrowed.toArray().Length;
                if (numToolsBorrowed < 1)
                {
                    members.Delete(member);
                    Console.WriteLine("Deleted " + member.FirstName + " " + member.LastName + " from system!");
                    count--;
                }
                else if (numToolsBorrowed > 0) { Console.WriteLine("Can't remove this member because he/she is holding tools."); }
            }
            else { Console.WriteLine("Account doesn't exist"); }
           
        }
        /// <summary>
        /// get number of member in the collection
        /// </summary>
        /// <returns>number of members</returns>
        public int GetNumber()
        {
            return count;
        }

        /// <summary>
        /// Search for a member in the collection
        /// </summary>
        /// <param name="member"></param>
        /// <returns> true if existed and false otherwise </returns>
        public bool search(Member member)
        {
            return members.Search(member);
        }


        /// <summary>
        /// turn member collection into array
        /// </summary>
        /// <returns>array of members</returns>
        public Member[] toArray()
        {
            stackList = members.PreOrderTraverse();
            memberList = stackList.ToArray();
            return memberList;
        }
    }
}
   
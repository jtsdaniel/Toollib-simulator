using System;
using System.Linq;

namespace Assignment
{
    public class toolCollection : iToolCollection
    {
        //fields
        private Tool[] tools;
        private int count = 0;
        private int capacity = 0;
        //Constructor
        public toolCollection()
        {
            tools = new Tool[capacity];
        }
        /// <summary>
        /// Add new tool into collection
        /// </summary>
        /// <param name="tool"> new tool object </param>
        public void add(Tool tool)
        {
            
                Tool[] newArray = new Tool[capacity + 1];
                if (count == 0)
                {
                    newArray[count] = tool;
                    tools = newArray;
                    capacity = tools.Length;
                }
                else if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        newArray[i] = tools[i];
                    }
                    newArray[count] = tool;
                    tools = newArray;
                    capacity = tools.Length;
                }
                count++;
           
        }
        
        /// <summary>
        /// Delete a tool in collection
        /// </summary>
        /// <param name="tool">tool object wanted to remove</param>
        public void delete(Tool tool)
        {
            //index received from user
            int pos = tool.Index;
            for (int i = pos; i < tools.Length-1; i++)
            {
                tools[i] = tools[i + 1];
            }
            count--;
            capacity = tools.Length - 1;
            Tool[] temp = new Tool[capacity];
            for (int i = 0; i < capacity; i++) 
            {
                temp[i] = tools[i];
            }
            tools = temp;
            capacity = tools.Length;
        }

        /// <summary>
        /// Return a total number of tools in collection
        /// </summary>
        /// <returns></returns>
        public int GetNumber()
        {
            return count;
        }
        /// <summary>
        /// Search a tool in collection
        /// </summary>
        /// <param name="tool">tool wanted to search</param>
        /// <returns>True if existed and false otherwise</returns>
        public bool search(Tool tool)
        {
            Boolean status = false;
            foreach (Tool element in tools) {
                if (element.Name == tool.Name) {
                    status = true;
                }
            } 
            return status;
        }
        /// <summary>
        /// Turn the collection into array
        /// </summary>
        /// <returns> return an array of tools </returns>
        public Tool[] toArray()
        {
            return tools.ToArray();
        }
    }
}
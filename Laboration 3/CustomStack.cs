using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //Implementing the IIntegerList
    class CustomStack : IIntegerList
    {
        private class Node
        {
            public int data;
            public Node PreviousNode;
        }
        Node topNode;
        //Constructor
        public CustomStack(int Length)
        {
            this.topNode = null;
        }

        //Implementing the pop function it will return the first element in the stack
        public int Pop()
        {
            if (topNode == null)
            {
                Console.WriteLine("Can't perform the operation");
                return -1;
            }
            int popElement = topNode.data;
            topNode = topNode.PreviousNode;
            return popElement;
        }

        //Adding the element into Stack
        public void Push(int number)
        {
            Node newNode = new Node();
            //If the stack is empty
            if (newNode == null)
            {
                Console.WriteLine("Node can't be inserted");
            }
            newNode.data = number;
            newNode.PreviousNode = topNode;
            //Update Top Reference
            topNode = newNode;
        }

        //The shift will return the last element of the STACK (LIFO)
        public int Shift()
        {
            if (topNode == null)
                return 0;

            if (topNode.PreviousNode == null)
            {
                int dataToReturn = topNode.data;
                topNode = null;
                return dataToReturn;
            }
            // Find the second last node 
            Node second_last = topNode;
            while (second_last.PreviousNode.PreviousNode != null)
                second_last = second_last.PreviousNode;

            int data = second_last.PreviousNode.data;
            // Change next of second last 
            second_last.PreviousNode = null;

            return data;
        }
        public void SortAscending()
        {
            SortAscending(this);
        }
        public void SortAscending(CustomStack stack)
        {
            stack.topNode = this.mergeSort(stack.topNode);
            var sortedArray = ToArray();
        }

        //Using the extension method to sort the array in Descending
        public void SortDescending()
        {
            SortDescending(this);
        }
        public void SortDescending(CustomStack stack)
        {
            topNode = SelectionSortAppliedOnLinkedList(stack.topNode, DetermineLength(stack.topNode));
            var array = ToArray();
        }

        //The complexity for Selection Sort is O(N ^ 2)
        //The space complexity for O(1)
        Node SelectionSortAppliedOnLinkedList(Node TopNode, int count)
        {
            //Getting the variables to keep hold of the linked nodes
            Node _current = TopNode;
            Node _previous = _current;
            //Assuming that the current node is max
            Node _Max = _current;
            Node _maxPrevious = _Max;
            Node TopNodeOfSortedList = null;
            //Setting the head of the sorted list
            Node _sortedListTail = TopNodeOfSortedList;
            //Looping over the linked list
            for (int i = 0; i < count; i++)
            {
                //ReAssigning the top and current nodes
                _current = TopNode;
                _Max = _current;
                _maxPrevious = _Max;
                //Find max node untill there are elements
                while (_current != null)
                {
                    //If the data is greater that means change the max to current
                    if (_current.data >= _Max.data)
                    {
                        _Max = _current;
                        _maxPrevious = _previous;
                    }
                    _previous = _current;
                    _current = _current.PreviousNode;
                }
                // If the max element is the top node
                if (_Max == TopNode)
                {
                    TopNode = TopNode.PreviousNode;
                }
                //if the max element is at the tail 
                else if (_Max.PreviousNode == null)
                {
                    _maxPrevious.PreviousNode = null;
                }
                else
                {
                    //exchanging the addresses
                    _maxPrevious.PreviousNode = _maxPrevious.PreviousNode.PreviousNode;
                }
                //Attach max Node to the new sorted linked list
                if (TopNodeOfSortedList != null)
                {
                    _sortedListTail.PreviousNode = _Max;
                    _sortedListTail = _sortedListTail.PreviousNode;
                }
                else
                {
                    TopNodeOfSortedList = _Max;
                    _sortedListTail = TopNodeOfSortedList;
                }
            }
            return TopNodeOfSortedList;
        }
        int DetermineLength(Node head)
        {
            //Getting the top node
            Node curr = head;
            //Setting the count variable
            int count = 0;
            //Checking if the nodes are null
            while (curr != null)
            {
                //Increment the count
                count++;
                //Change the top node
                curr = curr.PreviousNode;
            }
            //return the number of elements
            return count;
        }

        //return the stack
        public int[] ToArray()
        {
            //Determining the length of the Array
            int lengthOfArray = DetermineLength(topNode);
            //Create Array
            int[] LinkedListArray = new int[lengthOfArray];
            //Set the index to 0
            int index = 0;
            //Get the top Node
            Node currentNode = topNode;
            //If the node is not at the end
            while (currentNode != null)
            {
                //Adding data in the Array
                LinkedListArray[index++] = currentNode.data;
                //Changing the top node
                currentNode = currentNode.PreviousNode;
            }
            //Return the Array
            return LinkedListArray;
        }


        //Implementing Merge Sort for the Sorting
        //Complexity of Merge Sort O(nLogN)
        //Space complexity of Merge Sort O(1)
        Node mergeSort(Node h)
        {
            // Base case : if head is null 
            if (h == null || h.PreviousNode == null)
            {
                return h;
            }

            // get the middle of the list 
            Node middle = getMiddle(h);
            Node nextofmiddle = middle.PreviousNode;

            // set the next of middle node to null 
            middle.PreviousNode = null;

            // Apply mergeSort on left list 
            Node left = mergeSort(h);

            // Apply mergeSort on right list 
            Node right = mergeSort(nextofmiddle);

            // Merge the left and right lists 
            Node sortedlist = sortedMerge(left, right);
            return sortedlist;
        }
        Node sortedMerge(Node a, Node b)
        {
            Node result = null;
            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;

            /* Pick either a or b, and recur */
            if (a.data <= b.data)
            {
                result = a;
                result.PreviousNode = sortedMerge(a.PreviousNode, b);
            }
            else
            {
                result = b;
                result.PreviousNode = sortedMerge(a, b.PreviousNode);
            }
            return result;
        }

        Node getMiddle(Node h)
        {
            // Base case 
            if (h == null)
                return h;
            Node fastptr = h.PreviousNode;
            Node slowptr = h;

            // Move fastptr by two and slow ptr by one 
            // Finally slowptr will point to middle node 
            while (fastptr != null)
            {
                fastptr = fastptr.PreviousNode;
                if (fastptr != null)
                {
                    slowptr = slowptr.PreviousNode;
                    fastptr = fastptr.PreviousNode;
                }
            }
            return slowptr;
        }

    }
}

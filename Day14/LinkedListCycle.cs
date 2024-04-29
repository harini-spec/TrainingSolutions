using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x)
        {
            val = x;
        }
    }

    public class CycleLinkedList
    {
        public static void Main(string[] args)
        {
            CycleLinkedList solution = new CycleLinkedList();
            solution.CheckForCycle();
        }

        private async Task CheckForCycle()
        {
            ListNode head = await GetInputFromUser();
            head = await CreateCycle(head);
            bool CyclePresent = await HasCycle(head);
            if (CyclePresent)
            {
                Console.WriteLine("Cycle is present");
            }
            else
            {
                Console.WriteLine("Cycle not present");
            }
        }

        private async Task<ListNode> CreateCycle(ListNode head)
        {
            Console.WriteLine("If you want to create a cycle, provide the position of the node to link to. Else enter -1");
            int NodePos;
            while(! int.TryParse(Console.ReadLine(), out NodePos))
            {
                Console.WriteLine("Enter a valid number");
            }
            if (NodePos == -1) return head;
            int pos = 1;
            ListNode temp = head, Node = head ;
            while(temp.next != null)
            {
                temp = temp.next;
            }
            while(pos != NodePos)
            {
                Node = Node.next;
                pos++;
            }
            temp.next = Node;
            return head;
        }

        private async Task<int> GetNumberFromUser()
        {
            int n;
            while(!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Please enter a valid number");
            }
            return n;
        }

        public async Task<ListNode> GetInputFromUser()
        {
            Console.WriteLine("Enter your input. -1 to stop");
            int n = await GetNumberFromUser();
            ListNode head = null;
            ListNode temp = null;

            while (n != -1)
            {
                ListNode node = new ListNode(n);
                if(head == null)
                {
                    head = node;
                    temp = head;
                }
                else
                {
                    temp.next = node;
                    temp = temp.next;
                }
                n = await GetNumberFromUser();
            }
            return head;
        }

        // Hare and Tortoise algorithm
        public async Task<bool> HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode tortoise = head;
            ListNode hare = head;

            while (hare.next != null)
            {
                tortoise = tortoise.next;
                hare = hare.next.next;
                if (hare == null) return false;
                if (tortoise == hare)
                    return true;
            }
            return false;
        }
    }
}

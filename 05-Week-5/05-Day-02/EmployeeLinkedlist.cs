using System;

namespace EmployeeLinkedList
{
    // Node class
    class Node
    {
        public int EmpId;
        public string Name;
        public Node Next;

        public Node(int id, string name)
        {
            EmpId = id;
            Name = name;
            Next = null;
        }
    }

    class EmployeeList
    {
        private Node head;

        // Insert at Beginning
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.Next = head;
            head = newNode;
        }

        // Insert at End
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
        }

        // Delete by Employee ID
        public void Delete(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            // If head needs to be deleted
            if (head.EmpId == id)
            {
                head = head.Next;
                return;
            }

            Node temp = head;
            Node prev = null;

            while (temp != null && temp.EmpId != id)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                Console.WriteLine("Employee not found");
                return;
            }

            prev.Next = temp.Next;
        }

        // Display list
        public void Display()
        {
            Node temp = head;

            if (temp == null)
            {
                Console.WriteLine("No employees");
                return;
            }

            while (temp != null)
            {
                Console.WriteLine(temp.EmpId + " - " + temp.Name);
                temp = temp.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList list = new EmployeeList();

            // Sample Input
            list.InsertAtEnd(101, "John");
            list.InsertAtEnd(102, "Sara");
            list.InsertAtEnd(103, "Mike");

            // Delete employee
            list.Delete(102);

            // Output
            Console.WriteLine("Employee List After Deletion:");
            list.Display();
        }
    }
}
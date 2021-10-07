using System;

namespace LinkedList
{
    internal class Node
    {
        internal int data;
        internal Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
    internal class SingleLinkedList
    {
        internal Node head;
    }
    internal void InsertFront(SingleLinkedList singlyList, int new_data)
    {
        Node new_node = new Node(new_data);
        new_node.next = singlyList.head;
        singlyList.head = new_node;
    }
}



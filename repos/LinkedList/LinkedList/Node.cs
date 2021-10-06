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
}



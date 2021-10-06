using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedList
    {
        private Node head;
        private Node current;
        public int Count;
    }
    public LinkedList()
    {
        head = new Node();
        current = head;
    }
}

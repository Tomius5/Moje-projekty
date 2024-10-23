using System;
using System.ComponentModel.Design;
namespace Spojový_seznam;

class Program
{
    static void Main(string[] args)
    {
        Node uzlik = new Node(8);
        Linkedlist seznam = new Linkedlist();
        seznam.Add(8);
        seznam.Add(3);
        seznam.Add(3);
        seznam.Add(10);
        Console.WriteLine("Nejnižší hodnota v seznamu: " + seznam.Findlowest());
    }
    class Node
    {
        public Node(int value) // konstruktor
        {
            Value = value;
        }
        public int Value { get; }
        public Node Next { get; set; }
    }
    class Linkedlist
    {
        public Node Head { get; set; }

        public void Add(int value) //přidám prvek do seznamu
        {
            if (Head == null) //zatím máme prázdný seznam
                Head = new Node(value);
            else
            {
                Node newNode = new Node(value);
                newNode.Next = Head;
                Head = newNode;
            }
        }
        public bool Find(int value)
        {
            Node node = Head;
            while (node != null) //dokud nejsme na konci seznamu
            {
                if (node.Next.Value == value)
                    return true;
                node = node.Next;
            }
            return false;
        }
        public int FindLowest()
        {
            if (Head == null)
                throw new InvalidOperationException("Seznam je prázdný."); //Z Googlu, protože potřebuju vrátit intnebo error

            Node node = Head;
            int lowest = node.Value;

            while (node != null)
            {
                if (node.Value < lowest)
                {
                    lowest = node.Value;
                }
                node = node.Next;
            }

            return lowest;
        }
        public string PrintAllVallues()
        {
            if (Head == null)
            {
                string odpoved = "Seznam je prázdný";
                return odpoved;
            }   
            Node node = Head;
            string allValues = ""
            while (node != null)
            {
                allValues += node.ToString();
                allValues += ", ";
            }
            return allValues;
        }

    }
}

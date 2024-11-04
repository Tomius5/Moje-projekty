using System;
using System.ComponentModel.Design;

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
       
        Linkedlist seznamzwei = new Linkedlist();
        seznamzwei.Add(8);
        seznamzwei.Add(4);
        seznamzwei.Add(5);
        seznamzwei.Add(10);
   
        string values = seznam.PrintAllVallues();
        Console.WriteLine("Hodnoty ve spojovem seznamu:");
        Console.WriteLine(values);
   
        seznam.SortLinkedList();
        string sorted = seznam.PrintAllVallues();
       
        Console.WriteLine("Seřazený spojový seznam:");
        Console.WriteLine(sorted);
       
        string prunik = seznam.PenetrationOfLinkedLists(seznamzwei);
        Console.WriteLine("Průnik spojovych seznamů: " + prunik);
       
        string sjednoceni = seznam.UnificationOfLinkedLists(seznamzwei);
        Console.WriteLine("Sjednocení spojovych seznamů: " + sjednoceni);
       
        Console.ReadLine();
    }
    class Node
    {
        public Node(int value) // konstruktor
        {
            Value = value;
        }
   
        public int Value { get; set; }  // Nyní je vlastnost zapisovatelná
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
            while (node != null) // dokud nejsme na konci seznamu
            {
                if (node.Value == value)
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
        public string PrintAllVallues() //Časová složitost O(n)
        {
            if (Head == null)
            {
                string odpoved = "Seznam je prázdný";
                return odpoved;
            }
            Node node = Head;
            string allValues = "";
            while (node != null)
            {
                allValues += node.Value;
                allValues += ", ";
                node = node.Next;
            }
            string allValuesfixed = allValues.Substring(0, allValues.Length - 2); //pardon, ale nemohl jsem již dále trpět čárku na konci výpisu hodnot.
            return allValuesfixed;
        }
        public void SortLinkedList() //Časová složitost O(n^2)
        {
            if (Head == null)
                throw new InvalidOperationException("Seznam je prázdný.");
            if (Head.Next == null)
                return;
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                Node current = Head;
                while (current.Next != null)
                {
                    if (current.Value > current.Next.Value)
                    {
                        int temp = current.Value;
                        current.Value = current.Next.Value;
                        current.Next.Value = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            }
        }
        public string PenetrationOfLinkedLists(Linkedlist otherList) //Časová složitost O(n^2)
        { //Ze školy jsme měli chybu v funkci Find(), musel jsem ji fixnout, jinak toto nefungovalo
            if (Head == null)
                return "∅";  //Matematický průnik zde není
            if (otherList.Head == null)
                return "∅";
            Node current = Head;
            string result = "";
            while (current != null)
            {
                if (otherList.Find(current.Value))
                {
                    result += current.Value + ", ";
                }
                current = current.Next;
            }
            if (result == "") //zase jsem se na to nemohl koukat
                return "∅";
            if (result == "∅")
                return result;
            string resultfixed = result.Substring(0, result.Length - 2);
            return resultfixed;
        }
        public string UnificationOfLinkedLists(Linkedlist otherList) //Časová složitost O(2n)
        {
            if (Head == null)
                throw new InvalidOperationException("Jeden ze seznamů je prázdný.");
            if (otherList.Head == null)
                throw new InvalidOperationException("Jeden ze seznamů je prázdný.");
            Node current = Head;
            string result = "";
            while (current != null)
            {
                if (!result.Contains(current.Value.ToString() + ", "))
                {
                    result += current.Value + ", ";
                }
            current = current.Next;
            }
            current = otherList.Head;
            while (current != null)
            {
                if (!result.Contains(current.Value.ToString() + ", "))
                {
                    result += current.Value + ", ";
                }
            current = current.Next;
            } //Už jsem chtěl napsat, že to rovnou seřadím, ale pak mi došlo, že to bych musel řadit string a to se mi nechce :)
            //Na odstraňování čárek už kašlu, za 1) další bonusové body bych už nedostal, za 2) musím jít pracovat na reakci na Princeznu nevěstu
            return result;
        }
    }

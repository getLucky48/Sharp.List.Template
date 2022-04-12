using System;

namespace Sharp.List.Template
{

    class Node<T>
    {

        public T value { get; set; }
        public Node<T> prev { get; set; }
        public Node<T> next { get; set; }

        public Node(T value)
        {

            this.value = value;
            prev = null;
            next = null;

        }

    }

    class List<T>
    {

        private Node<T> root { get; set; }
        private Node<T> tail { get; set; }
        private int count { get; set; }

        public List()
        {

            root = null;
            tail = null;
            count = 0;

        }

        public void Add(T value, int pos)
        {

            if (pos < 0 || pos > count)
            {

                Console.WriteLine($"Не удалось добавить элемент на позицию {pos}");

                return;

            }

            Node<T> node = new Node<T>(value);

            if (root == null)
            {

                root = node;
                tail = node;

            }
            else if (pos == count)
            {

                Node<T> last = tail;

                node.prev = last;
                last.next = node;

                tail = node;

            }
            else if (pos == 0)
            {

                Node<T> first = root;

                first.prev = node;
                node.next = first;

                root = node;

            }
            else
            {

                int counter = 0;

                Node<T> current = root;

                while (counter != pos)
                {

                    current = current.next;

                    counter++;

                }

                current.prev.next = node;

                node.next = current;
                node.prev = current.prev;

                current.prev = node;

            }

            count++;

        }

        public void Print()
        {

            Node<T> current = root;

            if (root == null)
            {

                Console.WriteLine("Список пуст");

                return;

            }

            while (current != null)
            {

                Console.Write($"{current.value} ");

                current = current.next;

            }

            Console.WriteLine();

        }

        public void SwapFirstWithLast()
        {

            if(count < 2) { return; }

            if(count == 2)
            {

                Node<T> temp = root;
                root = tail;
                tail = temp;

                root.next = tail;
                root.prev = null;

                tail.prev = root;
                tail.next = null;

            }
            else
            {

                Node<T> rootNext = root.next;
                Node<T> tailPrev = tail.prev;

                Node<T> temp = root;
                root = tail;
                tail = temp;

                root.prev = null;
                tail.next = null;

                root.next = rootNext;
                rootNext.prev = root;
                
                tail.prev = tailPrev;
                tailPrev.next = tail;

            }

        }

    }

}


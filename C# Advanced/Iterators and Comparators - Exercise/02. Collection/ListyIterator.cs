﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            bool hasNext = this.HasNext();
            if (hasNext)
            {
                this.index++;
            }

            return hasNext;
        }
        public bool HasNext()
        {
            if (this.index < this.elements.Count - 1)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (this.elements.Count > 0)
            {
                Console.WriteLine(this.elements[this.index]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

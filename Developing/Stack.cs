﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Developing.MyClasses
{
    namespace List
    {
        public class Stack<T> : IEnumerable<T>, IMyClasses<T>
        {
            private int _counter = 0;
            public int Size => _counter;

            private Node.SinglyLinked<T> _topNode = null;
            public Node.SinglyLinked<T> TopNode => _topNode;
            public T Peek => _topNode.Value;
            
            public bool IsEmpty => Size == 0;

            public Stack()
            {

            }
            public Stack(T[] arr)
            {
                foreach (var val in arr)
                {
                    Push(val);
                }

                _counter = arr.Length;
            }

            public void Push(T value)
            {
                this._counter++;

                Node.SinglyLinked<T> newNode = new Node.SinglyLinked<T>(value);

                if (_topNode == null)
                {
                    _topNode = newNode;
                    return;
                }

                newNode.Next = _topNode;
                _topNode = newNode;
            }
            public void Pop()
            {
                if (IsEmpty) return;

                _counter--;
                _topNode = _topNode.Next;
            }
            public Stack<T> Copy()
            {
                T[] tmp = (T[])this;
                Array.Reverse(tmp);

                return tmp;
            }

            public static explicit operator T[](Stack<T> stack)
            {
                T[] res = new T[stack.Size];

                int i = 0;
                //Node.SinglyLinked<T> ptr = stack.TopNode.SinglyLinked;

                foreach (var v in stack)
                {
                    res[i] = v;
                    i++;
                }

                Array.Reverse(res);

                return res;
            }
            public static implicit operator Stack<T>(T[] arr) => new Stack<T>(arr);

            public static Stack<T> operator +(Stack<T> lhs, Stack<T> rhs)
            {
                if (lhs.IsEmpty) return rhs.Copy();
                if (rhs.IsEmpty) return lhs.Copy();

                T[] lhsT = (T[])lhs, rhsT = (T[])rhs;
                T[] resT = new T[lhsT.Length + rhsT.Length];

                for (int i = 0; i < resT.Length; i++)
                {
                    resT[i] = i < lhsT.Length ? lhsT[i] : rhsT[i - lhsT.Length];
                }

                return resT;
            }
            public static Stack<T> operator -(Stack<T> lhs, Stack<T> rhs)
            {
                if (lhs.IsEmpty) return rhs.Copy();
                if (rhs.IsEmpty) return lhs.Copy();

                Stack<T> res = new Stack<T>();

                foreach (var lhsV in lhs)
                {
                    bool met = false;

                    foreach (var rhsV in rhs)
                    {
                        if ((dynamic)lhsV == (dynamic)rhsV) met = true;
                    }

                    if (!met) res.Push(lhsV);
                }

                return res;
            }
            public static bool operator ==(Stack<T> lhs, Stack<T> rhs)
            {
                //if (IsNull(lhs) || IsNull(rhs)) return false;
                if (lhs.Size != rhs.Size) return false;

                Node.SinglyLinked<T> rptr = rhs.TopNode;

                foreach (var v in lhs)
                {
                    if ((dynamic)v != (dynamic)rptr.Value) return false;

                    rptr = rptr.Next;
                }

                return true;
            }
            public static bool operator !=(Stack<T> lhs, Stack<T> rhs)
            {
                return !(lhs == rhs);
            }

            private T this[int idx]
            {
                get
                {
                    if (idx > this.Size || idx < 0) throw new IndexOutOfRangeException();

                    return ((T[])this)[idx];
                }
                set
                {
                    if (idx > this.Size || idx < 0) throw new IndexOutOfRangeException();
                    //if (IsEmpty || IsNull(this)) throw new Exception();

                    Node.SinglyLinked<T> tmp = TopNode;

                    int i = 0;
                    while (tmp != null && i != idx)
                    {
                        tmp = tmp.Next;
                        i++;
                    }

                    tmp.Value = value;
                }
            }

            public Stack<T> Sort()
            {
                var res = (T[])this;

                Array.Sort(res);

                return res;
            }


            /// <inheritdoc />
            void IMyClasses<T>.FillWith(T element, int howMany)
            {
                if (IsEmpty) return;

                for (int i = 0; i < howMany; i++)
                {
                    Push(element);
                }
            }

            /// <inheritdoc />
            public override bool Equals(object obj)
            {
                return this == (Stack<T>)obj;
            }

            /// <inheritdoc />
            public override int GetHashCode() => HashCode.Combine(this._topNode, this._counter);

            /// <inheritdoc />
            public override string ToString()
            {
                return string.Join(" -> ", (T[])this);
            }

            // version 3 (see Node.SinglyLinked class)
            public IEnumerator<T> GetEnumerator()
            {
                return _topNode.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
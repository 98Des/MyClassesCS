﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Developing.Arrays;
using Developing.GeneralExtensions;
using Developing.Lists;
using Developing.Nodes;
using Developing.Tree;

//using System.Collections.Generic;
//using System.Linq;

namespace CS_Test_Chamber.Chamber
{
    static class Program
    { 
        static Sequence _rand = new (25, Seed: 12);

        static void Main(string[] args)
        {
            var avl = new AvlTree<int>();
            var bst = new BstTree<int>();

            foreach (var elem in _rand)
            {
                avl.Insert(elem);
                bst.Insert(elem);
            }

            Console.WriteLine(_rand);
            Console.WriteLine();
            avl.Print2D();
            Console.WriteLine("\n\n");
            bst.Print2D();
        }
    }
}

/*
 * TODO: Implement:                             Status:
 * TODO:            2D printing for BTrees      Done
 * TODO:            2D pr. vertical
 * TODO:            Biparental heap
 * TODO:            Leftist heap
 * TODO:            Skew heap
 * TODO:            Binomial queue
 * TODO:            Fibonacci queue
 * TODO:            BST tree                    Done
 * TODO:            AVL tree                    Done
 * TODO:            B-tree
 * TODO:            2-3 tree
 * TODO:            2-3-4 tree
 * TODO:            BR tree
 * TODO:            Splay tree
 * TODO:            RST tree
 * TODO:            AVL<->BR<->2-3-4 conv.  
 *
 * TODO: Experiment:
 * TODO:            Try unsafe on BST<int>
 * TODO:            And comp. unit tests
 *
 * TODO: Refactor:
 * TODO:            Heap (completely)           Done
 */
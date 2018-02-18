using System;
using System.Runtime.InteropServices.ComTypes;

namespace BST
{
    public class Tree
    {
        private Node _root;

        public bool Insert(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                return true;
            }
            return InsertRecoursive(_root, value) != null;
        }

        private Node InsertRecoursive(Node root, int value)
        {
            if (root == null)
                return new Node(value);

            if (value > root.Value)
                root.Right = InsertRecoursive(root.Right, value);
            else if (value < root.Value)
                root.Left = InsertRecoursive(root.Left, value);
            else
                return null; // duplicated value

            return root;
        }

        public int? FindMaxValueWithThreshold(int threshold)
        {
            if (_root == null)
                return null;

            int? biggestValueBelowThreshold = null;
            var root = _root;

            do
            {
                if (biggestValueBelowThreshold.HasValue)
                {
                    if (biggestValueBelowThreshold < root.Value && root.Value < threshold)
                        biggestValueBelowThreshold = root.Value;
                }
                else
                {
                    if (root.Value < threshold)
                        biggestValueBelowThreshold = root.Value;
                }

                root = GetNodeBelowThreshold(root, threshold);
            } while (root != null);

            return biggestValueBelowThreshold;
        }

        private Node GetNodeBelowThreshold(Node root, int threashold)
        {
            if (root.Value < threashold)
                return root.Right;
            return root.Left;
        }

    }
}

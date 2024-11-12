using System;
using UnityEngine;

public class AVLTree : TreeABB
{
   
    public new void Insert(int value)
    {
        root = InsertRecursively(root, value);
    }

    private NodeABB InsertRecursively(NodeABB node, int value)
    {
   
        if (node == null)
        {
            return new NodeABB(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertRecursively(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRecursively(node.Right, value);
        }
        else
        {
            return node; 
        }

      
        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        
        int balance = GetBalance(node);

        
        if (balance > 1 && value < node.Left.Value)
        {
            return RotateRight(node);
        }

        
        if (balance < -1 && value > node.Right.Value)
        {
            return RotateLeft(node);
        }

        
        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

       
        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private int GetHeight(NodeABB node)
    {
        return node?.Height ?? 0;
    }


    private int GetBalance(NodeABB node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }


    private NodeABB RotateRight(NodeABB y)
    {
        NodeABB x = y.Left;
        NodeABB T2 = x.Right;

        
        x.Right = y;
        y.Left = T2;

       
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

       
        return x;
    }

    
    private NodeABB RotateLeft(NodeABB x)
    {
        NodeABB y = x.Right;
        NodeABB T2 = y.Left;

      
        y.Left = x;
        x.Right = T2;

       
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        
        return y;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TreeABB
{
    public NodeABB root; // Nodo ra�z del �rbol

    // M�todo para insertar un nuevo valor en el �rbol

    public void Insert(int value)
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

        return node;
    }

    // M�todo para obtener el nodo ra�z
    public NodeABB GetRoot()
    {
        return root;
    }

    // M�todo de recorrido In-Order (izquierda - ra�z - derecha)
    public void InOrder()
    {
        Console.WriteLine("InOrder:");
        InOrderRecursively(root);
    }

    private void InOrderRecursively(NodeABB node)
    {
        if (node != null)
        {
            InOrderRecursively(node.Left);
            Console.Write(node.Value + " ");
            InOrderRecursively(node.Right);
        }
    }

    // M�todo de recorrido Pre-Order (ra�z - izquierda - derecha)
    public void PreOrder()
    {
        Console.WriteLine("\nPreOrder:");
        PreOrderRecursively(root);
    }

    private void PreOrderRecursively(NodeABB node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderRecursively(node.Left);
            PreOrderRecursively(node.Right);
        }
    }

    // M�todo de recorrido Post-Order (izquierda - derecha - ra�z)
    public void PostOrder()
    {
        Console.WriteLine("\nPostOrder:");
        PostOrderRecursively(root);
    }

    private void PostOrderRecursively(NodeABB node)
    {
        if (node != null)
        {
            PostOrderRecursively(node.Left);
            PostOrderRecursively(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    // M�todo para calcular la mayor profundidad (altura) del �rbol
    public int GetMaxDepth()
    {
        return CalculateDepth(root);
    }

    private int CalculateDepth(NodeABB node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            int leftDepth = CalculateDepth(node.Left);
            int rightDepth = CalculateDepth(node.Right);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}


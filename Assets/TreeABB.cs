using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TreeABB
{
    public NodeABB root; // Nodo raíz del árbol

    // Método para insertar un nuevo valor en el árbol

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

    // Método para obtener el nodo raíz
    public NodeABB GetRoot()
    {
        return root;
    }

    // Método de recorrido In-Order (izquierda - raíz - derecha)
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

    // Método de recorrido Pre-Order (raíz - izquierda - derecha)
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

    // Método de recorrido Post-Order (izquierda - derecha - raíz)
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

    // Método para calcular la mayor profundidad (altura) del árbol
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


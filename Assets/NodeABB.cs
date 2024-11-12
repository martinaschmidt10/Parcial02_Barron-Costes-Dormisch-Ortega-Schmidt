using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeABB
{
    public int Value;        
    public NodeABB Left;       
    public NodeABB Right;      
    public int Height;         

    public NodeABB(int value)
    {
        Value = value;
        Left = null;
        Right = null;
        Height = 1; 
    }
}
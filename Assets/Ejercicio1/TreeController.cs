using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeController : MonoBehaviour
{
    public GameObject nodePrefab;         
    public float horizontalSpacing = 2f;  
    public float verticalSpacing = 2f;    
    public Transform treeStartPos;

    private TreeABB tree;                 

    void Start()
    {
   
        tree = new TreeABB();
        int[] myArray = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

        foreach (int value in myArray)
        {
            tree.Insert(value);
        }

   
        int maxDepth = tree.GetMaxDepth();
        Debug.Log("Mayor profundidad: " + maxDepth);

       
        DisplayTree();
    }

   
    void DisplayTree()
    {
        if (tree != null && tree.GetRoot() != null)
        {
            DisplayNode(tree.GetRoot(), treeStartPos.position, 0);  
        }
        else
        {
            Debug.Log("Tree or root node is null");
        }
    }

    
    void DisplayNode(NodeABB node, Vector2 position, int depth)
    {
        if (node == null) return;

        
        GameObject newNode = Instantiate(nodePrefab, position, Quaternion.identity);
        newNode.name = "Node_" + node.Value;

        
        TextMeshProUGUI textComponent = newNode.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = node.Value.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found in nodePrefab");
        }


        Vector2 leftPosition = position + new Vector2(-horizontalSpacing / (depth + 1), -verticalSpacing);
        Vector2 rightPosition = position + new Vector2(horizontalSpacing / (depth + 1), -verticalSpacing);

 
        if (node.Left != null)
        {
            DisplayNode(node.Left, leftPosition, depth + 1);
            DrawLine(position, leftPosition);
        }
        if (node.Right != null)
        {
            DisplayNode(node.Right, rightPosition, depth + 1);
            DrawLine(position, rightPosition);
        }
    }


    void DrawLine(Vector2 start, Vector2 end)
    {
        GameObject line = new GameObject("Line");
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = new Material(Shader.Find("Sprites/Default")); 
    }
}

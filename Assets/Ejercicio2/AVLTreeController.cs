using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      
using TMPro;               

public class AVLTreeController : MonoBehaviour
{
    public GameObject nodePrefab;             
    public float horizontalSpacing = 2f;      
    public float verticalSpacing = 2f;        
    public TMP_InputField inputField;        
    public Transform AVLtreePos;

    private AVLTree tree;                     

    void Start()
    {
        tree = new AVLTree();                 
        DisplayTree();                        
    }

    
    public void AddNodeFromInput()
    {
        if (int.TryParse(inputField.text, out int nodeValue))
        {
            tree.Insert(nodeValue);           
            DisplayTree();                    
            inputField.text = "";             
        }
        else
        {
            Debug.LogWarning("Please enter a valid integer value.");
        }
    }

    
    private void DisplayTree()
    {
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        
        DisplayNode(tree.GetRoot(), AVLtreePos.position, 0);
    }

    
    private void DisplayNode(NodeABB node, Vector2 position, int depth)
    {
        if (node == null) return;

        
        GameObject newNode = Instantiate(nodePrefab, position, Quaternion.identity, transform);
        TextMeshProUGUI text = newNode.GetComponentInChildren<TextMeshProUGUI>();
        text.text = node.Value.ToString();

        
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

    
    private void DrawLine(Vector2 start, Vector2 end)
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

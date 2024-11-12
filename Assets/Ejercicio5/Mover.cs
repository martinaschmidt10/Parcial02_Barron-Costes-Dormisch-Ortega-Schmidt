using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public List<Node> path = new List<Node>(); 
    public float moveSpeed = 2f;

    private int currentIndex = 0;
    
    
    private void Update()
    {
        if (path == null || path.Count == 0)
        {
            Debug.LogError("Path is not assigned or is empty!");
            return;
        }

        
        Transform targetNode = path[currentIndex].transform;
        transform.position = Vector3.MoveTowards(transform.position, targetNode.position, moveSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetNode.position) < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= path.Count)
            {
                Debug.Log("Reached the end of the path.");
                enabled = false; 
               
            }
        }

    }
    
}


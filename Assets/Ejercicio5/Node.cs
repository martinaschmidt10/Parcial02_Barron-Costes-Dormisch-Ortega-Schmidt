using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isWalkable = true; 
    public Vector2Int position; 
    public List<Node> neighbors = new List<Node>(); 

    private void OnDrawGizmos()
    {
        Gizmos.color = isWalkable ? Color.white : Color.gray; 
        Gizmos.DrawCube(transform.position, Vector3.one * 0.9f);
    }
}

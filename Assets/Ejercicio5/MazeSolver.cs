using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSolver : MonoBehaviour
{
    public Graph<Node> graph = new Graph<Node>();
    public Node startNode;
    public Node goalNode;
    public GameObject moverObject; 
    public EdgeVisualizer edgeVisualizer; 

    private List<Node> path;

    private void Start()
    {
        InitializeGraph();
        DrawEdges(); 
        path = graph.GetShortestPath(startNode, goalNode);
        Debug.Log("Path found: " + (path != null ? string.Join(" -> ", path) : "No path"));


        if (path != null && path.Count > 0)
        {
            Mover moverScript = moverObject.GetComponent<Mover>();
            if (moverScript != null)
            {
                moverScript.path = path; 
                StartCoroutine(MoveAlongPath());
            }
        }
        else
        {
            Debug.Log("No path found from start to goal.");
        }
    }

    private void InitializeGraph()
    {
        Node[] nodes = FindObjectsOfType<Node>();
        foreach (Node node in nodes)
        {
            if (node.isWalkable)
            {
                graph.AddNode(node);
                foreach (Node neighbor in node.neighbors)
                {
                    if (neighbor.isWalkable)
                    {
                        graph.AddNode(neighbor);
                        graph.AddEdge(node, neighbor, 1);
                    }
                }
            }
        }
    }

    private IEnumerator MoveAlongPath()
    {
        foreach (Node node in path)
        {
            moverObject.transform.position = node.transform.position;
            yield return new WaitForSeconds(0.5f); 
        }
    }

    private void DrawEdges()
    {
        foreach (var node in graph.nodes)
        {
            foreach (var (neighbor, cost) in node.Value)
            {
                
                edgeVisualizer.DrawEdge(node.Key.transform.position, neighbor.transform.position, Color.green);
            }
        }
    }
}

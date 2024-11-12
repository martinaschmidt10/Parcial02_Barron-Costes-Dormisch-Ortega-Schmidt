using System.Collections.Generic;
using UnityEngine;

public class EdgeVisualizer : MonoBehaviour
{
    private List<LineRenderer> lines = new List<LineRenderer>();

   
    public void DrawEdge(Vector3 start, Vector3 end, Color color)
    {
        GameObject lineObject = new GameObject("EdgeLine");
        lineObject.transform.SetParent(transform); 

        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        lines.Add(lineRenderer);
    }

    public void ClearEdges()
    {
        foreach (var line in lines)
        {
            Destroy(line.gameObject);
        }
        lines.Clear();
    }
}

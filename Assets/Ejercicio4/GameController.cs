using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;                 
    public Graphs<Planet> graph;           
    public List<Planet> planets = new List<Planet>(); 

    private void Start()
    {
        
        graph = new Graphs<Planet>();

        
        
        int planetName = 0;

        foreach (Planet planet in planets)
        {
            
            planet.planetName = "Planet " + planetName;
            planetName++;

          
            graph.AddNode(planet);
        }

       
        AddConnectionWithLine(planets[0], planets[1], 7);
        AddConnectionWithLine(planets[0], planets[2], 9);
        AddConnectionWithLine(planets[1], planets[2], 10);
        AddConnectionWithLine(planets[2], planets[3], 4);
        AddConnectionWithLine(planets[3], planets[4], 6);
        AddConnectionWithLine(planets[3], planets[7], 13);
        AddConnectionWithLine(planets[1], planets[5], 12);
        AddConnectionWithLine(planets[5], planets[4], 2);
        AddConnectionWithLine(planets[4], planets[6], 4);
        AddConnectionWithLine(planets[6], planets[7], 11);
        AddConnectionWithLine(planets[5], planets[6], 9);
        AddConnectionWithLine(planets[7], planets[8], 2);
        AddConnectionWithLine(planets[6], planets[9], 17);
        AddConnectionWithLine(planets[9], planets[10], 7);
        AddConnectionWithLine(planets[9], planets[11], 14);
        AddConnectionWithLine(planets[8], planets[10], 10);
        AddConnectionWithLine(planets[10], planets[11], 6);

        
        player.transform.position = planets[0].transform.position;
        player.currentPlanet = planets[0];
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            if (hitCollider != null)
            {
                Planet clickedPlanet = hitCollider.GetComponent<Planet>();
                if (clickedPlanet != null && clickedPlanet != player.currentPlanet)
                {
                    
                    var connections = graph.GetConnections(player.currentPlanet);
                    foreach (var connection in connections)
                    {
                        if (connection.Item1 == clickedPlanet)
                        {
                            player.TravelToPlanet(clickedPlanet, connection.Item2);
                            break;
                        }
                    }
                }
            }
        }
    }

    private void AddConnectionWithLine(Planet from, Planet to, int cost)
    {
        
        graph.AddEdge(from, to, cost);

        
        GameObject lineObject = new GameObject("LineConnection");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        
        lineRenderer.SetPosition(0, from.transform.position);
        lineRenderer.SetPosition(1, to.transform.position);

        
        GameObject costTextObject = new GameObject("CostText");
        costTextObject.transform.SetParent(lineObject.transform);

        
        TextMeshPro textMeshPro = costTextObject.AddComponent<TextMeshPro>();
        textMeshPro.text = cost.ToString(); 
        textMeshPro.fontSize = 7; 
        textMeshPro.color = Color.black;
        textMeshPro.sortingOrder = 1;

        
        Vector3 midPoint = (from.transform.position + to.transform.position) / 2;
        costTextObject.transform.position = midPoint;

        
        textMeshPro.alignment = TextAlignmentOptions.Center;

    }

}


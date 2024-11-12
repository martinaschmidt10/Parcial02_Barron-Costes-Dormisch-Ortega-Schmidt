using System.Collections.Generic;
using UnityEngine;

public class Graph<T>
{
    public Dictionary<T, List<(T, int)>> nodes = new Dictionary<T, List<(T, int)>>();

    public void AddNode(T node)
    {
        if (!nodes.ContainsKey(node))
        {
            nodes[node] = new List<(T, int)>();
        }
    }

    public void AddEdge(T from, T to, int cost)
    {
        if (nodes.ContainsKey(from) && nodes.ContainsKey(to))
        {
            nodes[from].Add((to, cost));
            nodes[to].Add((from, cost)); 
        }
    }

    public List<T> GetShortestPath(T start, T goal)
    {
        Dictionary<T, int> distances = new Dictionary<T, int>();
        Dictionary<T, T> previous = new Dictionary<T, T>();
        List<T> unvisited = new List<T>();

        foreach (var node in nodes.Keys)
        {
            distances[node] = int.MaxValue;
            unvisited.Add(node);
        }
        distances[start] = 0;

        while (unvisited.Count > 0)
        {
            T currentNode = default(T);
            int minDistance = int.MaxValue;

            foreach (var node in unvisited)
            {
                if (distances[node] < minDistance)
                {
                    minDistance = distances[node];
                    currentNode = node;
                }
            }

            if (currentNode.Equals(goal))
            {
                break;
            }

            unvisited.Remove(currentNode);

            foreach (var (neighbor, cost) in nodes[currentNode])
            {
                int alt = distances[currentNode] + cost;
                if (alt < distances[neighbor])
                {
                    distances[neighbor] = alt;
                    previous[neighbor] = currentNode;
                }
            }
        }

        List<T> path = new List<T>();
        T current = goal;
        while (!current.Equals(start))
        {
            if (!previous.ContainsKey(current))
            {
                return null;
            }
            path.Insert(0, current);
            current = previous[current];
        }
        path.Insert(0, start);

        return path;
    }
}

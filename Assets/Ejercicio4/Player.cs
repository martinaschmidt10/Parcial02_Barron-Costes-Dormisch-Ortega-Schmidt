using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Planet currentPlanet; 
    public float moveSpeed = 5f;  
    
    public void TravelToPlanet(Planet targetPlanet, int cost)
    {
        if (currentPlanet != targetPlanet)
        {
            StartCoroutine(MoveToPlanet(targetPlanet.transform.position));
            Debug.Log($"Travelling to {targetPlanet.planetName} with a cost of {cost} points.");
            currentPlanet = targetPlanet;
        }
    }

   
    private IEnumerator MoveToPlanet(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

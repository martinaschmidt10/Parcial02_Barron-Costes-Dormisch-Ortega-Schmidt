using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSetTest : MonoBehaviour
{
    private DynamicSet<int> set1;
    private DynamicSet<int> set2;

    void Start()
    {
        set1 = new DynamicSet<int>();
        set2 = new DynamicSet<int>();

        set1.Add(1);
        set1.Add(2);
        set1.Add(3);

        set2.Add(3);
        set2.Add(4);
        set2.Add(5);

        Debug.Log("Set 1:");
        set1.Show();
        Debug.Log("Set 2:");
        set2.Show();

        var unionSet = set1.Union(set2);
        Debug.Log("Union Set:");
        unionSet.Show();


        var intersectionSet = set1.Intersect(set2);
        Debug.Log("Intersection Set:");
        intersectionSet.Show();

        var differenceSet = set1.Difference(set2);
        Debug.Log("Difference Set:");
        differenceSet.Show();
    }
}
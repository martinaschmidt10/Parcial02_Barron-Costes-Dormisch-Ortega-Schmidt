using UnityEngine;

public class StaticSetTest : MonoBehaviour
{
    private StaticSet<int> staticSet1;
    private StaticSet<int> staticSet2;

    void Start()
    {
        
        staticSet1 = new StaticSet<int>(5);
        staticSet2 = new StaticSet<int>(5);

      
        staticSet1.Add(1);
        staticSet1.Add(2);
        staticSet1.Add(3);
        staticSet1.Add(4);

        staticSet2.Add(3);
        staticSet2.Add(4);
        staticSet2.Add(5);
        staticSet2.Add(6);


        Debug.Log("Static Set 1:");
        staticSet1.Show();

        Debug.Log("Static Set 2:");
        staticSet2.Show();


        Debug.Log("Cardinality of Static Set 1: " + staticSet1.Cardinality());
        Debug.Log("Cardinality of Static Set 2: " + staticSet2.Cardinality());

        Debug.Log("Set 1 contains 2: " + staticSet1.Contains(2)); 
        Debug.Log("Set 2 contains 7: " + staticSet2.Contains(7));

        var unionSet = staticSet1.Union(staticSet2);
        Debug.Log("Union of Static Set 1 and Static Set 2:");
        unionSet.Show();


        var intersectSet = staticSet1.Intersect(staticSet2);
        Debug.Log("Intersection of Static Set 1 and Static Set 2:");
        intersectSet.Show();

        var differenceSet = staticSet1.Difference(staticSet2);
        Debug.Log("Difference (Static Set 1 - Static Set 2):");
        differenceSet.Show();

        staticSet1.Remove(4);
        Debug.Log("Static Set 1 after removing 4:");
        staticSet1.Show();
        Debug.Log("Cardinality of Static Set 1 after removing 4: " + staticSet1.Cardinality());
    }
}
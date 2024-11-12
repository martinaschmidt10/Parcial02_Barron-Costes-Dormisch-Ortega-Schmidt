using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetDatos<T>
{

    void Add(T Item);
    void Remove(T Item);
    bool Contains(T Item);
    void Show();
    int Cardinality();
    bool IsEmpty();
    ISetDatos<T> Union(ISetDatos<T> otherSet);
    ISetDatos<T> Intersect(ISetDatos<T> otherSet);
    ISetDatos<T> Difference(ISetDatos<T> otherSet);


}

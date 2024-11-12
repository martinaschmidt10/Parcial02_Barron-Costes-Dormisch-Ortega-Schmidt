using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSet<T> : ISetDatos<T>
{

    public T[] SetArray;
    public int currentSize;
    public int capacity;

    public StaticSet(int capacity)
    {
        this.capacity = capacity;
        SetArray = new T[capacity];
        currentSize = 0;
    }

    public void Add(T item)
    {
        if (currentSize >= capacity)
        {
            Debug.LogWarning("Set is full!");
            return;
        }

        if (Contains(item)) return;

        SetArray[currentSize] = item;
        currentSize++;
    }
    public void Remove(T item)
    {
        int index = System.Array.IndexOf(SetArray, item);

        if (index >= 0)
        {
            for (int i = index; i < currentSize - 1; i++)
            {
                SetArray[i] = SetArray[i + 1];
            }
            SetArray[currentSize - 1] = default;
            currentSize--;
        }
    }

    public int Cardinality()
    {
        return currentSize;
    }

    public bool Contains(T item)
    {
        return System.Array.IndexOf(SetArray, item) >= 0;
    }
    public bool IsEmpty()
    {
        return currentSize == 0;
    }

    public void Show()
    {
        if (IsEmpty())
        {
            Debug.Log("Set is empty.");
            return;
        }

        string setContent = "Set contents: ";
        for (int i = 0; i < currentSize; i++)
        {
            setContent += SetArray[i].ToString() + " ";
        }
        Debug.Log(setContent);
    }

    public ISetDatos<T> Union(ISetDatos<T> otherSet)
    {
        var other = otherSet as StaticSet<T>;   
        StaticSet<T> unionSet = new StaticSet<T>(capacity + other.capacity);
        foreach (var item in SetArray)
        {
            if (!unionSet.Contains(item))
            {
                unionSet.Add(item);
            }
        }
        foreach (var item in other.SetArray)
        {
            if (!unionSet.Contains(item))
            {
                unionSet.Add(item);
            }
        }
        return unionSet;
    }

    public ISetDatos<T> Intersect(ISetDatos<T> otherSet)
    {
        var other = otherSet as StaticSet<T>;
        StaticSet<T> intersectSet = new StaticSet<T>(Mathf.Min(capacity, other.capacity));
        foreach (var item in SetArray)
        {
            if (otherSet.Contains(item))
            {
                intersectSet.Add(item);
            }
        }
        return intersectSet;
    }

    public ISetDatos<T> Difference(ISetDatos<T> otherSet)
    {
        var other = otherSet as StaticSet<T>;
        StaticSet<T> differenceSet = new StaticSet<T>(capacity);
        foreach (var item in SetArray)
        {
            if (!other.Contains(item))
            {
                differenceSet.Add(item);
            }
        }
        return differenceSet;
    }
}

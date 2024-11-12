using System.Collections.Generic;
using UnityEngine;


public class DynamicSet<T> : ISetDatos<T>
{
    public List<T> SetList;

    public DynamicSet()
    {
        SetList = new List<T>();
    }

    public void Add(T Item)
    {
        if (SetList.Contains(Item))
        {
            return;
        }
        else
        {
            SetList.Add(Item);
        }
    }

    public void Remove(T Item)
    {
        SetList.Remove(Item);
    }

    public bool Contains(T Item)
    {
        return SetList.Contains(Item);
    }

    public bool IsEmpty()
    {
        return SetList.Count == 0;
    }

    public int Cardinality()
    {
        return SetList.Count;
    }

    public void Show()
    {
        foreach (var item in SetList)
        {
            Debug.Log(item.ToString() + " ");
        }
    }



    //LA FUNCION UNION AGREGA LOS ITEMS DE UN SET A OTRO
    public ISetDatos<T> Union(ISetDatos<T> otherSet)
    {
        var other = otherSet as DynamicSet<T>; //EL AS LO QUE HACE ES QUE EL OBJECTO QUE TIENE LA INTERFAZ SE CONSIDERE UN DYNAMIC SET PARA QUE LA FUNCION SE PUEDA EJECUTAR
        var unionSet = new DynamicSet<T>();

        foreach (var item in SetList)
        {
            unionSet.Add(item);
        }

        foreach (var item in other.SetList)
        {
            unionSet.Add(item);
        }

        return unionSet;
    }


    //LA FUNCION INTERSECT COMPARA LOS DOS SET Y RETORNA UN NUEVO SET CON LO QUE TIENEN EN COMUN
    public ISetDatos<T> Intersect(ISetDatos<T> otherSet)
    {
        var other = otherSet as DynamicSet<T>;
        var intersectionSet = new DynamicSet<T>();

        foreach (var item in SetList)
        {
            if (other.Contains(item))
            {
                intersectionSet.Add(item);
            }
        }

        return intersectionSet;
    }

    //LA FUNCION DIFFERENCE COMPARA LOS DOS SET Y CREA UN SET CON LOS QUE NO COMPARTEN
    public ISetDatos<T> Difference(ISetDatos<T> otherSet)
    {
        var other = otherSet as DynamicSet<T>;
        var differenceSet = new DynamicSet<T>();

        foreach (var item in SetList)
        {
            if (!other.Contains(item))
            {
                differenceSet.Add(item);
            }
        }

        return differenceSet;
    }

}
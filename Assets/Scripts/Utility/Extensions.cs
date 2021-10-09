using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T RandomItem<T>(this IList<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
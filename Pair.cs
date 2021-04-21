using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair<F, S>
{
    public Pair() { }
    public Pair(F first, S second)
    {
        First = first;
        Second = second;
    }

    public F First { get; set; }
    public S Second { get; set; }
    public void SetValue(F first, S second)
    {
        First = first;
        Second = second;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexDegreeComparator : IComparer<VerticeWP>
{
    public int Compare(VerticeWP x, VerticeWP y)
    {
        return x.NumeroFronteiras < y.NumeroFronteiras ? 1 : x.NumeroFronteiras == y.NumeroFronteiras ? 0 : -1;
    }
}

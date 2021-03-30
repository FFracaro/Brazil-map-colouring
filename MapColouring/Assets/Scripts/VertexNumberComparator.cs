using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexNumberComparator
{
    private readonly int NumeroToCompare;

    public VertexNumberComparator(int NumeroEstado)
    {
        NumeroToCompare = NumeroEstado;
    }

    public bool Comparar(VerticeWP vertice)
    {
        return vertice.NumeroEstado == NumeroToCompare;
    }
}
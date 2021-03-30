using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class WelshAndPowell : MonoBehaviour
{
    public VerticeWP[] Graph;
    public Color[] colors;

    public Text Time;

    public void WP()
    {
        Array.Sort(Graph, new VertexDegreeComparator());
        List<int> NumberVerticesColoridos = new List<int>();

        int CorAtual = 0;
        int QtdEstadosColoridos = 0;

        while(true)
        {
           QtdEstadosColoridos = 0;

            for(int i = 0; i < Graph.Length; i++)
            {
                if (!NumberVerticesColoridos.Contains(Graph[i].NumeroEstado))
                {
                    if (!VerifyNeighbors(Graph[i].Edges, CorAtual))
                    {
                        Graph[i].CorEstado = CorAtual;
                        NumberVerticesColoridos.Add(Graph[i].NumeroEstado);
                        QtdEstadosColoridos++;
                    }
                }
                else
                {
                    QtdEstadosColoridos++;
                }
            }

            if (QtdEstadosColoridos == 27)
            {
                break;
            }

            CorAtual++;
        }
    }

    public void WPTimed()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        WP();

        watch.Stop();

        Time.text = "Tempo medido: " + watch.Elapsed.TotalMilliseconds + " ms.";
    }

    private bool DoesVertexContainsThisEdge(VerticeWP[] VertexEdges, VerticeWP EdgeToFind)
    {
        for(int i = 0; i < VertexEdges.Length; i++)
        {
            if (EdgeToFind.NumeroEstado == VertexEdges[i].NumeroEstado)
                return true;
        }
        return false;
    }

    private bool VerifyNeighbors(VerticeWP[] VertexEdges, int ColorNumber)
    {
        for (int i = 0; i < VertexEdges.Length; i++)
        {
            if (VertexEdges[i].CorEstado == ColorNumber)
                return true;
        }
        return false;
    }

    public void SetColorsToMap()
    {
        foreach (VerticeWP v in Graph)
        {
            if (v.CorEstado != -1 && v.CorEstado < 5)
                v.SpriteEstado.color = colors[v.CorEstado];
        }
    }

    public void ResetProblem()
    {
        ShuffleEstados();
        ResetVertices();
    }

    void ShuffleEstados()
    {
        for (int t = 0; t < Graph.Length; t++)
        {
            VerticeWP tmp = Graph[t];
            int r = UnityEngine.Random.Range(t, Graph.Length);
            Graph[t] = Graph[r];
            Graph[r] = tmp;
        }
    }

    void ResetVertices()
    {
        foreach (VerticeWP v in Graph)
        {
            v.CorEstado = -1;
            v.SpriteEstado.color = Color.white;
        }
    }
}





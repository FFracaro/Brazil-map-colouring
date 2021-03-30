using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Backtracking : MonoBehaviour
{
    public List<Vertice> Graph;
    public Color[] colors;
    int[] ColorCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public Text Time;

    public bool BT(int EstadoInicial)
    {
        return ColorirVertices(Graph[EstadoInicial]);
    }

    public void BTTimed(int EstadoInicial)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        bool resultado = BT(EstadoInicial);

        watch.Stop();

        if(resultado)
        {
            //MostrarCoresNoMapa(Graph);

            UnityEngine.Debug.Log("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");
            Time.text = "" + watch.Elapsed.TotalMilliseconds;
        }

    }

    void ResetProblem()
    {
        foreach(Vertice v in Graph)
        {
            v.CorEstado = -1;
            v.SpriteEstado.color = Color.white;
            v.WasVisited = false;
        }
    }

    public bool ColorirVertices(Vertice Vertice)
    {
        bool backtrack = false;

        for (int colorIndex = 0; colorIndex < colors.Length; colorIndex++)
        {
            if (PodeSerColorido(colorIndex, Vertice))
            {
                Vertice.CorEstado = colorIndex;
                Vertice.SpriteEstado.color = colors[colorIndex];
                Vertice.WasVisited = true;
                ColorCount[Vertice.NumeroEstado]++;

                UnityEngine.Debug.Log("Vert: " + Vertice.NomeEstado + " C: " + Vertice.CorEstado);

                if (SumArray(ColorCount) == Graph.Count)
                    return true;

                foreach (Vertice v in Vertice.Edges)
                {
                    if (!v.WasVisited)
                    {
                        if(!ColorirVertices(v))
                        {
                            backtrack = true;
                        }
                    }
                }
            }

            if (!backtrack && AllEdgesWereVisitedAndColored(Vertice))
                return true;

            backtrack = false;
        }

        Vertice.WasVisited = false;
        Vertice.CorEstado = -1;
        Vertice.SpriteEstado.color = Color.white;
        ColorCount[Vertice.NumeroEstado]--;
        return false;
    }

    bool AllEdgesWereVisitedAndColored(Vertice v)
    {
        foreach (Vertice ver in v.Edges)
        {
            if (!ver.WasVisited && (ver.CorEstado == -1))
            {
                return false;
            }
        }
        return true;
    }

    //Function to check whether it is valid to color with color[colorIndex]
    bool PodeSerColorido(int cor, Vertice Vertice)
    {
        foreach (Vertice v in Vertice.Edges)
        {
            if (v.WasVisited && v.CorEstado == cor)
            {
                return false;
            }          
        }
        return true;
    }

    public void MostrarCoresNoMapa(List<Vertice> Graph)
    {
        Vertice TempVertice;

        foreach (Vertice v in Graph)
        {
            TempVertice = v.GetComponent<Vertice>();

            if (TempVertice.CorEstado != -1)
                TempVertice.SpriteEstado.color = colors[TempVertice.CorEstado];
        }
    }

    int SumArray(int[] arr)
    {
        int sum = 0;

        foreach(int n in arr)
        {
            sum += n;
        }

        return sum;
    }
}

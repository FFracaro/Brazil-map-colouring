using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Esta classe é responsável pela colorização dos vértices
///  do grafo que representa o Brasil utilizando uma técnica
///  de busca em profundidade
/// </summary>

public class DepthFirstSearch : MonoBehaviour
{
    public List<Vertice> Graph;
    private Stack<Vertice> PilhaEstados = new Stack<Vertice>();
    public Color[] colors;
    public Text Time;

    public void DFS(int EstadoInicial)
    {
        // Variável temporária para o script de um vértice
        Vertice TempVertice;

        // Variável temporária para o script de um vértice de fronteira
        Vertice TempVerticeFronteira;

        // Vetor utilizado para contabilizar as cores da fronteira de um vértice
        int[] CoresUsadas = { 0, 0, 0, 0, 0 };


        PilhaEstados.Push(Graph[EstadoInicial]);


        while (PilhaEstados.Count > 0)
        {

            TempVertice = PilhaEstados.Pop();

            if (!TempVertice.WasVisited)
            {
                TempVertice.WasVisited = true;
 
                foreach(Vertice v in TempVertice.Edges)
                {
                    TempVerticeFronteira = v.GetComponent<Vertice>();

                    // Verifica a cor do vértice na fronteira
                    if(TempVerticeFronteira.CorEstado != -1)
                    {
                        CoresUsadas[TempVerticeFronteira.CorEstado]++;
                    }

                    PilhaEstados.Push(v);
                }

                /*  Adiciona a cor ao vértice atual baseado nas informações das cores 
                    dos vértices da fronteita */
                TempVertice.CorEstado = SetColorToEstado(CoresUsadas);
                ResetCoresUsadas(CoresUsadas);
            }
        }

    }

    public void DFSTimed(int EstadoInicial)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        DFS(EstadoInicial);

        watch.Stop();

        Time.text = "Tempo medido: " + watch.Elapsed.TotalMilliseconds + " ms.";
    }

    private int SetColorToEstado(int[] Cores)
    {
        for(int i = 0; i < Cores.Length; i++)
        {
            if (Cores[i] == 0)
                return i;
        }
        return -1;
    }

    private void ResetCoresUsadas(int[] Cores)
    {
        for (int i = 0; i < Cores.Length; i++)
        {
            Cores[i] = 0;
        }
    }

    public void SetColorsToMap()
    {
        Vertice TempVertice;

        foreach(Vertice v in Graph)
        {
            TempVertice = v.GetComponent<Vertice>();

            if(TempVertice.CorEstado != -1)
                TempVertice.SpriteEstado.color = colors[TempVertice.CorEstado];
        }
    }

    public void ResetVertices()
    {
        foreach (Vertice v in Graph)
        {
            v.CorEstado = -1;
            v.WasVisited = false;
            v.SpriteEstado.color = Color.white;
        }
    }
}

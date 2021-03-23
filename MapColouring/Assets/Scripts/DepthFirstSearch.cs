using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstSearch : MonoBehaviour
{
    public List<GameObject> Graph;
    private Stack<GameObject> PilhaEstados = new Stack<GameObject>();
    public Color[] colors;

    public void DFS(int EstadoInicial)
    {
        // Variável temporária para um vértice
        GameObject TempVertice;

        // Variável temporária para o script de um vértice
        Vertice TempScriptVertice;

        // Variável temporária para o script de um vértice de fronteira
        Vertice TempScriptVerticeFronteira;

        // Vetor utilizado para contabilizar as cores da fronteira de um vértice
        int[] CoresUsadas = { 0, 0, 0, 0, 0 };


        PilhaEstados.Push(Graph[EstadoInicial]);


        while (PilhaEstados.Count > 0)
        {

            TempVertice = PilhaEstados.Pop();
            TempScriptVertice = TempVertice.GetComponent<Vertice>();

            if (!TempScriptVertice.WasVisited)
            {
                TempScriptVertice.WasVisited = true;
 
                foreach(GameObject vertice in TempScriptVertice.Edges)
                {
                    TempScriptVerticeFronteira = vertice.GetComponent<Vertice>();

                    if(TempScriptVerticeFronteira.CorEstado != -1)
                    {
                        CoresUsadas[TempScriptVerticeFronteira.CorEstado]++;
                    }

                    PilhaEstados.Push(vertice);
                }

                TempScriptVertice.CorEstado = SetColorToEstado(CoresUsadas);
                ResetCoresUsadas(CoresUsadas);
            }
        }

        SetColorToMap(Graph);
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

    public void SetColorToMap(List<GameObject> Graph)
    {
        Vertice TempVertice;

        foreach(GameObject v in Graph)
        {
            TempVertice = v.GetComponent<Vertice>();

            if(TempVertice.CorEstado != -1)
                TempVertice.SpriteEstado.color = colors[TempVertice.CorEstado];
        }
    }
}

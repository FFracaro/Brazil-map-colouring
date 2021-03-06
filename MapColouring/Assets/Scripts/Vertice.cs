using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertice : MonoBehaviour
{
    public int NumeroEstado;
    public string NomeEstado;
    public string SiglaEstado;

    // Variável de referência para o gráfico de um estado
    public SpriteRenderer SpriteEstado;

    public Vertice[] Edges;

    /*  Métodos e variável responsável por guardar
        um número que representa uma cor
        -1 indica que nenhuma cor foi estabelecida */
    public int CorEstado { get; set; } = -1;

    /*  Métodos e variável reponsável por indicar
    se um vértice foi visitado ou não
    durante a execução de um algoritmo */
    public bool WasVisited { get; set; } = false;
}

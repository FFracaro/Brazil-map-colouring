using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticeWP : MonoBehaviour
{
    public int NumeroEstado;
    public string NomeEstado;
    public string SiglaEstado;

    // Variável de referência para o gráfico de um estado
    public SpriteRenderer SpriteEstado;

    public int NumeroFronteiras = 0;

    /*  Métodos e variável responsável por guardar
    um número que representa uma cor
    -1 indica que nenhuma cor foi estabelecida */
    public int CorEstado { get; set; } = -1;

    public VerticeWP[] Edges;

    private void Start()
    {
        NumeroFronteiras = Edges.Length;
    }
}

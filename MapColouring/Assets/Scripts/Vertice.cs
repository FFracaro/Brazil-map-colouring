using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertice : MonoBehaviour
{
    public int NumeroEstado;
    public string NomeEstado;
    public string SiglaEstado;
    public GameObject[] Edges;
    public SpriteRenderer SpriteEstado;
     
    public int CorEstado { get; set; } = -1;
    public bool WasVisited { get; set; } = false;
}

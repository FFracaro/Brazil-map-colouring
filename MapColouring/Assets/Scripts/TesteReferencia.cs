using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteReferencia : MonoBehaviour
{
    public List<GameObject> Grafo;
    private Queue<GameObject> fila = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        Grafo[0].GetComponent<Vertice>().CorEstado = Color.black;

        Grafo[0].gameObject.GetComponent<Vertice>().Edges[0].GetComponent<Vertice>().CorEstado = Color.gray;
        fila.Enqueue(Grafo[0].gameObject.GetComponent<Vertice>().Edges[0]);

        Grafo[0].gameObject.GetComponent<Vertice>().Edges[1].GetComponent<Vertice>().CorEstado = Color.gray;
        fila.Enqueue(Grafo[0].gameObject.GetComponent<Vertice>().Edges[0]);

        Debug.Log("Cor no grafo = " + Grafo[0].gameObject.GetComponent<Vertice>().Edges[0].GetComponent<Vertice>().CorEstado);

        Grafo[0].gameObject.GetComponent<Vertice>().Edges[0].GetComponent<Vertice>().CorEstado = Color.black;

        Debug.Log("Cor no grafo = " + Grafo[0].gameObject.GetComponent<Vertice>().Edges[0].GetComponent<Vertice>().CorEstado);

        GameObject a = fila.Dequeue();

        Debug.Log("Cor na fila = " + a.GetComponent<Vertice>().CorEstado);
        */
    }

}

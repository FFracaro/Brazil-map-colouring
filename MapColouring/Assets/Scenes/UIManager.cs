using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button btnIniciar;
    public Button btnResetar;
    public Button btnVoltar;
    public string SceneName;
    public Text TxtTempo;
    public Dropdown DropdownMenu;

    public void VoltarTelaInicial()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void CallDFSTimed()
    {
        btnIniciar.interactable = false;

        int EstadoInicial = DropdownMenu.value;

        DropdownMenu.interactable = false;

        DepthFirstSearch DFSScript = GetComponent<DepthFirstSearch>();

        DFSScript.DFSTimed(EstadoInicial);

        DFSScript.SetColorsToMap();

        if (!btnResetar.IsInteractable())
        {
            btnResetar.interactable = true;
        }
    }

    public void ResetDFS()
    {
        btnResetar.interactable = false;

        TxtTempo.text = "";

        DepthFirstSearch DFSScript = GetComponent<DepthFirstSearch>();

        DFSScript.ResetVertices();

        if (!btnIniciar.IsInteractable() && !DropdownMenu.IsInteractable())
        {
            btnIniciar.interactable = true;
            DropdownMenu.interactable = true;
        }
    }
}

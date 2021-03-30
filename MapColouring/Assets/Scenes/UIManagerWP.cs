using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerWP : MonoBehaviour
{
    public Button btnIniciar;
    public Button btnResetar;
    public Button btnVoltar;
    public string SceneName;
    public Text TxtTempo;

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

    public void CallWPTimed()
    {
        btnIniciar.interactable = false;

        WelshAndPowell WPScript = GetComponent<WelshAndPowell>();
        WPScript.WPTimed();
        WPScript.SetColorsToMap();

        if (!btnResetar.IsInteractable())
        {
            btnResetar.interactable = true;
        }
    }

    public void ResetWP()
    {
        btnResetar.interactable = false;

        TxtTempo.text = "";

        WelshAndPowell WPScript = GetComponent<WelshAndPowell>();
        WPScript.ResetProblem();

        if (!btnIniciar.IsInteractable())
        {
            btnIniciar.interactable = true;
        }
    }
}

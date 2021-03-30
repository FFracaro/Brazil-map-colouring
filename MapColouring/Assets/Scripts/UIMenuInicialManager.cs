using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuInicialManager : MonoBehaviour
{
    public Dropdown DropdownMenu;
    public string[] NomeSceneAlgoritmos;
    string SceneToLoad;

    public void LoadSceneAlgoritmo()
    {
        int AlgoritmoEscolhido = DropdownMenu.value;

        SceneToLoad = NomeSceneAlgoritmos[AlgoritmoEscolhido];

        if(SceneToLoad != null)
            StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

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
}

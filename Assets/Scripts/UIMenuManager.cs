using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour {

    public void GameLain()
    {
        Application.OpenURL("http://m-edukasi.kemdikbud.go.id/medukasi/?m1=me");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GantiScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}

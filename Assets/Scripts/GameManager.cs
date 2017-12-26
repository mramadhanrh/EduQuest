using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject GameDone, GameOver;

    public int swipeLimit;

    GameObject finnish;


    bool isShow, isOverShow;
	// Use this for initialization
	void Start () {
        Constans.IsGameDone = false;
        Constans.swipeCount = 0;
        finnish = GameObject.Find("Finnish");
        finnish.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Constans.IsGameDone)
        {
            if (!finnish.activeInHierarchy)
            {
                finnish.SetActive(true);
            }
        }

        if (Constans.swipeCount == swipeLimit + 1)
        {
            if (!isOverShow)
            {
                ShowGameOver();
                isOverShow = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetIsAbleToWalk(false);
            }
        }
	}

    public void GotoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetShowGameDone()
    {
        if (!isShow)
        {
            ShowGameDone();
            isShow = true;
            if (GameObject.FindGameObjectWithTag("Player") != null)
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetIsAbleToWalk(false);
        }
    }

    public void GantiScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public int getLimit()
    {
        return swipeLimit;
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }


    public void ShowGameDone()
    {
        GameDone.SetActive(true);
    }


    public void CheckStatus()
    {
        if (IsAllCorrect() && !Constans.IsGameDone)
        {
            Constans.IsGameDone = true;
            Camera.main.GetComponent<Animator>().Play("Camera_GotoMain");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetIsAbleToWalk(true);
        }
    }

    bool IsAllCorrect()
    {
        foreach (GameObject q in GameObject.FindGameObjectsWithTag("Question"))
        {
            if (!q.GetComponent<QuestionScript>().getCorrect())
            {
                return false;
            }
        }
        return true;
    }
}

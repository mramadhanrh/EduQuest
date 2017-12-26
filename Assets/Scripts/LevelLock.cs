using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLock : MonoBehaviour {

    public Sprite Unlock, Lock;

    bool unlock;
	// Use this for initialization
	void Start () {
        if(gameObject.name != "Level1")
            CheckLock();
        else
        {
            GetComponent<Image>().sprite = Unlock;
            unlock = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel()
    {
        Debug.Log(this.name);
        if (unlock)
        {
            SceneManager.LoadScene(this.name);
        }
    }

    public void CheckLock()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            GetComponent<Image>().sprite = Unlock;
            unlock = true;
        }
        else
        {
            GetComponent<Image>().sprite = Lock;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinnishScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GetComponent<Animator>().Play("Finnish_End");
            int y = SceneManager.GetActiveScene().buildIndex - 1;
            PlayerPrefs.SetString("Level" + y, "true");
            PlayerPrefs.Save();
        }
    }
}

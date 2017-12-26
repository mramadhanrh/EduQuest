using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finnish")
        {
            GetComponent<Animator>().Play("Player_Finnish");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetShowGameDone();
        }
    }
}

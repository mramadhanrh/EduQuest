using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour {

    public GameObject[] Questions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        foreach (GameObject Question in Questions)
        {
            Question.transform.FindChild("BoxAnswer").GetComponent<DragScript>().SetPosition();
            Question.transform.FindChild("BoxAnswer").GetComponent<DragScript>().preventDrag = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDragObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "tmpBox")
        {
            if (!col.gameObject.GetComponentInParent<QuestionScript>().isFilled)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    GameObject go = transform.parent.gameObject;
                    go.GetComponent<DragScript>().SetPosition(col.transform.position, col.transform.gameObject);
                }
            }
        }
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    GameObject go = transform.parent.gameObject;
    //    go.GetComponent<DragScript>().SetPosition(col.transform.gameObject);
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour {

    public bool isTouch;

    [Range(0f,1f)]
    public float rayRange;

    RaycastHit2D[] hits = new RaycastHit2D[4];

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        SetRaycast();
        if (getHit())
        {
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
        if (Constans.IsGameDone)
        {
            GetComponent<Animator>().Play("Cell_Open");
        }
	}

    void OnMouseDown()
    {
        if (isTouch && !Constans.IsGameDone)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetIsAbleToWalk(false);
            Camera.main.GetComponent<Animator>().Play("Camera_GotoQuest");
            Constans.swipeCount--;
        }
    }

    bool getHit()
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit)
            {
                return true;
            }
        }
        return false;
    }

    void SetRaycast()
    {
        hits[0] = Physics2D.Raycast(transform.position, new Vector2(1, 0), rayRange, 1 << 9);
        hits[1] = Physics2D.Raycast(transform.position, new Vector2(-1, 0), rayRange, 1 << 9);
        hits[2] = Physics2D.Raycast(transform.position, new Vector2(0, 1), rayRange, 1 << 9);
        hits[3] = Physics2D.Raycast(transform.position, new Vector2(0, -1), rayRange, 1 << 9);
    }
}

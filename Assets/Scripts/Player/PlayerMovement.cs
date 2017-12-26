using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WalkDirection
{
    right,
    left,
    up,
    down,
    none
}

public class PlayerMovement : MonoBehaviour {

    WalkDirection wd;

    [Range(0,10)]
    public float speed;

    [Range(0f, 1f)]
    public float rayRange;

    bool isAbleToWalk;

    RaycastHit2D[] hits = new RaycastHit2D[4];

	// Use this for initialization
	void Start () {
        isAbleToWalk = true;
        wd = WalkDirection.none;
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
	}
	
	// Update is called once per frame
	void Update () {
        if(wd == WalkDirection.none && isAbleToWalk)
            SetSwipe();

        if(isAbleToWalk)
            SetWalk();

        SetRaycast();

        CheckHit();

        SetAnimation();
        
	}

    public void SetIsAbleToWalk(bool value)
    {
        isAbleToWalk = value;
    }

    void SetAnimation()
    {
        if (wd == WalkDirection.none)
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
    }

    void CheckHit()
    {
        if (getHit())
        {
            wd = WalkDirection.none;
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

    void SetAllZeroRayCast()
    {
        hits[0] = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0, 1 << 8);
        hits[1] = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0, 1 << 8);
        hits[2] = Physics2D.Raycast(transform.position, new Vector2(0, 1), 0, 1 << 8);
        hits[3] = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0, 1 << 8);
    }

    void SetRaycast()
    {
        SetAllZeroRayCast();

        if (wd == WalkDirection.right)
        {
            hits[0] = Physics2D.Raycast(transform.position, new Vector2(1, 0), rayRange, 1 << 8);
        }
        else if (wd == WalkDirection.left)
        {
            hits[1] = Physics2D.Raycast(transform.position, new Vector2(-1, 0), rayRange, 1 << 8);
        }
        else if (wd == WalkDirection.up)
        {
            hits[2] = Physics2D.Raycast(transform.position, new Vector2(0, 1), rayRange, 1 << 8);
        }
        else if (wd == WalkDirection.down)
        {
            hits[3] = Physics2D.Raycast(transform.position, new Vector2(0, -1), rayRange, 1 << 8);
        }
    }

    void SetWalk()
    {
        if (wd == WalkDirection.right)
        {
            transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
        }
        else if (wd == WalkDirection.left)
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
        else if (wd == WalkDirection.up)
        {
            transform.Translate(new Vector2(0, 1) * Time.deltaTime * speed);
        }
        else if (wd == WalkDirection.down)
        {
            transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(new Vector2(0, 0));
        }
    }

    void SetSwipe()
    {
        if (Swipe.Instance.IsSwiping(SwipeDirection.Right))
        {
            wd = WalkDirection.right;
            Constans.swipeCount++;
        }
        else if (Swipe.Instance.IsSwiping(SwipeDirection.Left))
        {
            wd = WalkDirection.left;
            Constans.swipeCount++;
        }
        else if (Swipe.Instance.IsSwiping(SwipeDirection.Up))
        {
            wd = WalkDirection.up;
            Constans.swipeCount++;
        }
        else if (Swipe.Instance.IsSwiping(SwipeDirection.Down))
        {
            wd = WalkDirection.down;
            Constans.swipeCount++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragScript : MonoBehaviour {

    public float value;

    public GameObject boxTempCompare;

    public GameObject t;

    bool isDragging;

    public bool preventDrag {get; set;}

    GameObject g;
    Vector3 z;

    Vector3 tmpPosition, startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Break();

        if (isDragging)
        {
            z = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));            
            z.z = 0;
            g.transform.position = z;
        }
	}

    void OnMouseDown()
    {
        if (!preventDrag)
        {
            isDragging = true;
            AddGameObject();
        }
    }

    void AddGameObject()
    {
        g = new GameObject("go");
        GameObject T = Instantiate(t, g.transform.position, Quaternion.identity);
        //T.transform.parent = g.transform;
        T.transform.SetParent(g.transform);
        T.GetComponentInChildren<TextMeshProUGUI>().SetText(transform.parent.GetComponent<QuestionScript>().answer.ToString());
        T.GetComponentInChildren<TextMeshProUGUI>().color = new Color(T.GetComponentInChildren<TextMeshProUGUI>().color.r, T.GetComponentInChildren<TextMeshProUGUI>().color.g, T.GetComponentInChildren<TextMeshProUGUI>().color.b, 0.5f);
        g.transform.parent = this.transform;
        g.transform.localScale = Vector3.one;
        g.AddComponent<TriggerDragObject>();
        g.AddComponent<BoxCollider2D>();
        g.GetComponent<BoxCollider2D>().isTrigger = true;
        g.GetComponent<BoxCollider2D>().size = new Vector2(4.03f, 4.03f);
        g.AddComponent<SpriteRenderer>();
        g.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        g.GetComponent<SpriteRenderer>().color = new Color(g.GetComponent<SpriteRenderer>().color.r, g.GetComponent<SpriteRenderer>().color.g, g.GetComponent<SpriteRenderer>().color.b, 0.5f);
    }

    void OnMouseUp()
    {
        if (tmpPosition != Vector3.zero)
            transform.position = tmpPosition;
        Destroy(g.gameObject);
        isDragging = false;
    }


    public void SetPosition(Vector3 value, GameObject tmp)
    {
        tmpPosition = value;
        tmpPosition.z = -1;
        Debug.Log("ASUP");
        boxTempCompare = tmp;
        GameObject gm = GameObject.Find("GameManager");
        Debug.Log(transform.parent.GetComponent<QuestionScript>().getAnswer() + " " + tmp.GetComponentInParent<QuestionScript>().getAnswer());
        if (transform.parent.GetComponent<QuestionScript>().getAnswer() == tmp.GetComponentInParent<QuestionScript>().getAnswer())
        {
            tmp.GetComponentInParent<QuestionScript>().SetCorrect(true);
        }
        tmp.GetComponentInParent<QuestionScript>().SetFilled(true);
        gm.GetComponent<GameManager>().CheckStatus();
        preventDrag = true;
    }

    public void SetPosition()
    {
        tmpPosition = Vector3.zero;
        transform.position = startPosition;
        boxTempCompare = null;
        GetComponentInParent<QuestionScript>().SetFilled(false);
        GetComponentInParent<QuestionScript>().SetCorrect(false);
    }

}

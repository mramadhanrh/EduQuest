using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISwipe : MonoBehaviour {

    int swipeLimit;

	// Use this for initialization
	void Start () {
        swipeLimit = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getLimit();
	}
	
	// Update is called once per frame
	void Update () {
        if (Constans.swipeCount <= swipeLimit)
        {
            GetComponent<TextMeshProUGUI>().SetText((swipeLimit - Constans.swipeCount).ToString() + " Swipe Left");
        }
        Debug.Log(Constans.swipeCount);
	}
}

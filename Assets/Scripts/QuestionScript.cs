using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum JenisSoal
{
    Perkalian,
    Pembagian,
    Pertambahan,
    Pengurangan
}

public class QuestionScript : MonoBehaviour {

    public GameObject QuestionCanvas;
    public GameObject BoxTemp;
    public GameObject Answer;

    GameObject Comparer;

    public float answer;
    string question;

    bool isCorrect;
    public bool isFilled;
    public JenisSoal jenisSoal;

	// Use this for initialization
	void Start () {
        SetQuestion();
        QuestionCanvas.GetComponentInChildren<TextMeshProUGUI>().SetText(question);
        Answer.GetComponentInChildren<TextMeshProUGUI>().SetText(answer.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getComparer()
    {
        return Comparer;
    }

    public void SetComparer(GameObject val)
    {
        Comparer = val;
    }

    public bool getCorrect()
    {
        return isCorrect;
    }

    public void SetFilled(bool val)
    {
        isFilled = val;
    }

    public void SetCorrect(bool val)
    {
        isCorrect = val;
    }

    public float getAnswer()
    {
        return answer;
    }

    public GameObject getBoxTemp()
    {
        return BoxTemp;
    }

    void SetQuestion()
    {
        int x = Random.Range(0, 10);
        int y = Random.Range(0, 10);

        switch (jenisSoal)
        {
            case JenisSoal.Perkalian:
                SetPerkalian(x, y);
                break;
            case JenisSoal.Pembagian:
                SetPembagian(x);
                break;
            case JenisSoal.Pertambahan:
                SetPertambahan(x, y);
                break;
            case JenisSoal.Pengurangan:
                SetPengurangan(x, y);
                break;
        }
    }

    void SetPembagian(int x)
    {
        int y;
        
        if(x % 3 == 0)
        {
            y = 3;
        }
        else if(x % 2 == 0)
        {
            y = 2;
        }
        else
        {
            y = 1;
        }

        answer = x / y;
        question = x.ToString() + " : " + y.ToString();

    }

    void SetPertambahan(int x, int y)
    {
        answer = x + y;
        question = x.ToString() + " + " + y.ToString();
    }

    void SetPengurangan(int x, int y)
    {
        answer = x - y;
        question = x.ToString() + " - " + y.ToString();
    }

    void SetPerkalian(int x, int y)
    {
        answer = x * y;
        question = x.ToString() + " x " + y.ToString();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text text;

	void Start ()
	{
	    text = GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<Text>();
	}
	
	void Update () {
	    if (text)
	    {
	        text.text = "Score: " + score;
	    }
	}
}

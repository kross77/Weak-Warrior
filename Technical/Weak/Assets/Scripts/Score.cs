using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text text;
	// Use this for initialization
	void Start ()
	{
	    text = GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (text)
	    {
	        text.text = "Score: " + score;
	    }
	}
}

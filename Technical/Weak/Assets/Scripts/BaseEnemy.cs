using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {
    public int Speed;
    public int Health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void Flip()
    {
        var theScale = gameObject.transform.localScale;
        theScale.x = theScale.x * -1;
        gameObject.transform.localScale = theScale;
    }
}

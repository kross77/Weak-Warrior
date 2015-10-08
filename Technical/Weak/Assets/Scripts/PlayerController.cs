using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int Health = 3;
    public bool FacingRight = true;
    public bool IsHit = false;
    public bool IsHurt = false;
    public float ImmortalTime = 0;
    public float FrezeTime = 0f;
    private Animator _anim;
	// Use this for initialization
	void Start () {
	    _anim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	    if (FrezeTime > 0)
	    {
	        FrezeTime -= Time.deltaTime;
	    }
	    if (ImmortalTime > 0)
	    {
	        ImmortalTime -= Time.deltaTime;
	    }
	    if (FrezeTime < 0.2f)
	    {
            _anim.SetBool("isMissed", false);
	    }
	}

    public void Flip()
    {
        var theScalse = gameObject.transform.localScale;
        theScalse.x = theScalse.x*-1;
        gameObject.transform.localScale = theScalse;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !IsHit)
        {
            IsHit = true;
        }
        else if(other.tag == "Ground")
        {
            if (!IsHit)
            {
                gameObject.GetComponent<Animator>().SetBool("isMissed", true);
                gameObject.GetComponent<Animator>().SetTrigger("isMiss");
                FrezeTime = 0.6f;
            }
            else
            {
                IsHit = false;
            }
        }
    }

    public void Hurt()
    {
        if (ImmortalTime <= 0)
        {
            Health--;
            ImmortalTime = 1f;
        }
        if (Health < 0)
        {
            Restart();

            Destroy(gameObject);
        }
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Debug.Log("restart");
    }
}

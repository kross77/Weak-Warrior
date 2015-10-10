using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public int health = 3;
    public bool facingRight = true;
    //public bool IsHit = false;
    public bool isHurt = false;
    public float immortalTime = 0;
    public float frezeTime = 0f;
    public bool flipable = true;
    private Animator _anim;
    public List<BaseEnemy> enemy; 
	// Use this for initialization
	void Start () {
	    _anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (frezeTime > 0)
	    {
	        frezeTime -= Time.deltaTime;
	    }
	    if (immortalTime > 0)
	    {
	        immortalTime -= Time.deltaTime;
	    }
	    if (frezeTime < 0.2f)
	    {
            _anim.SetBool("isMissed", false);
	    }
	}

    public void Flip()
    {
            var theScalse = gameObject.transform.localScale;
            theScalse.x = theScalse.x * -1;
            gameObject.transform.localScale = theScalse;
            facingRight = !facingRight;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    public void Hurt()
    {
        if (immortalTime <= 0)
        {
            health--;
            immortalTime = 1f;
        }
        if (health < 0)
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

    void Clear()
    {
        if (enemy.Count == 0)
        {
            _anim.SetBool("isMissed", true);
            _anim.SetTrigger("isMiss");
            frezeTime = 0.7f;
        }
        else
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if(enemy[i])
                    if (enemy[i].health <= 0)
                    {

                        enemy[i].isDead = true;
                        enemy[i].GetComponent<Animator>().SetTrigger("isDead");
                        Debug.Log("die");
                    }
            }
        }
        enemy.Clear();
    }
}

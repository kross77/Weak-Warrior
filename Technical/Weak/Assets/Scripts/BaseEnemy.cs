using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseEnemy : MonoBehaviour {
    public float speed;
    public int health;
    public bool isMoving = true;
    public bool isDead = false;
    public float dieTime = 1f;

    public Animator _anim;
    //public bool isRight = false;

	// Use this for initialization
	void Start ()
	{
	        
	}
	    
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Flip(bool isRight)
    {
        speed = Random.Range(1f, 4f);
        if (isRight)
        {
            speed *= -1;
            var theScale = gameObject.transform.localScale;
            theScale.x = theScale.x*-1;
            gameObject.transform.localScale = theScale;
        }

    }

    public virtual void Move()
    {
    }

    public virtual void Attack()
    {
        isMoving = false;
        _anim.SetTrigger("isAttack");

        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public virtual void Die()
    {
        if (isDead)
        {
            dieTime -= Time.deltaTime;
        }
        if (dieTime <= 0)
        {
            Destroy(gameObject);
            Debug.Log("destroy");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Attack();
        }
        if (other.tag == "Sword")
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            Attacked(player);
        }

        if (other.tag == "HitBox")
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            Hit(player);
        }
    }

    public virtual void Hit(PlayerController player)
    {
        if (player)
        {
            player.Hurt();
        }
    }

    public virtual void Attacked(PlayerController other)
    {
        health--;
        other.GetComponentInParent<PlayerController>().enemy.Add(gameObject.GetComponent<BaseEnemy>());
    }
}

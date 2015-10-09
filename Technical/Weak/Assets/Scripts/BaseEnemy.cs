using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseEnemy : MonoBehaviour {
    public float speed;
    public int health;

    public bool isDead = false;
    public float dieTime = 1f;

    public Animator _anim;

	// Use this for initialization
	void Start ()
	{
	        
	}
	    
	// Update is called once per frame
	void Update () {
	
	}

    protected void Flip()
    {
        var theScale = gameObject.transform.localScale;
        theScale.x = theScale.x * -1;
        gameObject.transform.localScale = theScale;
        speed = speed*-1;
        //gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
    }

    public virtual void Move()
    {
        gameObject.transform.position += new Vector3(speed, 0) * Time.deltaTime;
    }

    public virtual void Attack()
    {
        speed = 0;
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
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Attack();
        }

        if (other.tag == "Ground")
        {
            Flip();
        }

        if (other.tag == "Sword")
        {
            other.GetComponentInParent<PlayerController>().enemy.Add(gameObject.GetComponent<Enemy>());
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
}

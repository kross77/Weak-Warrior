using UnityEngine;
using System.Collections;

public class Enemy : BaseEnemy
{
    public bool IsDead = false;
    public float DieTime = 1f;
    void Update()
    {
        if (IsDead)
        {
            DieTime -= Time.deltaTime;
        }
        if (DieTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetTrigger("isAttack");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        
        if (other.tag == "Ground")
        {
            Flip();
            gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
        }

        if (other.tag == "Sword")
        {
            gameObject.GetComponent<Animator>().SetTrigger("isDead");
            IsDead = true;
        }

        if (other.tag == "HitBox")
        {
            Debug.Log("hitbox");
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player)
            {
                player.Hurt();
            }
        }
    }


}

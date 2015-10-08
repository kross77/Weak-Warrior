using UnityEngine;
using System.Collections;

public class Enemy : BaseEnemy 
{

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
            Destroy(gameObject);
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

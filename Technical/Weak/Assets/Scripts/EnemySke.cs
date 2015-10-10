using UnityEngine;
using System.Collections;

public class EnemySke : BaseEnemy 
{
    private float lastSpeed;
	// Use this for initialization
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        //speed = Random.Range(1f, 3f);
        health = 2;
    }
	
	// Update is called once per frame
	void Update () {
        Die();
        Move();
	}


    public override void Move()
    {
        if(isMoving)
            gameObject.transform.position += new Vector3(speed, 0) * Time.deltaTime;

    }
    public override void Attacked(PlayerController other)
    {
        
        base.Attacked(other);

        if (health > 0)
        {
            _anim.SetTrigger("isIdle");
            KnockBack();
        }
        else
        {
            _anim.SetTrigger("isDead");
        }
    }

    public override void Attack()
    {
        Debug.Log(lastSpeed);
        base.Attack();
    }

    void KnockBack()
    {
        lastSpeed = speed;

        isMoving = true;
        Debug.Log("speed trc:" + speed);
        if (speed > 0)
        {
            speed = lastSpeed / lastSpeed * -4f;

        }
        else
        {
            speed = lastSpeed / -lastSpeed * -4f;
            
        }
        Debug.Log("speed:" + speed);
    }

    void Idle()
    {
        speed = 0;
    }

    void Recorvery()
    {
        speed = lastSpeed;
    }

    public override void Flip(bool isRight)
    {
        base.Flip(isRight);
    }
}

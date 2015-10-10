using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : BaseEnemy
{
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        
        health = 1;
    }
    void Update()
    {
        Die();
        Move();
    }

    public override void Move()
    {
        if (isMoving)
            gameObject.transform.position += new Vector3(speed, 0) * Time.deltaTime;
    }

    public override void Flip(bool isRight)
    {
        base.Flip(isRight);
    }
}

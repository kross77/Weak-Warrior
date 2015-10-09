using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : BaseEnemy
{
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        speed = Random.Range(1f, 4f);
        health = 1;
    }
    void Update()
    {
        Die();
        Move();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("attack");
    }
}

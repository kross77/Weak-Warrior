using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _player;
    public Image cooldown;
    public float time = 10f;
    void Start()
    {
        _animator = GameObject.Find("Player").GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        

    }

    void Update()
    {
        CooldownSkill();
    }

	public void Left()
    {
	    if (_player.frezeTime <= 0 && _player.flipable)
	    {
            _animator.SetTrigger("isAttack"); 
            if (_player.facingRight)
            {
                _player.Flip();
            }
                
	    }  
    }

    public void Right()
    {
        if (_player.frezeTime <= 0 && _player.flipable)
        {
            _animator.SetTrigger("isAttack");
            if (!_player.facingRight)
            {
                _player.Flip();
            }
            
        }
    }
    [ContextMenu("skill")]
    public void Skill()
    {
        ResetCooldown();
        _animator.SetTrigger("useSkill");
    }

    public void CooldownSkill()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            cooldown.fillAmount -= Time.deltaTime/10;
        }
        else
        {
            cooldown.enabled = false;
        }
    }

    public void ResetCooldown()
    {
        time = 10f;
        cooldown.fillAmount = 1;
        cooldown.enabled = true;
    }
}

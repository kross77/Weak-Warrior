using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _player;
    void Start()
    {
        _animator = GameObject.Find("Player").GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();

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
}

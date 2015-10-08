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
	    if (_player.FrezeTime <= 0 && _player.Flipable)
	    {
            _animator.SetTrigger("isAttack"); 
            if (_player.FacingRight)
            {
                if (_player.Flipable)
                {
                    _player.Flip();
                }
            }
                
	    }  
    }

    public void Right()
    {
        if (_player.FrezeTime <= 0 && _player.Flipable)
        {
            _animator.SetTrigger("isAttack");
            if (!_player.FacingRight)
            {
                if (_player.Flipable)
                {
                    _player.Flip();
                }
            }
            
        }
    }
}

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
	    if (_player.FrezeTime <= 0)
	    {
            if (_player.FacingRight)
            {
                _player.FacingRight = !_player.FacingRight;
                _player.Flip();
            }
            _animator.SetTrigger("isAttack");     
	    }  
    }

    public void Right()
    {
        if (_player.FrezeTime <= 0)
        {
            if (!_player.FacingRight)
            {
                _player.FacingRight = !_player.FacingRight;
                _player.Flip();
            }
            _animator.SetTrigger("isAttack");
        }
    }
}

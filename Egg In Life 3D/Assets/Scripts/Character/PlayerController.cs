using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0;
    }
    private void Update()
    {
        if (UIManager.Instance.animatorTime.normalizedValue > .5f)
        {
            _animator.Play("Dancing", -1, UIManager.Instance.animatorTime.normalizedValue * 2);
        }
        else
        {
            _animator.Play("Dance", -1, UIManager.Instance.animatorTime.normalizedValue * 2);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private Animator _animator;
    public string animationName;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0;
    }
    private void Update()
    {

        _animator.Play(animationName, 0, UIManager.Instance.animatorTime.normalizedValue );




    }
}

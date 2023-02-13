using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PLayerAnimation : MonoBehaviour
{
    private const string IS_Walking = "IsWalking";
    private PlayerMovement _player;
    private Animator _animator;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _animator = GetComponent<Animator>();      
    }

    private void Update()
    {
        _animator.SetBool(IS_Walking,_player.IsWalking());       
    }


}

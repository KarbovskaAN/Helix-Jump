using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class JumpBall : MonoBehaviour
{
    private Animator _animator;
    
    private float _jumpForce = 4.5f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent( out PlatformSegment2 platformSegment))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpForce ,ForceMode.Impulse);
        }
    }
}

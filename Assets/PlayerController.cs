using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float moveSpeed;
    public float jumpForce;
    public Vector2 input;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Moverse
        input = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = input;

        //Saltar
        if (Input.GetButtonDown("Jump"))
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }

}   
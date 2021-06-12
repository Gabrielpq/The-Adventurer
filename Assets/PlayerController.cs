using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    //Movement
    private Rigidbody2D _rigidbody;
    
    private Vector2 input;
    public float moveSpeed;
    private int direction = 0;

    //Jump
    public float jumpForce;

    //GroundCheck
    public Transform groundCheckPoint;
    public float radius;
    public LayerMask whatIsGround;
    private bool isGrounded = false;

    //Respawn
    private Vector3 resetPos;

    //Shooting
    public GameObject bullet; //Aquí vamos a añadir el prefab que se va a clonar al disparar
    public Transform shootPos;

    //
    public BulletManager bulletManager;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        bulletManager = GetComponent<BulletManager>();
        bulletManager.Init();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidbody.velocity.y);
        if (input.x > 0)
            direction = 1;
        else if (input.x < 0)
            direction = -1;


        _rigidbody.velocity = input;
        FlipSprite();

        GroundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButton("Fire1")) 
        {
            if (bulletManager.CanShoot()) 
            {
                ShootBullet();
            }
        }
    }

    void ShootBullet() 
    {
         GameObject tempBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
         tempBullet.GetComponent<Bullet>().Shoot(direction);
         bulletManager.ShootBullet();
    }

    void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatIsGround);
    }
    void FlipSprite()
    {
        //By rotations
        transform.eulerAngles = new Vector3(0, direction == 1 ? 0 : 180, 0);
    }


}   
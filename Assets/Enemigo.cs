using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rigidbody;
    public int direction = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        FlipSprite();
    }

    void Update()
    {
        _rigidbody.velocity = new Vector2(direction * moveSpeed, _rigidbody.velocity.y);
    }

    void FlipSprite()
    {
        transform.eulerAngles = new Vector3(0, direction == 1 ? 180 : 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pared"))
        {
            direction *= -1;
            FlipSprite();
        }
    }

}

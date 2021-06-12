using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    //para asignar la velocidad de la bala
        public float bulletSpeed;

    void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

   public void Shoot(int _direction)
    {
        _rigidbody.velocity = Vector2.right * _direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared")) 
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharge_Bullet_Item : MonoBehaviour
{ 
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {
             collision.GetComponent<PlayerController>().bulletManager.RechargeBullet();
             Destroy(this.gameObject);
         } 
     }
}

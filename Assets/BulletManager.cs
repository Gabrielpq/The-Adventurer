using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public int maxBulletAmount; //20
    public int currentBulletAmount; //0
    public TextMeshProUGUI bulletText;

    public void Init()
    {
        currentBulletAmount = maxBulletAmount;
        UpdateBulletText();
        //Antes era 0
        //Ahora es 20
    }

    public void ShootBullet()
    {
        currentBulletAmount = Mathf.Clamp(currentBulletAmount - 1, 0, maxBulletAmount);
        UpdateBulletText();
    }

    //Ejemplo
    //Añadir 10 balas cada que se usa esta función
    //Max = 20
    //Current = 11
    //Añades 10 balas, deberías tener 21, pero lo estamos dejando en una cantidad máxima de balas
    //Por lo que va a quedar en 20
    public void RechargeBullet() 
    {
        currentBulletAmount = Mathf.Clamp(currentBulletAmount + 10, 0, maxBulletAmount);
        UpdateBulletText();
    }

    void UpdateBulletText()
    {
        bulletText.text = "x " + currentBulletAmount;
    }

    public bool CanShoot()
    {
        return currentBulletAmount > 0;
    }
}

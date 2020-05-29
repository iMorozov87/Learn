using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int _numbersOfBullets = 10;

    public override void Shoot(Transform shootPoint)
    {
        int minAngle = -30;
        int maxAngle = 30;
        float steepChangedAngle = (float)(maxAngle - minAngle) / _numbersOfBullets;
        float currentAngle = maxAngle;

        for (int i = 0; i < _numbersOfBullets; i++)
        {
            Bullet newBullet = Instantiate(Bullet, shootPoint.position, Quaternion.Euler(0, 0, currentAngle));
            currentAngle -= steepChangedAngle;
        }
    }
}

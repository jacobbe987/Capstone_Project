using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponBase
{
    public override void Shoot()
    {
        if (Input.GetMouseButton(0) && CanShoot())
        {
            ShootBullet(_bulletSpawnPos.forward);
            SetNextShot();
        }
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon Data")]
public class SO_WeaponData : ScriptableObject
{
    public Bullet _bulletPrefab;
    public float _bulletSpeed;
    public float _rof;
}

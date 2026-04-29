using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "EnemySettings")]
public class SO_Enemies : ScriptableObject
{
    public float _triggerDistance;
    public float _speed;
    public float _attackSpeed;
    public int _damage;
}

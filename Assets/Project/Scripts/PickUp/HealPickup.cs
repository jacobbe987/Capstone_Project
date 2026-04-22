using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : OnPickEffects
{
    [SerializeField] private int _valueToHeal;

    public override void OnPick(GameObject player)
    {

        var _lifeController = player.GetComponent<LifeController>();
        if (_lifeController != null)
        {
            _lifeController.AddHp(_valueToHeal);
        }
    }
}

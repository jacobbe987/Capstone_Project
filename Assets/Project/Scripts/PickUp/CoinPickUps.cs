using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUps : OnPickEffects
{
    [SerializeField] private int _coinValue;

    public override void OnPick(GameObject player)
    {
        
        var _itemCollected = player.GetComponent<ItemsController>();
        if (_itemCollected != null)
        {
            _itemCollected.AddCoins(_coinValue);
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private OnPickEffects _onPick;

    private void Awake()
    {
        _onPick = GetComponent<OnPickEffects>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        if (_onPick != null)
            _onPick.OnPick(other.gameObject);
        Destroy(gameObject);
    }
}

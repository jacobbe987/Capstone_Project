using UnityEngine;
using UnityEngine.Events;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private int _coinsAmount=0;
    [SerializeField] private UnityEvent<int> _onChangeCoin;

    public int Coins => _coinsAmount;

    public void AddCoins(int amount)
    {
        _coinsAmount += amount;
        _onChangeCoin.Invoke(_coinsAmount);
    }
}

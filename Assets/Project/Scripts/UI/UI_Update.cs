using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Image _fillableLifebar;

    public void DisplayCoin(int coin)
    {
        _coinText.text = $"Coin: {coin.ToString()}/3";
    }
    public void DisplayLife(float percentageLife)
    {
        _fillableLifebar.fillAmount = Mathf.Clamp01(percentageLife);
    }
}

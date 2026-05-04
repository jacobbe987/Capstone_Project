using UnityEngine;

public class UI_GameStatus : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ItemsController _itemsController;
    [SerializeField] private UI_Update _uiUpdate;

    public void UpdateLifebar(int hp, int maxHp)
    {
        float percentageLife = (float)hp / maxHp;
        _uiUpdate.DisplayLife(percentageLife);
    }

    public void UpdateCoins(int coin)
    {
        _uiUpdate.DisplayCoin(coin);
    }

    private void OnEnable()
    {
        UpdateLifebar(_gameManager.LifeController.Hp, _gameManager.LifeController.Maxhp);
        UpdateCoins(_itemsController.Coins);
    }
}

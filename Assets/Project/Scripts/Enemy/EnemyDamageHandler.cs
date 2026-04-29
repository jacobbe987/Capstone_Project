using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private LifeController _lifeController;
    [SerializeField] private int coinValue;

    private void Awake()
    {
        if (_lifeController == null)
            _lifeController = GetComponent<LifeController>();
    }

    private void OnEnable()
    {
        if (_lifeController != null)
            _lifeController.ResetLife();

        GetComponent<Collider>().enabled = true;
    }

    public void HandleDamage()
    {
        if (SoundFxManager._instance != null)
            SoundFxManager._instance.PlayFxSound("BulletImpact");
    }

    public void HandleDeath()
    {
        //inventory.AddCoin(coinValue);

        if (SoundFxManager._instance != null)
            SoundFxManager._instance.PlayFxSound("EnemyDeath");
    }
}
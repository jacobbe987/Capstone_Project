using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private LifeController _lifeController;

    private void Awake()
    {
        if (_lifeController == null)
            _lifeController = GetComponent<LifeController>();
    }

    public void HandleDamage()
    {
        if (SoundFxManager._instance != null)
            SoundFxManager._instance.PlayFxSound("BulletImpact");
    }

    public void HandleDeath()
    {

        if (SoundFxManager._instance != null)
            SoundFxManager._instance.PlayFxSound("EnemyDeath");
    }
}
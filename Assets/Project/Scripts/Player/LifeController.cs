using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, int> _onChangeHp;
    [SerializeField] private int _hp, _maxHp;
    private bool _isDead = false;

    public int Hp { get => _hp; set => SetHp(value); }
    public int Maxhp { get => _maxHp; set => SetMaxHp(value); }

    private void SetHp(int hp)
    {
        hp=Mathf.Clamp(hp, 0, _maxHp);

        if (hp != _hp)
        {
            _hp=hp;
        }
        _onChangeHp.Invoke(_hp, _maxHp);
    }

    private void SetMaxHp(int maxhp)
    {
        _maxHp=maxhp;
    }

    public void RemoveHp(int dmg)
    {
        if (_isDead) return;
        //SoundFxManager._instance.PlayFxSound("PlayerHit");
        SetHp(_hp - dmg);

        if(_hp <= 0)
        {
            _isDead = true;
            Destroy(gameObject);
            
        }
    }

    public void AddHp(int hpAmount)
    {
        SetHp(_hp + hpAmount);

    }

    public void ResetLife()
    {
        _isDead = false;
        SetHp(Maxhp);
    }

    [ContextMenu("inflict 20 dmg")]
    public void Inflict20Dmg()
    {
        RemoveHp(20);
    }
}

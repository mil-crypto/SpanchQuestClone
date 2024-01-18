using UnityEngine;

public class IceMage : Mage
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _blizzardSlowKoef;

    public void Init(int healt, float damageValue, float attackRadius, float blizzardSlowKoef)
    {
        Init(healt, damageValue);
        _attackRadius = attackRadius;
        _blizzardSlowKoef = blizzardSlowKoef;
    }
    public override void CastSpell()
    {
        Debug.Log("Casting blizzard");
    }
}

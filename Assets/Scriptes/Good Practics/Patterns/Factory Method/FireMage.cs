
using UnityEngine;

public class FireMage : Mage
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _fireBallRadius;

    public void Init(int healt, float damageValue, float attackRadius,float fireBallRadius)
    {
        Init(healt, damageValue);
        _attackRadius = attackRadius;
        _fireBallRadius = fireBallRadius;
    }
    public override void CastSpell()
    {
        Debug.Log("Casting fireball");
    }
}

using UnityEngine;

public abstract class Mage : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _attackValue;
    protected void Init(int health,float attackValue)
    {
        _health = health;
        _attackValue = attackValue;
    }

    public abstract void CastSpell();
}

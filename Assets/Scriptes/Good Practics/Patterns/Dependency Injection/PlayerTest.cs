

public class PlayerTest  // Client
{
    private IDamageCalculator _damageCalculator;
    public void Inject(IDamageCalculator damageCalculator)
    {
        _damageCalculator = damageCalculator;
    }
    public void Attack(Enemy enemy)
    {
        float damage = _damageCalculator.CalculateDamage();
        enemy.TakeDamage(damage);
    }
}

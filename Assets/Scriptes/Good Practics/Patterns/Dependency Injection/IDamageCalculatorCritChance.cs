public class IDamageCalculatorCritChance : IDamageCalculator
{
    private Weapon weapon;

    public IDamageCalculatorCritChance(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public float CalculateDamage()
    {
        throw new System.NotImplementedException();
    }
}
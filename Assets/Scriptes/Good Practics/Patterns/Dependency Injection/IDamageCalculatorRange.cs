public class IDamageCalculatorRange : IDamageCalculator
{
    private Weapon weapon;

    public IDamageCalculatorRange(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public float CalculateDamage()
    {
        throw new System.NotImplementedException();
    }
}
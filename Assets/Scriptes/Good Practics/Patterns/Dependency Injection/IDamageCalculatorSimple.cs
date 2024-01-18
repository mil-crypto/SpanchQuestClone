public class IDamageCalculatorSimple : IDamageCalculator
{
    private Weapon weapon;
    public IDamageCalculatorSimple Simple;

    public IDamageCalculatorSimple(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public float CalculateDamage()
    {
        throw new System.NotImplementedException();
    }
}
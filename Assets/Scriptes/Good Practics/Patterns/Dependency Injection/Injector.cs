public class Injector
{
    private PlayerTest _playerTest;
    private Weapon _weapon;
    public void Init(CalculatorType calculatorType)
    {
        IDamageCalculator calculator;
        /*switch (calculatorType)
        {
            case calculatorType.Simple:
                calculator = new IDamageCalculatorSimple(_weapon);
                break;
            case CalculatorType.Range:
                calculator = new IDamageCalculatorRange(_weapon);
                break;
            case CalculatorType.Crit:
                calculator = new IDamageCalculatorCritChance(_weapon);
                break;
            default:
                calculator = new IDamageCalculatorSimple(_weapon);
                break;
            
        }
        _playerTest.Inject(calculator);  
        */
    }
}
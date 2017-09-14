
public class PrimitiveCalculator
{
    private ICalculationalable additionValue;
    private ICalculationalable additionStrategy;
    private ICalculationalable subtractionStrategy;
    private ICalculationalable multiplyStrategy;
    private ICalculationalable divideStrategy;

    public PrimitiveCalculator(AdditionStrategy additionStrategy, SubtractionStrategy subtractionStrategy,
        MultiplyStrategy multiplyStrategy, DivideStrategy divideStrategy)
    {
        this.additionStrategy = additionStrategy;
        this.subtractionStrategy = subtractionStrategy;
        this.multiplyStrategy = multiplyStrategy;
        this.divideStrategy = divideStrategy;
        this.additionValue = additionStrategy;

    }

    public void ChangeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                this.additionValue = this.additionStrategy;
                break;
            case '-':
                this.additionValue = this.subtractionStrategy;
                break;
            case '*':
                this.additionValue = this.multiplyStrategy;
                break;
            case '/':
                this.additionValue = this.divideStrategy;
                break;
        }
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.additionValue.Calculate(firstOperand, secondOperand);
    }
}
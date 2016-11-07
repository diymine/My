using Service.Contracts;

namespace Services
{
    public class CalculatorService:ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}

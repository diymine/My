using System.ServiceModel;

namespace Service.Contracts
{
    [ServiceContract(Name = "CalculatorService", Namespace = "http://www.artech.com/")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);


    }
}


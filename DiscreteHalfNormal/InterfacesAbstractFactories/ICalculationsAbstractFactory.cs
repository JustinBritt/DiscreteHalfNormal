namespace DiscreteHalfNormal.InterfacesAbstractFactories
{
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    public interface ICalculationsAbstractFactory
    {
        ICCalculationFactory CreateCCalculationFactory();

        IMeanCalculationFactory CreateMeanCalculationFactory();

        IqθMeanCalculationFactory CreateqθMeanCalculationFactory();

        IxCpCalculationFactory CreatexCpCalculationFactory();

        IxpCalculationFactory CreatexpCalculationFactory();
    }
}
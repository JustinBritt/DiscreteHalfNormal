namespace DiscreteHalfNormal.InterfacesAbstractFactories
{
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    public interface ICalculationsAbstractFactory
    {
        ICCalculationFactory CreateCCalculationFactory();

        IqθMeanCalculationFactory CreateqθMeanCalculationFactory();

        IxCpCalculationFactory CreatexCpCalculationFactory();

        IxpCalculationFactory CreatexpCalculationFactory();

        IμCalculationFactory CreateμCalculationFactory();
    }
}
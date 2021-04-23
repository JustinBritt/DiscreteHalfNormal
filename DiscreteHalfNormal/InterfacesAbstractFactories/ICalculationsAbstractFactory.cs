namespace DiscreteHalfNormal.InterfacesAbstractFactories
{
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    public interface ICalculationsAbstractFactory
    {
        ICCalculationFactory CreateCCalculationFactory();

        IqθμCalculationFactory CreateqθμCalculationFactory();

        IxCpCalculationFactory CreatexCpCalculationFactory();

        IxpCalculationFactory CreatexpCalculationFactory();

        IμCalculationFactory CreateμCalculationFactory();
    }
}
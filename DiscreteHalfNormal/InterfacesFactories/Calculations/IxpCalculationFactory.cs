namespace DiscreteHalfNormal.InterfacesFactories.Calculations
{
    using DiscreteHalfNormal.Interfaces.Calculations;

    public interface IxpCalculationFactory
    {
        IxpCalculation Create(
            ICCalculation CCalculation,
            IxCpCalculation xCpCalculation,
            int xUpperBound);
    }
}
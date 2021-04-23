namespace DiscreteHalfNormal.InterfacesFactories.Calculations
{
    using DiscreteHalfNormal.Interfaces.Calculations;

    public interface IxCpCalculationFactory
    {
        IxCpCalculation Create(
            int xUpperBound);
    }
}
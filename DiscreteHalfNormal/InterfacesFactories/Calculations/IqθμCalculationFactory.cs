namespace DiscreteHalfNormal.InterfacesFactories.Calculations
{
    using DiscreteHalfNormal.Interfaces.Calculations;

    public interface IqθμCalculationFactory
    {
        IqθμCalculation Create(
            int xUpperBound);
    }
}
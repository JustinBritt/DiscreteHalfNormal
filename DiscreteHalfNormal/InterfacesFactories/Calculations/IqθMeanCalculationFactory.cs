namespace DiscreteHalfNormal.InterfacesFactories.Calculations
{
    using DiscreteHalfNormal.Interfaces.Calculations;

    public interface IqθMeanCalculationFactory
    {
        IqθMeanCalculation Create(
            int xUpperBound);
    }
}
namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class qθMeanCalculationFactory : IqθMeanCalculationFactory
    {
        public qθMeanCalculationFactory()
        {
        }

        public IqθMeanCalculation Create(
            int xUpperBound)
        {
            IqθMeanCalculation calculation = null;

            try
            {
                calculation = new qθMeanCalculation(
                    xUpperBound);
            }
            finally
            {
            }

            return calculation;
        }
    }
}
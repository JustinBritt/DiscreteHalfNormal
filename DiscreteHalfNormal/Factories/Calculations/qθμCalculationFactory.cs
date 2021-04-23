namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class qθμCalculationFactory : IqθμCalculationFactory
    {
        public qθμCalculationFactory()
        {
        }

        public IqθμCalculation Create(
            int xUpperBound)
        {
            IqθμCalculation calculation = null;

            try
            {
                calculation = new qθμCalculation(
                    xUpperBound);
            }
            finally
            {
            }

            return calculation;
        }
    }
}
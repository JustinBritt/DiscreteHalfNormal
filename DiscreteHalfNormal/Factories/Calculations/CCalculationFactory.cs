namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class CCalculationFactory : ICCalculationFactory
    {
        public CCalculationFactory()
        {
        }

        public ICCalculation Create()
        {
            ICCalculation calculation = null;

            try
            {
                calculation = new CCalculation();
            }
            finally
            {
            }

            return calculation;
        }
    }
}
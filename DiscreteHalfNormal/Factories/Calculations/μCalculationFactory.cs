namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class μCalculationFactory : IμCalculationFactory
    {
        public μCalculationFactory()
        {
        }

        public IμCalculation Create()
        {
            IμCalculation calculation = null;

            try
            {
                calculation = new μCalculation();
            }
            finally
            {
            }

            return calculation;
        }
    }
}
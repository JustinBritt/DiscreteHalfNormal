namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class MeanCalculationFactory : IMeanCalculationFactory
    {
        public MeanCalculationFactory()
        {
        }

        public IMeanCalculation Create()
        {
            IMeanCalculation calculation = null;

            try
            {
                calculation = new MeanCalculation();
            }
            finally
            {
            }

            return calculation;
        }
    }
}
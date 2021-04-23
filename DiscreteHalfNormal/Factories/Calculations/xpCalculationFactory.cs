namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class xpCalculationFactory : IxpCalculationFactory
    {
        public xpCalculationFactory()
        {
        }

        public IxpCalculation Create(
            ICCalculation CCalculation,
            IxCpCalculation xCpCalculation,
            int xUpperBound)
        {
            IxpCalculation calculation = null;

            try
            {
                calculation = new xpCalculation(
                    CCalculation,
                    xCpCalculation,
                    xUpperBound);
            }
            finally
            {
            }

            return calculation;
        }
    }
}
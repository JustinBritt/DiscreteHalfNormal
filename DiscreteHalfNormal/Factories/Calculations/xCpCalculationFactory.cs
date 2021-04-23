namespace DiscreteHalfNormal.Factories.Calculations
{
    using DiscreteHalfNormal.Classes.Calculations;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class xCpCalculationFactory : IxCpCalculationFactory
    {
        public xCpCalculationFactory()
        {
        }

        public IxCpCalculation Create(
            int xUpperBound)
        {
            IxCpCalculation calculation = null;

            try
            {
                calculation = new xCpCalculation(
                    xUpperBound);
            }
            finally
            {
            }

            return calculation;
        }
    }
}
namespace DiscreteHalfNormal.AbstractFactories
{
    using DiscreteHalfNormal.Factories.Calculations;
    using DiscreteHalfNormal.InterfacesAbstractFactories;
    using DiscreteHalfNormal.InterfacesFactories.Calculations;

    internal sealed class CalculationsAbstractFactory : ICalculationsAbstractFactory
    {
        public CalculationsAbstractFactory()
        {
        }

        public ICCalculationFactory CreateCCalculationFactory()
        {
            ICCalculationFactory factory = null;

            try
            {
                factory = new CCalculationFactory();
            }
            finally
            {
            }

            return factory;
        }

        public IqθMeanCalculationFactory CreateqθMeanCalculationFactory()
        {
            IqθMeanCalculationFactory factory = null;

            try
            {
                factory = new qθMeanCalculationFactory();
            }
            finally
            {
            }

            return factory;
        }

        public IxCpCalculationFactory CreatexCpCalculationFactory()
        {
            IxCpCalculationFactory factory = null;

            try
            {
                factory = new xCpCalculationFactory();
            }
            finally
            {
            }

            return factory;
        }

        public IxpCalculationFactory CreatexpCalculationFactory()
        {
            IxpCalculationFactory factory = null;

            try
            {
                factory = new xpCalculationFactory();
            }
            finally
            {
            }

            return factory;
        }

        public IμCalculationFactory CreateμCalculationFactory()
        {
            IμCalculationFactory factory = null;

            try
            {
                factory = new μCalculationFactory();
            }
            finally
            {
            }

            return factory;
        }
    }
}
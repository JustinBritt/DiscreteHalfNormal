namespace DiscreteHalfNormal.AbstractFactories
{
    using DiscreteHalfNormal.InterfacesAbstractFactories;

    public sealed class AbstractFactory : IAbstractFactory
    {
        public AbstractFactory()
        {
        }

        public static IAbstractFactory Create()
        {
            return new AbstractFactory();
        }

        public ICalculationsAbstractFactory CreateCalculationsAbstractFactory()
        {
            ICalculationsAbstractFactory abstractFactory = null;

            try
            {
                abstractFactory = new CalculationsAbstractFactory();
            }
            finally
            {
            }

            return abstractFactory;
        }
    }
}
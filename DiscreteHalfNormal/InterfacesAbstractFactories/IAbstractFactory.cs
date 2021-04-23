namespace DiscreteHalfNormal.InterfacesAbstractFactories
{
    using DiscreteHalfNormal.InterfacesAbstractFactories;

    public interface IAbstractFactory
    {
        ICalculationsAbstractFactory CreateCalculationsAbstractFactory();
    }
}
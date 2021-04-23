namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IxCpCalculation : IDisposable
    {
        ReadOnlySpan<xCpCalculationElement> Calculate(
            double q,
            int xUpperBound,
            double θ);
    }
}
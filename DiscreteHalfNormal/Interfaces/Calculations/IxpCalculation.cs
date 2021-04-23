namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IxpCalculation : IDisposable
    {
        ReadOnlySpan<xpCalculationElement> Calculate(
            double C,
            double q,
            int xUpperBound,
            double θ);

        ReadOnlySpan<xpCalculationElement> Calculate(
            double q,
            int xUpperBound,
            double θ);
    }
}
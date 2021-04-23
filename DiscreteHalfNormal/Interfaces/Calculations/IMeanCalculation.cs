namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IMeanCalculation
    {
        double Calculate(
            double q,
            ReadOnlySpan<xpCalculationElement> xp,
            int xUpperBound,
            double θ);
    }
}
namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface ICCalculation
    {
        double Calculate(
            ReadOnlySpan<xCpCalculationElement> xCp,
            int xUpperBound);
    }
}
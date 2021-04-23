namespace DiscreteHalfNormal.Classes.Calculations
{
    using System;

    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.Structs.CalculationElements;

    internal sealed class MeanCalculation : IMeanCalculation
    {
        public MeanCalculation()
        {
        }

        public unsafe double Calculate(
            double q,
            ReadOnlySpan<xpCalculationElement> xp,
            int xUpperBound,
            double θ)
        {
            double sum = 0;

            for (int x = 0; x <= xUpperBound; x = x + 1)
            {
                sum += xp[x].x * xp[x].p;
            }

            return sum;
        }
    }
}
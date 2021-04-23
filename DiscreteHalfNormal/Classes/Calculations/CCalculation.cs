namespace DiscreteHalfNormal.Classes.Calculations
{
    using System;

    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.Structs.CalculationElements;

    internal sealed class CCalculation : ICCalculation
    {
        public CCalculation()
        {
        }

        public unsafe double Calculate(
            ReadOnlySpan<xCpCalculationElement> xCp,
            int xUpperBound)
        {
            double sum = 0;

            for (int x = 0; x <= xUpperBound; x = x + 1)
            {
                sum += xCp[x].Cp;
            }

            return sum;
        }
    }
}
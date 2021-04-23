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

        /// <summary>
        /// Calculates the mean μ.
        /// </summary>
        /// <param name="q">q</param>
        /// <param name="xp">x, p</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θ">θ</param>
        /// <returns>Mean μ</returns>
        public unsafe double Calculate(
            double q,
            ReadOnlySpan<xpCalculationElement> xp,
            int xUpperBound,
            double θ)
        {
            double sum = 0;

            fixed (xpCalculationElement * xpPtr = xp)
            {
                for (int x = 0; x <= xUpperBound; x = x + 1)
                {
                    sum += (*(xpPtr + x)).x * (*(xpPtr + x)).p;
                }
            }

            return sum;
        }
    }
}
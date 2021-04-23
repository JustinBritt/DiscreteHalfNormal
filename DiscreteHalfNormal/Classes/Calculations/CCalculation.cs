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

        /// <summary>
        /// Calculates the normalization constant C.
        /// </summary>
        /// <param name="xCp">x, C * p</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <returns>Normalization constant C</returns>
        public unsafe double Calculate(
            ReadOnlySpan<xCpCalculationElement> xCp,
            int xUpperBound)
        {
            double sum = 0;

            fixed (xCpCalculationElement * xCpPtr = xCp)
            {
                for (int x = 0; x <= xUpperBound; x = x + 1)
                {
                    sum += (*(xCpPtr + x)).Cp;
                }
            }

            return sum;
        }
    }
}
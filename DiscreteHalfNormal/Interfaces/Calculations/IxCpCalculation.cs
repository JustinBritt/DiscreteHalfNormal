namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IxCpCalculation : IDisposable
    {
        /// <summary>
        /// Calculates x, C * p.
        /// </summary>
        /// <param name="q">q</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θ">θ</param>
        /// <returns>x, C * p</returns>
        ReadOnlySpan<xCpCalculationElement> Calculate(
            double q,
            int xUpperBound,
            double θ);
    }
}
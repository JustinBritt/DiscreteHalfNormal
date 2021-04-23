namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IxpCalculation : IDisposable
    {
        /// <summary>
        /// Calculates x, p.
        /// </summary>
        /// <param name="C">Normalization constant</param>
        /// <param name="q">q</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θ">θ</param>
        /// <returns>x, p</returns>
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
namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IμCalculation
    {
        /// <summary>
        /// Calculates the mean μ.
        /// </summary>
        /// <param name="q">q</param>
        /// <param name="xp">x, p</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θ">θ</param>
        /// <returns>Mean μ</returns>
        double Calculate(
            double q,
            ReadOnlySpan<xpCalculationElement> xp,
            int xUpperBound,
            double θ);
    }
}
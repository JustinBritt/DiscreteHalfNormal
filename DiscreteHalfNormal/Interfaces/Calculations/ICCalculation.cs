namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface ICCalculation
    {
        /// <summary>
        /// Calculates the normalization constant C.
        /// </summary>
        /// <param name="xCp">x, C * p</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <returns>Normalization constant C</returns>
        double Calculate(
            ReadOnlySpan<xCpCalculationElement> xCp,
            int xUpperBound);
    }
}
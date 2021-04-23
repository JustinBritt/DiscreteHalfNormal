namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IqθμCalculation : IDisposable
    {
        IxpCalculation xpCalculation { get; }

        /// <summary>
        /// This loops over a range of x, q, and θ values to find calculated means that are within the tolerance of a target mean.
        /// Note that 0 &lt; q &lt; 1 and 0 &lt; θ.
        /// </summary>
        /// <param name="qLowerBound">Lower bound for q</param>
        /// <param name="qStep">Step for q</param>
        /// <param name="qUpperBound">Upper bound for q</param>
        /// <param name="targetμ">Target mean</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θLowerBound">Lower bound for θ</param>
        /// <param name="θStep">Step for θ</param>
        /// <param name="θUpperBound">Upper bound for θ</param>
        /// <param name="tolerance">Tolerance</param>
        /// <returns>ReadOnlySpan of <see cref="qθμCalculationElement"/> values where |<paramref name="targetμ"/> - calculatedμ| &lt;= <paramref name="tolerance"/></returns>
        ReadOnlySpan<qθμCalculationElement> Calculate(
            double qLowerBound,
            double qStep,
            double qUpperBound,
            double targetμ,
            int xUpperBound,
            double θLowerBound,
            double θStep,
            double θUpperBound,
            double tolerance);
    }
}
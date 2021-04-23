namespace DiscreteHalfNormal.Interfaces.Calculations
{
    using System;

    using DiscreteHalfNormal.Structs.CalculationElements;

    public interface IqθMeanCalculation : IDisposable
    {
        IxpCalculation xpCalculation { get; }

        ReadOnlySpan<qθMeanCalculationElement> Calculate(
            double qLowerBound,
            double qStep,
            double qUpperBound,
            double targetMean,
            int xUpperBound,
            double θLowerBound,
            double θStep,
            double θUpperBound,
            double tolerance);
    }
}
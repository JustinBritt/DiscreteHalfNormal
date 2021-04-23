namespace DiscreteHalfNormal.Classes.Calculations
{
    using System;

    using DiscreteHalfNormal.AbstractFactories;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesAbstractFactories;
    using DiscreteHalfNormal.Structs.CalculationElements;

    internal sealed class qθMeanCalculation : IqθMeanCalculation
    {
        public qθMeanCalculation(
            int xUpperBound)
        {
            IAbstractFactory abstractFactory = AbstractFactory.Create();

            this.CCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreateCCalculationFactory().Create();

            this.MeanCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreateMeanCalculationFactory().Create();

            this.xCpCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreatexCpCalculationFactory().Create(
                xUpperBound);

            this.xpCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreatexpCalculationFactory().Create(
                this.CCalculation,
                this.xCpCalculation,
                xUpperBound);
        }

        public IxpCalculation xpCalculation { get; }

        private ICCalculation CCalculation { get; }

        private IMeanCalculation MeanCalculation { get; }

        private IxCpCalculation xCpCalculation { get; }

        /// <summary>
        /// This loops over a range of x, q, and θ values to find calculated means that are within the tolerance of a target mean.
        /// Note that 0 &lt; q &lt; 1 and 0 &lt; θ.
        /// </summary>
        /// <param name="qLowerBound">Lower bound for q</param>
        /// <param name="qStep">Step for q</param>
        /// <param name="qUpperBound">Upper bound for q</param>
        /// <param name="targetMean">Target mean</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θLowerBound">Lower bound for θ</param>
        /// <param name="θStep">Step for θ</param>
        /// <param name="θUpperBound">Upper bound for θ</param>
        /// <param name="tolerance">Tolerance</param>
        /// <returns>ReadOnlySpan of <see cref="qθMeanCalculationElement"/> values where |<paramref name="targetMean"/> - calculatedMean| <= <paramref name="tolerance"/></returns>
        public unsafe ReadOnlySpan<qθMeanCalculationElement> Calculate(
            double qLowerBound,
            double qStep,
            double qUpperBound,
            double targetMean,
            int xUpperBound,
            double θLowerBound,
            double θStep,
            double θUpperBound,
            double tolerance)
        {
            int numberAccepted = 0;

            qθMeanCalculationElement[] qθMeanArray = new qθMeanCalculationElement[
                1
                +
                (int)Math.Ceiling((qUpperBound - qLowerBound) / qStep)
                *
                (int)Math.Ceiling((θUpperBound - θLowerBound) / θStep)];

            Span<qθMeanCalculationElement> qθMeanSpan = new Span<qθMeanCalculationElement>(
                qθMeanArray);

            qθMeanSpan.Clear();

            fixed (qθMeanCalculationElement * qθMeanSpanPtr = qθMeanSpan)
            {
                for (double θ = θLowerBound; θ < θUpperBound; θ = θ + θStep)
                {
                    for (double q = qLowerBound; q < qUpperBound; q = q + qStep)
                    {
                        ReadOnlySpan<xCpCalculationElement> xCp = this.xCpCalculation.Calculate(
                            q,
                            xUpperBound,
                            θ);

                        double C = this.CCalculation.Calculate(
                            xCp,
                            xUpperBound);

                        ReadOnlySpan<xpCalculationElement> xp = this.xpCalculation.Calculate(
                            C,
                            q,
                            xUpperBound,
                            θ);

                        double calculatedMean = this.MeanCalculation.Calculate(
                            q,
                            xp.ToArray(),
                            xUpperBound,
                            θ);

                        if (calculatedMean >= 0)
                        {
                            if (Math.Abs(targetMean - calculatedMean) <= tolerance)
                            {
                                *(qθMeanSpanPtr + numberAccepted) =
                                    new qθMeanCalculationElement(
                                        q,
                                        θ,
                                        calculatedMean);

                                numberAccepted += 1;
                            }
                        }
                    }
                }
            }

            return qθMeanSpan.Slice(
                0,
                numberAccepted);
        }

        bool disposed;
        public unsafe void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                this.xCpCalculation.Dispose();

                this.xpCalculation.Dispose();
            }
        }
    }
}
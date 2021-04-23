namespace DiscreteHalfNormal.Classes.Calculations
{
    using System;

    using DiscreteHalfNormal.AbstractFactories;
    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.InterfacesAbstractFactories;
    using DiscreteHalfNormal.Structs.CalculationElements;

    internal sealed class qθμCalculation : IqθμCalculation
    {
        public qθμCalculation(
            int xUpperBound)
        {
            IAbstractFactory abstractFactory = AbstractFactory.Create();

            this.CCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreateCCalculationFactory().Create();

            this.μCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreateμCalculationFactory().Create();

            this.xCpCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreatexCpCalculationFactory().Create(
                xUpperBound);

            this.xpCalculation = abstractFactory.CreateCalculationsAbstractFactory().CreatexpCalculationFactory().Create(
                this.CCalculation,
                this.xCpCalculation,
                xUpperBound);
        }

        public IxpCalculation xpCalculation { get; }

        private ICCalculation CCalculation { get; }

        private IμCalculation μCalculation { get; }

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
        /// <returns>ReadOnlySpan of <see cref="qθμCalculationElement"/> values where |<paramref name="targetMean"/> - calculatedMean| <= <paramref name="tolerance"/></returns>
        public unsafe ReadOnlySpan<qθμCalculationElement> Calculate(
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

            qθμCalculationElement[] qθμArray = new qθμCalculationElement[
                1
                +
                (int)Math.Ceiling((qUpperBound - qLowerBound) / qStep)
                *
                (int)Math.Ceiling((θUpperBound - θLowerBound) / θStep)];

            Span<qθμCalculationElement> qθμSpan = new Span<qθμCalculationElement>(
                qθμArray);

            qθμSpan.Clear();

            fixed (qθμCalculationElement * qθμSpanPtr = qθμSpan)
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

                        double calculatedμ = this.μCalculation.Calculate(
                            q,
                            xp.ToArray(),
                            xUpperBound,
                            θ);

                        if (calculatedμ >= 0)
                        {
                            if (Math.Abs(targetMean - calculatedμ) <= tolerance)
                            {
                                *(qθμSpanPtr + numberAccepted) =
                                    new qθμCalculationElement(
                                        q,
                                        θ,
                                        calculatedμ);

                                numberAccepted += 1;
                            }
                        }
                    }
                }
            }

            return qθμSpan.Slice(
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
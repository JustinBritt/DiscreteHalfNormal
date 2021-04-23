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

        public ReadOnlySpan<qθMeanCalculationElement> Calculate(
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
            // 0 < q < 1
            // 0 < θ

            int numberAccepted = 0;

            qθMeanCalculationElement[] qθMeanArray = new qθMeanCalculationElement[
                (int)Math.Ceiling((qUpperBound - qLowerBound) / qStep)
                *
                (int)Math.Ceiling((θUpperBound - θLowerBound) / θStep)];

            Span<qθMeanCalculationElement> qθMeanSpan = new Span<qθMeanCalculationElement>(
                qθMeanArray);

            qθMeanSpan.Clear();

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
                            qθMeanSpan[numberAccepted] = 
                                new qθMeanCalculationElement(
                                    q,
                                    θ,
                                    calculatedMean);

                            numberAccepted += 1;
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
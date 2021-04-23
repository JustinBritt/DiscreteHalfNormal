namespace DiscreteHalfNormal.Structs.CalculationElements
{
    public struct qθMeanCalculationElement
    {
        public const int SizeInBytes = 32;

        public qθMeanCalculationElement(
            double q,
            double θ,
            double mean)
        {
            this.q = q;

            this.θ = θ;

            this.Mean = mean;
        }

        public double q { get; }

        public double θ { get; }

        public double Mean { get; }
    }
}
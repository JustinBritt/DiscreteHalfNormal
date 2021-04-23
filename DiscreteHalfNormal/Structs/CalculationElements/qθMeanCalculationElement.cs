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

        /// <summary>
        /// q
        /// </summary>
        public double q { get; }

        /// <summary>
        /// θ
        /// </summary>
        public double θ { get; }

        /// <summary>
        /// Mean μ
        /// </summary>
        public double Mean { get; }
    }
}
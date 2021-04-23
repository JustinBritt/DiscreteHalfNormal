namespace DiscreteHalfNormal.Structs.CalculationElements
{
    public struct qθμCalculationElement
    {
        public const int SizeInBytes = 32;

        public qθμCalculationElement(
            double q,
            double θ,
            double μ)
        {
            this.q = q;

            this.θ = θ;

            this.μ = μ;
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
        public double μ { get; }
    }
}
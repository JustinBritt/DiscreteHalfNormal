namespace DiscreteHalfNormal.Structs.CalculationElements
{
    public struct xpCalculationElement
    {
        public const int SizeInBytes = 16;

        public xpCalculationElement(
            int x,
            double p)
        {
            this.x = x;

            this.p = p;
        }

        public int x { get; }

        public double p { get; }
    }
}
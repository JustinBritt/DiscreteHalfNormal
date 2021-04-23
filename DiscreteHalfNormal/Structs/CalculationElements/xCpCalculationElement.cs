namespace DiscreteHalfNormal.Structs.CalculationElements
{
    public struct xCpCalculationElement
    {
        public const int SizeInBytes = 16;

        public xCpCalculationElement(
            int x,
            double Cp)
        {
            this.x = x;

            this.Cp = Cp;
        }

        public int x { get; }

        public double Cp { get; }
    }
}
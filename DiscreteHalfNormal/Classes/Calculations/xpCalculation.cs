namespace DiscreteHalfNormal.Classes.Calculations
{
    using System;
    using System.Runtime.InteropServices;

    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.Structs.CalculationElements;

    internal sealed class xpCalculation : IxpCalculation
    {
        public unsafe xpCalculation(
            ICCalculation CCalculation,
            IxCpCalculation xCpCalculation,
            int xUpperBound)
        {
            this.CCalculation = CCalculation;

            this.xCpCalculation = xCpCalculation;

            // xp
            this.xpIntPtr = Marshal.AllocHGlobal(
               (xUpperBound + 1)
               *
               xpCalculationElement.SizeInBytes);
        }

        private ICCalculation CCalculation { get; }

        private IxCpCalculation xCpCalculation { get; }

        private IntPtr xpIntPtr { get; }

        /// <summary>
        /// Calculates x, p.
        /// </summary>
        /// <param name="C">Normalization constant</param>
        /// <param name="q">q</param>
        /// <param name="xUpperBound">Upper bound for x</param>
        /// <param name="θ">θ</param>
        /// <returns>x, p</returns>
        public unsafe ReadOnlySpan<xpCalculationElement> Calculate(
            double C,
            double q,
            int xUpperBound,
            double θ)
        {
            Span<xpCalculationElement> xpSpan = new Span<xpCalculationElement>(
                (void*)this.xpIntPtr,
                1 + xUpperBound);

            xpSpan.Clear();

            fixed (xpCalculationElement * xpSpanPtr = xpSpan)
            {
                for (int x = 0; x <= xUpperBound; x = x + 1)
                {
                    *(xpSpanPtr + x) =
                        new xpCalculationElement(
                            x,
                            Math.Pow(θ, x)
                            *
                            Math.Pow(q, (int)(x * (x - 1) * 0.5))
                            *
                            Math.Pow(C, -1));
                }
            }

            return xpSpan;
        }

        public unsafe ReadOnlySpan<xpCalculationElement> Calculate(
            double q,
            int xUpperBound,
            double θ)
        {
            ReadOnlySpan<xCpCalculationElement> xCp = this.xCpCalculation.Calculate(
                q,
                xUpperBound,
                θ);

            double C = this.CCalculation.Calculate(
                xCp,
                xUpperBound);

            xpCalculationElement[] xpArray = new xpCalculationElement[xUpperBound + 1];

            Span<xpCalculationElement> xpSpan = new Span<xpCalculationElement>(
                xpArray);

            xpSpan.Clear();

            fixed (xpCalculationElement * xpSpanPtr = xpSpan)
            {
                for (int x = 0; x <= xUpperBound; x = x + 1)
                {
                    *(xpSpanPtr + x) =
                        new xpCalculationElement(
                            x,
                            Math.Pow(θ, x)
                            *
                            Math.Pow(q, (int)(x * (x - 1) * 0.5))
                            *
                            Math.Pow(C, -1));
                }
            }

            return xpSpan;
        }

        bool disposed;
        public unsafe void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                // xp
                Marshal.FreeHGlobal(
                    this.xpIntPtr);
            }
        }
    }
}
namespace DiscreteHalfNormal.Classes.Calculations
{
    using System;
    using System.Runtime.InteropServices;

    using DiscreteHalfNormal.Interfaces.Calculations;
    using DiscreteHalfNormal.Structs.CalculationElements;

    internal unsafe sealed class xCpCalculation : IxCpCalculation
    {
        public unsafe xCpCalculation(
            int xUpperBound)
        {
            // xCp
            this.xCpIntPtr = Marshal.AllocHGlobal(
               (xUpperBound + 1)
               *
               xCpCalculationElement.SizeInBytes);
        }

        private IntPtr xCpIntPtr { get; }

        public unsafe ReadOnlySpan<xCpCalculationElement> Calculate(
            double q,
            int xUpperBound,
            double θ)
        {
            Span<xCpCalculationElement> xCpSpan = new Span<xCpCalculationElement>(
                (void*)this.xCpIntPtr,
                1 + xUpperBound);

            xCpSpan.Clear();

            fixed (xCpCalculationElement * xCpSpanPtr = xCpSpan)
            {
                for (int x = 0; x <= xUpperBound; x = x + 1)
                {
                    *(xCpSpanPtr + x) =
                        new xCpCalculationElement(
                            x,
                            Math.Pow(θ, x)
                            *
                            Math.Pow(q, (int)(x * (x - 1) * 0.5)));
                }
            }

            return xCpSpan;
        }

        bool disposed;
        public unsafe void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                // xCp
                Marshal.FreeHGlobal(
                    this.xCpIntPtr);
            }
        }
    }
}
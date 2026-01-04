namespace OptimizationState.StateTransitions.LexicographicNext.BitTransitions
{
    public static class BitTransitionExtension
    {
        /// <summary>
        /// Returns the next larger integer with the same number of set bits (1s).
        /// This is the "Next Permutation" equivalent for the bit space.
        /// </summary>
        public static int NextWithSameBitCount(int n)
        {
            if (n <= 0) return -1;

            int smallest = n & -n;

            int ripple = n + smallest;

            if (ripple < 0) return -1;

            int ones = (n ^ ripple) >> 2;
            int tail = ones / smallest;

            return ripple | tail;
        }
    }
}
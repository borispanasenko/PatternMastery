namespace OptimizationState.StateTransitions.LexicographicNext.PermutationTransition
{
    public static class NextSmaller
    {
        /// <summary>
        /// Finds the nearest smallest integer consisting of the digits of the given positive integer.
        /// Logic: Inverted NextBigger.
        /// 1. Find pivot (first digit from right that is larger than than previous).
        /// 2. Swap with the largest digit in tail that is less than pivot.
        /// 3. Sort tail descending (9..0) to maximize it.
        /// </summary>
        /// <returns>int.</returns>
        public static int NextSmallerThan(int number)
        {
            if (number < 0) throw new ArgumentException("Number cannot be less than 0.", nameof(number));

            long temp = number;

            long suffixBag = 0;
            long suffixPow = 1;

            int pivot = -1;
            int lastDigit = -1;

            while (temp > 0)
            {
                int currentDigit = (int)(temp % 10);
                temp /= 10;

                if (lastDigit != -1 && currentDigit > lastDigit)
                {
                    pivot = currentDigit;
                    break;
                }

                suffixBag += currentDigit * suffixPow;
                suffixPow *= 10;

                lastDigit = currentDigit;
            }

            if (pivot == -1) return -1;

            int maxSmallerSwap = -1;
            long swapSearchTemp = suffixBag;

            while (swapSearchTemp > 0)
            {
                int d = (int)(swapSearchTemp % 10);

                if (d < pivot && d > maxSmallerSwap)
                {
                    maxSmallerSwap = d;
                }

                swapSearchTemp /= 10;
            }

            long result = temp * 10 + maxSmallerSwap;

            for (int digit = 9; digit >= 0; digit--)
            {
                int count = 0;
                if (pivot == digit) count++;

                long tailScanner = suffixBag;
                while (tailScanner > 0)
                {
                    if (tailScanner % 10 == digit) count++;
                    tailScanner /= 10;
                }

                if (maxSmallerSwap == digit) count--;

                for (int i = 0; i < count; i++)
                {
                    result = result * 10 + digit;
                }
            }

            if (result > int.MaxValue) return -1;

            return (int)result;
        }
    }
}
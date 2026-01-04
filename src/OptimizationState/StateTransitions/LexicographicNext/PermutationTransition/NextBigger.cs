// <copyright file="NextBigger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OptimizationState.StateTransitions.LexicographicNext.PermutationTransition;

public class NextBigger
{
    /// <summary>
    /// Finds the nearest largest integer consisting of the digits of the given positive integer number; return -1 if no such number exists.
    /// </summary>
    /// <param name="number">Source number.</param>
    /// <returns>
    /// The nearest largest integer consisting of the digits  of the given positive integer; return -1 if no such number exists.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
    public static int NextBiggerThan(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number cannot be less than 0.", nameof(number));
        }

        long temp = number;

        long suffixBag = 0;
        long suffixPow = 1;

        int pivot = -1;
        int lastDigit = -1;

        while (temp > 0)
        {
            int currentDigit = (int)(temp % 10);
            temp /= 10;

            if (lastDigit != -1 && currentDigit < lastDigit)
            {
                pivot = currentDigit;
                break;
            }

            suffixBag += currentDigit * suffixPow;
            suffixPow *= 10;

            lastDigit = currentDigit;
        }

        if (pivot == -1)
        {
            return -1;
        }

        int swapDigit = 10;
        long swapSearchTemp = suffixBag;

        while (swapSearchTemp > 0)
        {
            int d = (int)(swapSearchTemp % 10);
            if (d > pivot && d < swapDigit)
            {
                swapDigit = d;
            }

            swapSearchTemp /= 10;
        }

        if (swapDigit == 10)
        {
            return -1;
        }

        long result = (temp * 10) + swapDigit;

        for (int digit = 0; digit <= 9; digit++)
        {
            int count = 0;

            if (pivot == digit)
            {
                count++;
            }

            long tailScanner = suffixBag;
            while (tailScanner > 0)
            {
                if (tailScanner % 10 == digit)
                {
                    count++;
                }

                tailScanner /= 10;
            }

            if (swapDigit == digit)
            {
                count--;
            }

            for (int i = 0; i < count; i++)
            {
                result = (result * 10) + digit;
            }
        }

        if (result > int.MaxValue)
        {
            return -1;
        }

        return (int)result;
    }
}
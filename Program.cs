using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    
    static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;
        while (left < right)
        {
            if (word[left] != word[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    static void Main(string[] args)
    {
        string[] words = { "racecar", "hello", "world" };
        bool foundPalindrome = false;

        Thread[] threads = new Thread[words.Length];

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < words.Length; i++)
        {
            int index = i; 

            threads[i] = new Thread(() =>
            {
                if (IsPalindrome(words[index]))
                {
                    foundPalindrome = true;
                    Console.WriteLine($"Found a palindrome: {words[index]}");
                }
            });

            threads[i].Start();
        }

        
        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");

        if (!foundPalindrome)
        {
            Console.WriteLine("No palindrome found.");
        }
    }
}

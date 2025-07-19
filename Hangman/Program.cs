using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main()
    {
        //string word = "";
        Dictionary<char, int> hashh = new Dictionary<char, int>();
        Dictionary<char, int> hashh2 = new Dictionary<char, int>();
        string underscore = "";
        string compare = "";
        int tries = 4;
        int gamestate = 0; // Game in progress =0, Game won =1, game lost=2
        Console.WriteLine("Welcome to hangman!");
        Console.WriteLine("Please enter a word");
        string word=Console.ReadLine();
        Console.WriteLine("You have 4 attempts remaining");
        Console.WriteLine("==== CHANGE APPLIED ====");

        for (int i = 0; i < word.Length; i++)
        {
            underscore += "_";
            if (!hashh.ContainsKey(word[i]))
            {
                hashh[word[i]] = 1;
            }
            else
            {
                hashh[word[i]] += 1;
            }
        }
        while (gamestate == 0)
        {
            char guess = Console.ReadLine()[0];
            if (hashh.ContainsKey(guess))
            {
                if (hashh[guess] == 0) {
                    Console.WriteLine("You have already guessed this letter");
                    }
                else
                {

                    hashh[guess]--;
                    Console.WriteLine("correct Guess");
                    if (!hashh2.ContainsKey(guess))
                    {
                        hashh2[guess] = 1;
                    }
                    else
                    {
                        hashh2[guess] += 1;
                    }
                    for(int i=0; i < word.Length; i++)
                    {
                        if (hashh2.ContainsKey(word[i]))
                            {
                            compare += word[i];
                        }
                        else
                        {
                            compare += "_";
                        }
                        if (compare.Equals(word))
                        {
                            gamestate = 1;
                        }
                    }
                }
            }
            
        else {
            tries--;
                if (tries == 0)
                {
                    gamestate = 2;
                }
            Console.WriteLine(compare);
            Console.WriteLine($"Incorrect {tries} tries remaining!");
                for (int i = 0; i < word.Length; i++)
                {
                    if (hashh2.ContainsKey(word[i]))
                    {
                        compare += word[i];
                    }
                    else
                    {
                        compare += "_";
                    }
                }

            }

            Console.WriteLine(compare);
            compare = "";
        }
        if (gamestate == 1)
        {
            Console.WriteLine("You've won!");
        }
        else
        {
            Console.WriteLine("You've lost!");
        }
    
    } 
   
    }



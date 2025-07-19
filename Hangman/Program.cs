using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Net.Http;
using System.Text.Json;
class Program
{
    static async Task Main()
    {
       bool game = true;
        while (game == true)
        {
            Dictionary<char, int> hashh = new Dictionary<char, int>();
            Dictionary<char, int> hashh2 = new Dictionary<char, int>();
            string underscore = "";
            string compare = "";
            int tries = 6;
            int gamestate = 0; // Game in progress =0, Game won =1, game lost=2
            Console.WriteLine("Welcome to hangman!");
            string[] word1 = await GetWord();
            string word = word1[0];

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
            Console.WriteLine($"You have {tries} attempts remaining");
            Console.WriteLine(underscore);
            while (gamestate == 0)
            {
                char guess = Console.ReadLine()[0];
                if (hashh.ContainsKey(guess))
                {
                    if (hashh[guess] == 0)
                    {
                        Console.WriteLine("You have already guessed this letter");
                    }
                    else
                    {

                        hashh[guess] = 0;
                        Console.WriteLine("correct Guess");
                        if (!hashh2.ContainsKey(guess))
                        {
                            hashh2[guess] = 1;
                        }
                        else
                        {
                            hashh2[guess] += 1;
                        }
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
                            if (compare.Equals(word))
                            {
                                gamestate = 1;
                            }
                        }
                    }
                }

                else
                {
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

                Console.WriteLine($"You've lost!, the word is :{word}");
            }

            Console.WriteLine("Type 1 to play again");
            Console.WriteLine("Enter any key to exit");
            string playagain = Console.ReadLine();
                 if( !playagain.Equals("1"))
            {
                Console.WriteLine("Thank you for playing!");
                game = false;
            }

        }
    } 
    public static async Task<String[]> GetWord()
    {
        HttpClient client= new HttpClient();
        string uri = "https://random-word-api.herokuapp.com/word";
        try
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string res = await response.Content.ReadAsStringAsync();
            string[] words = JsonSerializer.Deserialize<string[]>(res);
            return words;
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine(e.Message);
            return ["Error"];
        }
    }
    }



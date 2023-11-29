using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
     int tries=5;
    string name ="";
    string name2 ="";
    string letter="";
    string combined="";
    int count=0;
    bool win=false;
List<string> underscore = new List<string> {""};
    int indx=0;
        Console.WriteLine($"Welcome to hangman!");
        Console.WriteLine($"Enter a word");
       name= Console.ReadLine();
       name2=name;
        Console.WriteLine($"Game will now commence!");
        for(int i=0;i<name2.Length;i++){
            underscore.Add("_");
        }
    while (tries!=0){
        Console.WriteLine($"{tries} tries remaining");
           foreach (string word in underscore)
        {
            Console.Write(word);
        }
    
       letter= Console.ReadLine();
       if(name.Length<=0){
        Console.WriteLine($"{name.Length}");
        win=true;
                Console.WriteLine("Congratulations You have Won!");
break;

       }
            if(name.Contains(letter)){
                combined=combined+letter;
                indx=name2.IndexOf(letter);
                underscore[indx]=letter;
                string modifiedString = name.Replace(letter.ToString(), "");
                name=modifiedString;
            }
            else{
                Console.WriteLine($"Wrong!");
                tries--;
            }
    }
           if(win==false){
                Console.WriteLine($"You have lost!");
       }


    }
           static void Eat(string name)
    {
        
        Console.WriteLine("The animal is eating.");

    }

}
    public class Guess
    {
        public void po(string name){
            Console.Write($"po is a popopopopo {name}");
        }
        
    }


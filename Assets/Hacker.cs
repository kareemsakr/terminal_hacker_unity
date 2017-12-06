using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;
public class Level
{
    public string Rank
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string Password
    {
        get;
        set;
    }
    public bool IsEasterEGG
    {
        get;
        set;
    }
}

public class Hacker : MonoBehaviour {


    int level;

    public List<Level> MyLevels = new List<Level>()
    {
        new Level(){ Rank = "1" , Name ="Mama's laptop" , Password = "qwerty"},
        new Level(){ Rank = "2" , Name ="Mohannad's laptop" , Password = "dont_touch"},
        new Level(){ Rank = "007" , Name ="007" , Password = "martini" , IsEasterEGG = true},
    };

    enum Screen { Main, GuessPw, Win};

    Screen currentScreen;

	// Use this for initialization
    void Start () {
       PrintMainMenu();

	}





    void  PrintMainMenu()
    {
        currentScreen = Screen.Main;
        Terminal.WriteLine("Hello Dear!");
        PrintOptions();
        Terminal.WriteLine("Choose Wisely!!!");
    }


    void OnUserInput(string input)
    {
        //if (Enumerable.Range(1,Options.Count()).Select(item => item.ToString()).Contains(input))

        if (input.ToLower().Trim() == "menu")
        {
            PrintMainMenu();
        }
        //else if(Regex.IsMatch(input, @"^[0-9]+$") && Convert.ToInt32(input) <= Options.Count)
        else if(currentScreen == Screen.Main)
        {
            RunMainMenu(input);
        }

    }

    private void RunMainMenu(string input)
    {
        currentScreen = Screen.GuessPw;
        Terminal.WriteLine("You've chosen level " + input);
    }



    void PrintOptions() 
    {

        foreach (var level in MyLevels)
        {
            if (!level.IsEasterEGG)
            {
                Terminal.WriteLine(level.Rank + " - " + level.Name);
            }
        }
    }

}

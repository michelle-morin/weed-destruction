using System;
using System.Collections.Generic;
using KillTheWeed.Models;

namespace KillTheWeed
{
  public class Program
  {
    public static void Main()
    {
      Console.Clear();
      Console.WriteLine("Evil weeds from the planet InvasiveSpecies VII have invaded your yard!");
      Console.WriteLine("Are you brave enough to undertake the mission to protect your home from total weed-nihilation?!");
      Console.WriteLine("[START] [RUN AWAY]");
      string startStatus = Console.ReadLine();
      if (startStatus.ToLower() == "start")
      {
        Player player = new Player();
        List<Weed> weedList = Weed.GetWeeds();
        string yardSize = ChooseBattleField();
        FillYard(yardSize, weedList);
        Battle(player, weedList);
      }
      else if (startStatus.ToLower() == "run away")
      {
        Console.WriteLine("You have forsaken yourself and therfore your all of humanity. You can only cower and watch as the weeds devour your world and block out the sun, relegating you to eternal darkness.");
      }
      else 
      {
        Main();
      }
    }

    public static string ChooseBattleField()
    {
      Console.WriteLine("Choose your battlefield:");
      Console.WriteLine("[SMALL] [MEDIUM] [LARGE]");
      string yardSize = Console.ReadLine();
      return yardSize;
    }

    public static void FillYard(string yardSize, List<Weed> weedList)
    {
      if (yardSize.ToLower() == "small" || yardSize.ToLower() == "medium" || yardSize.ToLower() == "large")
      {
        Weed.PopulateYard(yardSize);
        Console.WriteLine("Enemy Combatants have entered the battle!");
        DisplayWeeds(weedList);
      }
      else
      {
        string newYardSize = ChooseBattleField();
        FillYard(newYardSize, weedList);
      }
    }

    public static string ChooseOption()
    {
      Console.WriteLine("How shall we fight the weeds today? Or How about a nice refreshing beverage? Or Sleep? Or Hawaiian Vacation?? The choice is yours!");
      Console.WriteLine("[ROUND UP] [TROWEL] [HULA HOE] [TURBO TOOL]");
      Console.WriteLine("[WATER] [SLEEP] [VACATION]");
      string action = Console.ReadLine();
      return action;
    }

    public static void Battle(Player player, List<Weed> weedList)
    {
      string action = ChooseOption();
      Console.Clear();
      if (action.ToLower() == "round up" || action.ToLower() == "trowel" || action.ToLower() == "turbo tool" || action.ToLower() == "hula hoe" || action.ToLower() == "vacation" || action.ToLower() == "sleep" || action.ToLower() == "water")
      {
        if (action.ToLower() == "round up")
        {
          Weed.RoundUp(player);
          Console.WriteLine("You damaged each weed at the expense of your own health!");
        }
        else if (action.ToLower() == "trowel" || action.ToLower() == "turbo tool" || action.ToLower() == "hula hoe")
        {
          DisplayWeeds(weedList);
          Console.WriteLine("Which weed would you like to attack?");
          Console.WriteLine("[ ENTER WEED NUMBER ]");
          string stringWeedOption = Console.ReadLine();
          int weedOption = int.Parse(stringWeedOption);
          int weedOptionNum = weedOption - 1;
          Console.WriteLine("weed option: " + weedOption);
          Console.WriteLine("weed option - 1: " + weedOptionNum);
          Weed selectedWeed = weedList[weedOptionNum];
          if (action.ToLower() == "trowel")
          {
            selectedWeed.Trowel(player);
          }
          else if (action.ToLower() == "turbo tool")
          {
            selectedWeed.TurboTool(player);
          }
          else if (action.ToLower() == "hula hoe")
          {
            selectedWeed.HulaHoe(player);
          }
        }
        else if (action.ToLower() == "vacation")
        {
          player.Vacation(weedList);
          Console.WriteLine("You fly away to paradise... Meanwhile the weeds commit atrocities against your yard!");
        }
        else if (action.ToLower() == "sleep")
        {
          player.Sleep(weedList);
          Console.WriteLine("Your weeds grew while you were asleep!");
        }
        else if (action.ToLower() == "water")
        {
          player.BeverageBreak();
          Console.WriteLine("Now that you're hydrated... are you ready to battle the weeds again?");
        }
        Weed.CheckAlive();
        NextMove(player, weedList);
      }
      else
      {
        Battle(player, weedList);
      }
    }

    public static int CheckGameStatus(Player player, List<Weed> weedList)
    {
      if (player.Health <= 0 || weedList.Count > 20)
      {
        return 1;
      }
      else if (weedList.Count == 0)
      {
        return 2;
      }
      else
      {
        return 0;
      }
    }

    public static void EndGame(int isGameOver)
    {
      if (isGameOver == 1)
      {
        Console.WriteLine("The weeds took over!");
        Console.WriteLine("GAME OVER");
      }
      else if (isGameOver == 2)
      {
        Console.WriteLine("You defeated the weeds!");
        Console.WriteLine("GAME OVER");
      }
    }

    public static void NextMove(Player player, List<Weed> weedList)
    {
      int isGameOver = CheckGameStatus(player, weedList);
      if (isGameOver == 0)
      {
        DisplayWeeds(weedList);
        DisplayPlayer(player);
        Battle(player, weedList);
      }
      else if (isGameOver == 1 || isGameOver == 2)
      {
        EndGame(isGameOver);
      }
    }

    public static void DisplayWeeds(List<Weed> weedList)
    {
      Console.WriteLine("Your opponents:");
      int counter = 1;
      foreach(Weed currentWeed in weedList)
      {
        Console.WriteLine("Weed "+ counter + " size: " + currentWeed.Size);
        Console.WriteLine("---------------");
        counter++;
      }
    }

    public static void DisplayPlayer(Player player)
    {
      Console.WriteLine("Your current health: " + player.Health);
      Console.WriteLine("---------------");
    }
  }
}
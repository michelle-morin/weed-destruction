using System;

namespace KillTheWeed
{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Evil weeds from the planet InvasiveSpecies VII have invaded your yard!");
      Console.WriteLine("Are you brave enough to undertake the mission to protect your home from total weed-nihilation?!");
      Console.WriteLine("[START] [RUN AWAY]");
      string startStatus = Console.ReadLine();
      if (startStatus.ToLower() = "start")
      {
        
      }
      else if (startStatus.ToLower() = "run away")
      {
        Console.WriteLine("You have forsaken yourself and therfore your all of humanity. You can only cower and watch as the weeds devour your world and block out the sun, relegating you to eternal darkness.")
      }
      else 
      {
        Console.WriteLine("Please select Start or Run Away")
        // Add Return To Menu Logic
      }
    }


    public static void CheckGameStatus()
    {
      if (Player.Alive == false || Weed.myWeeds.Count > 50)
      {
        Console.WriteLine("The weeds took over!");
        Console.WriteLine("GAME OVER");
      }
      else if (Weed.myWeeds.Count == 0)
      {
        Console.WriteLine("You defeated the weeds!");
        Console.WriteLine("GAME OVER");
      }
    }

    public static void RestartGame()
    {
      List<Weed> myWeeds = new List<Weed> {};
      Main();
    }
  }
}
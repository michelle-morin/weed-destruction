using System;

namespace KillTheWeed.Models
{
  public class Player
  {
    public int Health { get; set; }
    public bool Alive { get; set; }

    public Player()
    {
      Health = 100;
      Alive = true;
    }

    public static void BeverageBreak()
    {
      Health += 20;
    }

    public void CheckHealth()
    {
      if (Health <= 0)
      {
        Alive = false;
      }
      else
      {
        Alive = true;
      }
    }
  }
}
using System;
using System.Collections.Generic;

namespace KillTheWeed.Models
{
  public class Weed
  {
    public int Size { get; set; }
    public bool Alive { get; set; }
    private static List<Weed> _myWeeds = new List<Weed>() {};

    public Weed()
    {
      Size = 5;
      Alive = true;
    }

    public static List<Weed> GetWeeds() 
    {
      return _myWeeds;
    }

    public static void RoundUp(Player player)
    {
      foreach (Weed currentWeed in _myWeeds)
      {
        currentWeed.Size -= 2;
      }
      player.Health -= 50;
    }

    public void HulaHoe(Player player)
    {
      Size -= 4;
      player.Health -= 10;
    }

    public void Trowel(Player player)
    {
      Size -= 3;
      player.Health -= 10;
    }

    public void TurboTool(Player player)
    {
      Size = 0;
      player.Health -= 10;
    }

    public static void CheckAlive()
    {
      foreach (Weed currentWeed in _myWeeds)
      {
        if (currentWeed.Size <= 0)
        {
          currentWeed.Alive = false;
          _myWeeds.Remove(currentWeed);
        }
        else
        {
          currentWeed.Alive = true;
        }
      }
    }

    public static void PopulateYard(string yardSize)
    {
      if (yardSize.ToLower() == "small")
      {
        for (int i=0; i<3; i++)
        {
          Weed weed = new Weed();
          _myWeeds.Add(weed);
        }
      }
      else if (yardSize.ToLower() == "medium")
      {
        for (int i=0; i<6; i++)
        {
          Weed weed = new Weed();
          _myWeeds.Add(weed);
        }
      }
      else if (yardSize.ToLower() == "large")
      {
        for (int i=0; i<10; i++)
        {
          Weed weed = new Weed();
          _myWeeds.Add(weed);
        }
      }
    }
  }
}
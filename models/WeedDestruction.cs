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

    public static List<Weed> getWeeds() {
      return _myWeeds;
    }

    public void RoundUp()
    {
      foreach (Weed currentWeed in _myWeeds)
      {
        Size -= 2;
      }
    }

    public void YardTool()
    {
      Size -= 4;
    }

    public void TurboTool()
    {
      Size = 0;
    }

    public void CheckAlive()
    {
      foreach (Weed currentWeed in _myWeeds)
      {
        if (currentWeed.Size <= 0)
        {
          Alive = false;
          _myWeeds.Remove(currentWeed);
        }
        else
        {
          Alive = true;
        }
      }
    }

    public static void PopulateYard(string yardSize)
    {
      if (yardSize.ToLower() == "small")
      {
        for (int i=0; i<4; i++)
        {
          Weed weed = new Weed();
          _myWeeds.Add(weed);
        }
      }
      else if (yardSize.ToLower() == "medium")
      {
        for (int i=0; i<7; i++)
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
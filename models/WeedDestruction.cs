using System;

namespace KillTheWeed.Models
{
  public class Weed
  {
    public int Size { get; set; }
    public bool Alive { get; set }

    public Weed()
    {
      Size = 5;
      Alive = true;
    }

    List<Weed> myWeeds = new List<Weed> {};

    public static void RoundUp()
    {
      Size -= 2;
      Player.Health -= 25;
    }

    public void YardTool()
    {
      Size -= 4;
    }

    public void TurboTool()
    {
      Size = 0;
    }

    public static void CheckAlive()
    {
      foreach (Weed weed in myWeeds)
      {
        if (Size <= 0)
        {
          Alive = false;
          myWeeds.Remove(weed);
        }
        else
        {
          Alive = true;
        }
      }
    }

    public static void PopulateYard(int yardSize)
    {
      if (yardSize < 1)
      {
        for (int i=0; i<4; i++)
        {
          Weed weed = new Weed();
          myWeeds.Add(weed);
        }
      }
      else if (yardSize < 2)
      {
        for (int i=0; i<7; i++)
        {
          Weed weed = new Weed();
          myWeeds.Add(weed);
        }
      }
      else 
      {
        for (int i=0; i<10; i++)
        {
          Weed weed = new Weed();
          myWeeds.Add(weed);
        }
      }
    }
  }
}
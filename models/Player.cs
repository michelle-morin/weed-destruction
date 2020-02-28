using System;
using System.Collections.Generic;

namespace KillTheWeed.Models
{
  public class Player
  {
    public int Health { get; set; }
    private static Player _player = new Player();

    public static Player GetPlayer()
    {
      return _player;
    }

    public Player()
    {
      Health = 100;
    }
    
    public void BeverageBreak()
    {
      if (Health + 15 > 100)
      {
        Health = 100;
      }
      else
      {
        Health += 15;
      }
    }

    public void Sleep(List<Weed> weedList)
    {
      if (Health + 30 > 100)
      {
        Health = 100;
      }
      else
      {
        Health += 30;
      }
      for (int i=0; i<weedList.Count; i++)
      {
        weedList[i].Size += 1;
      }
    }

    public void Vacation(List<Weed> weedList)
    {
      Health = 100;
      for(int i=1; i < 3; i++)
      {
        Weed weed = new Weed();
        weedList.Add(weed);
      }
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class BreakWall : IMove
  {
    private HeroState _hero;
    private MapCellState _cell;

    public BreakWall(HeroState hero, MapCellState cell) 
    {
      _hero = hero;
      _cell = cell;
    }

    void IMove.Do()
    {
      _cell.IsBroken = true;
      _hero.CanAct = false;
    }
  }
}

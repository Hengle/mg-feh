using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class MoveHeroTo : IMove
  {
    private HeroState _hero;
    private int _distance;
    private MapCellState _cell;
    private MapState _map;
    private bool _pushed;

    public MoveHeroTo(HeroState hero, int distance, MapCellState cell, MapState map, bool pushed = false)
    {
      _hero = hero;
      _distance = distance;
      _cell = cell;
      _map = map;
      _pushed = pushed;
    }

    void IMove.Do()
    {
      _hero.Location = _cell.Location;
    }
  }
}

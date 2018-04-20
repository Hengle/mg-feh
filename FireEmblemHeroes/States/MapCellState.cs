using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class MapCellState
  {
    public MapCellState(MapCell cell, MapCellLocation location)
    {
      Cell = cell;
      Location = location;
    }

    public MapCell Cell { get; }
    public MapCellLocation Location { get; }

    public bool IsBroken { get; set; } = false;

    public bool IsBreakable => Cell.Flags.HasFlag(MapCellFlags.Breakable);
    public bool IsWall => Cell.Flags.HasFlag(MapCellFlags.Wall) || (IsBreakable && !IsBroken);
    public bool IsForest => Cell.Flags.HasFlag(MapCellFlags.Forest);
    public bool IsWater => Cell.Flags.HasFlag(MapCellFlags.Water);
    public bool IsAir => Cell.Flags.HasFlag(MapCellFlags.Air);
    public bool IsTrench => Cell.Flags.HasFlag(MapCellFlags.Trench);
    public bool IsMountains => Cell.Flags.HasFlag(MapCellFlags.Mountains);
  }
}

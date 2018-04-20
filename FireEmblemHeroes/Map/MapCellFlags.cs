using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  [Flags]
  public enum MapCellFlags : int
  {
    Plain = 0,
    Air = 1 << 0,
    Forest = 1 << 1,
    Mountains = 1 << 2,
    Water = 1 << 3,
    Wall = 1 << 4,
    Breakable = 1 << 5,
    Defensive = 1 << 6,
    Trench = 1 << 7,
  }
}

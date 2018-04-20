using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class MapCell
  {
    public MapCell(MapCellFlags flags)
    {
      Flags = flags;
    }

    public MapCellFlags Flags { get; }
  }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public static class Maps
  {
    public static int[,] Kenney1 = new[,]
    {
      { 0, 0, 0, 0, 0, 0 },
      { 0, 0, 0, 0, 0, 0 },
      { 0, 0, 0, 0, 0, 0 },
      { 2, 2, 32, 2, 2, 2 },
      { 2, 2, 2, 32, 2, 2 },
      { 0, 0, 0, 0, 0, 0 },
      { 0, 0, 0, 0, 0, 0 },
      { 0, 0, 0, 0, 0, 0 },
    };

    public static Map CreateMap(int[,] data)
    {
      var rows = data.GetLength(0);
      var columns = data.GetLength(1);
      var map = new Map(rows, columns);

      int r, c;
      for (r = 0; r < rows; ++r)
      {
        for (c = 0; c < columns; ++c)
        {
          map.SetCell(r, c, (MapCellFlags)data[r, c]);
        }
      }

      return map;
    }
  }
}

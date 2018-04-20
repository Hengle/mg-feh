using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class Map
  {
    public const int DefaultRows = 8;
    public const int DefaultColumns = 6;

    private readonly MapCell[,] _cells;

    public Map() 
      : this(DefaultRows, DefaultColumns)
    {

    }

    public Map(int rows, int columns)
    {
      _cells = new MapCell[rows, columns];
      Rows = rows;
      Columns = columns;
    }

    public void SetCell(int row, int column, MapCellFlags flags)
    {
      _cells[row, column] = new MapCell(flags);
    }

    public int Rows { get; }
    public int Columns { get; }

    public MapCell this[MapCellLocation loc]
    {
      get => _cells[loc.Row, loc.Column];
      set => _cells[loc.Row, loc.Column] = value;
    }
  }
}

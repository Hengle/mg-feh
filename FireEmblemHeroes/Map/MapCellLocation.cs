using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  [StructLayout(LayoutKind.Explicit)]
  public struct MapCellLocation : IEquatable<MapCellLocation>
  {
    [FieldOffset(0)]
    public byte Row;

    [FieldOffset(1)]
    public byte Column;

    [FieldOffset(0)]
    public int Key;

    public MapCellLocation(int row, int column)
      : this()
    {
      Row = (byte)row;
      Column = (byte)column;
    }

    public MapCellLocation(byte row, byte column)
      : this()
    {
      Row = row;
      Column = column;
    }

    public static (int dr, int dc) Diff(MapCellLocation x, MapCellLocation y)
    {
      (int xr, int xc) = x;
      (int yr, int yc) = y;
      return (xr - yr, xc - yc);
    }

    public static implicit operator MapCellLocation((byte row, byte col) t)
    {
      return new MapCellLocation(t.row, t.col);
    }

    public void Deconstruct(out byte row, out byte column)
    {
      row = Row;
      column = Column;
    }

    public override int GetHashCode()
    {
      return Key;
    }

    public override bool Equals(object obj)
    {
      if (obj is MapCellLocation l)
      {
        return Equals(l);
      }

      return false;
    }

    public bool Equals(MapCellLocation other)
    {
      return Key == other.Key;
    }
  }
}

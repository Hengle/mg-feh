using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class AggregateMove : IMove
  {
    private readonly IMove[] _moves;

    /// <summary> Creates a move that will perform each of the moves in order. </summary>
    public AggregateMove(params IMove[] moves)
    {
      _moves = moves;
    }
  }
}

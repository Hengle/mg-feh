using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public class RandomAI : BaseHeroAI
  {
    private readonly Random _random = new Random();

    public RandomAI(HeroState owner) 
      : base(owner)
    {

    }

    public override IMove GetMove(MapState state)
    {
      var moves = state.GetMoves(Owner);
      return moves[_random.Next(moves.Length)];
    }
  }
}

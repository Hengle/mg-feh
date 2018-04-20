using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblemHeroes
{
  public abstract class AssistSkill
  {
    public virtual bool TeamOnly => true;
    public abstract int Range { get; }
    public abstract IEnumerable<IMove> ValidMovesFor(MapCellLocation location, HeroState owner, HeroState target, MapState map);
  }
}

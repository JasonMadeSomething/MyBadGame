using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Components.Stats
{
    public class ManaComponent : StatComponent
    {
        public ManaComponent() : base(1, 1) { }

        public ManaComponent(int endurance, int scalingFactor)
            : base(endurance, scalingFactor)
        { }

    }
}
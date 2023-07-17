using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Components.Stats
{
    public class HealthComponent : StatComponent
    {
        public HealthComponent() : base(1, 1) { }

        public HealthComponent(int endurance, int scalingFactor)
            : base(endurance, scalingFactor)
        { }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeGame.Components.Stats;

namespace SomeGameTests.ComponentTests.StatsTests
{
    [TestFixture]
    public class HealthComponentTests : StatComponentTests<HealthComponent>
    {
        public HealthComponentTests() : base(10, 1) { }
        protected override HealthComponent CreateStatComponent(int keyAttributeValue, int scalingFactor)
        {
            return new HealthComponent(keyAttributeValue, scalingFactor);
        }

    }
}

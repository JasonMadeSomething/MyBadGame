using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeGame.Components.Stats;
namespace SomeGameTests.ComponentTests.StatsTests
{
    [TestFixture]
    public class ManaComponentTests : StatComponentTests<ManaComponent>
    {
        public ManaComponentTests() : base(10, 1) { }
        protected override ManaComponent CreateStatComponent(int keyAttributeValue, int scalingFactor)
        {
            return new ManaComponent(keyAttributeValue, scalingFactor);
        }

    }
}

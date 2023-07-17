using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeGame.Components.Stats;
namespace SomeGameTests.ComponentTests.StatsTests
{
    [TestFixture]
    public abstract class StatComponentTests<T> where T : StatComponent, new()
    {
        protected T statComponent;
        protected int testReductionAmount;
        protected int testFullDrainAmount;
        protected int testScalingFactor;
        protected int keyAttributeValue;
        protected abstract T CreateStatComponent(int keyAttributeValue, int scalingFactor);

        protected StatComponentTests(int keyAttributeValue, int scalingFactor)
        {
            this.keyAttributeValue = keyAttributeValue;
            this.testScalingFactor = scalingFactor;
            this.testFullDrainAmount = -1 * (new T().Max + 100);
            this.testReductionAmount = -1 * (new T().Max - 3);
            this.statComponent = CreateStatComponent(keyAttributeValue, scalingFactor);
        }
        [SetUp]
        public void SetUp()
        {
            testScalingFactor = 1;

            statComponent = CreateStatComponent(keyAttributeValue, testScalingFactor);
        }

        [Test]
        public void StatComponent_ShouldInitalizeFull()
        {
            T freshStatComponent = CreateStatComponent(keyAttributeValue, testScalingFactor);
            Assert.That(freshStatComponent.Max, Is.EqualTo(freshStatComponent.Current));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(5, 2, 10)]
        [TestCase(5, 3, 15)]
        public void StatComponent_ShouldInitializeWithScaling(int keyAttribute, int scalingFactor, int expectedValue)
        {
            T freshStatComponent = CreateStatComponent(keyAttribute, scalingFactor);

            Assert.That(freshStatComponent.Max, Is.EqualTo(expectedValue));
            Assert.That(freshStatComponent.Current, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(1, 3, 3)]
        [TestCase(1, 4, 4)]
        public void StatComponent_ShouldAllowIncreaseByScalingFactor(int keyAttribute, int newScaleFactor, int expectedValue)
        {
            T freshStatComponent = CreateStatComponent(keyAttribute, testScalingFactor);
            freshStatComponent.ScalingChange(newScaleFactor);
            Assert.That(freshStatComponent.Max, Is.EqualTo(expectedValue));
            Assert.That(freshStatComponent.Max, Is.EqualTo(keyAttribute * newScaleFactor));

        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        public void StatComponent_ShouldBeAbleToIncreaseMaxOnBaseAttributeChange(int keyAttribute, int testScalingFactor)
        {
            T freshStatComponent = CreateStatComponent(keyAttribute, testScalingFactor);
            freshStatComponent.AttributeUpdate(keyAttribute);
            Assert.That(freshStatComponent.Max, Is.EqualTo((keyAttribute * testScalingFactor)));

        }

        [Test]
        public void StatComponent_ShouldNotBringCurrentValueBelowZero()
        {
            statComponent.UpdateCurrent(testFullDrainAmount);
            Assert.That(statComponent.Current, Is.EqualTo(0));
        }
        [Test]
        public void StatComponent_ShouldNotBringCurrentValueAboveMax()
        {
            statComponent.UpdateCurrent(statComponent.Max);
            Assert.That(statComponent.Current, Is.LessThanOrEqualTo(statComponent.Max));
        }

        [Test]
        public void StatComponent_ShouldIndicateWhenEmpty()
        {
            statComponent.UpdateCurrent(testFullDrainAmount);

            Assert.That(statComponent.IsEmpty());
        }

        [Test]
        public void StatComponent_ShouldIndicateWhenNonZero()
        {
            statComponent.UpdateCurrent(testReductionAmount);

            Assert.That(!statComponent.IsEmpty());
        }


    }
}

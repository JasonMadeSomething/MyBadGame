using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeGame.Components.Stats
{
    public abstract class StatComponent
    {
        public int Max { get; protected set; }
        public int Current { get; protected set; }
        public int scaleFactor;

        public StatComponent(int keyAttribute, int scalingFactor)
        {
            Max = keyAttribute * scalingFactor;
            Current = Max;
            scaleFactor = scalingFactor;
        }

        public void UpdateCurrent(int statModifyAmount)
        {
            Current += statModifyAmount;
            if (Current >= Max) Current = Max;
            if (Current <= 0) Current = 0;
        }

        public void ScalingChange(int newScaleFactor)
        {
            Max = (Max / scaleFactor) * newScaleFactor;
        }

        public void AttributeUpdate(int newAttributeValue)
        {
            Max = scaleFactor * newAttributeValue;
        }

        public bool IsEmpty()
        {
            return Current <= 0;
        }
    }
}

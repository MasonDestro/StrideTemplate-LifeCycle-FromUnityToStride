using Stride.Core;
using Stride.Engine;
using Stride.Engine.Design;

namespace Template_LifeCycle.LifeCycle
{
    [DataContract(nameof(MyActivableComponent))]
    [DefaultEntityComponentProcessor(typeof(MyActivableComponentProcessor))]
    public class MyActivableComponent : ActivableEntityComponent
    {
        #region Helper States of Unity MonoBehaviour style Life Cycle

        public bool isDisabledOnAwake;
        public bool isStart;
        public bool isEnableChanged;

        #endregion


    }
}

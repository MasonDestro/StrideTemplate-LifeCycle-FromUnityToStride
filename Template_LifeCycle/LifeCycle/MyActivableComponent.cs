using Stride.Core;
using Stride.Engine;
using Stride.Engine.Design;

namespace Template_LifeCycle.LifeCycle
{
    [AllowMultipleComponents]
    [DataContract(nameof(MyActivableComponent))]
    [DefaultEntityComponentProcessor(typeof(MyActivableComponentProcessor), ExecutionMode = ExecutionMode.Runtime)]
    public class MyActivableComponent : ActivableEntityComponent
    {
        #region Helper States of Unity MonoBehaviour style Life Cycle

        public bool IsDisabledOnAwake;
        public bool IsStart;
        public bool IsEnableChanged;

        #endregion


    }
}

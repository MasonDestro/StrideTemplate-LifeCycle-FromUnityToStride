using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using Stride.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_LifeCycle.LifeCycle
{
    [DataContract(nameof(MyActivableComponent))]
    [DefaultEntityComponentProcessor(typeof(MyActivableComponentProcessor))]
    public class MyActivableComponent : ActivableEntityComponent
    {
        #region States of Unit/MonoBehaviour style Life Cycle

        public bool isStart;
        public bool isEnableChanged;

        #endregion


    }
}

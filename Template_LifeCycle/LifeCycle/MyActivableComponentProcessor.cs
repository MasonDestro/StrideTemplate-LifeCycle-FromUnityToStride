using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Games;
using Stride.Core.Annotations;

namespace Template_LifeCycle.LifeCycle
{
    public class MyActivableComponentProcessor : EntityProcessor<MyActivableComponent>
    {
        //  MonoBehaviour Awake()
        protected override void OnEntityComponentAdding(Entity entity, [NotNull] MyActivableComponent component, [NotNull] MyActivableComponent data)
        {
            data.isStart = true;

            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Info, "Awake"));
        }

        //  MonoBehaviour OnDestroy()
        protected override void OnEntityComponentRemoved(Entity entity, [NotNull] MyActivableComponent component, [NotNull] MyActivableComponent data)
        {
            if (data.Enabled)
            {

                ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnDisable"));
            }


            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Fatal, "OnDestroy"));
        }

        public override void Update(GameTime time)
        {
            foreach (var data in ComponentDatas.Values)
            {
                if (data.isEnableChanged)
                {
                    data.isEnableChanged = false;

                    //  MonoBehaviour OnEnable()
                    if (data.Enabled)
                    {

                        ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnEnable"));
                    }
                    //  MonoBehaviour OnDisable()
                    else
                    {

                        ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnDisable"));
                    }
                }


                if (!data.Enabled)
                {
                    continue;
                }


                //  MonoBehaviour Start()
                if (data.isStart)
                {
                    data.isStart = false;

                    ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Verbose, "Start"));
                }


                //  MonoBehaviour Update()

                ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Debug, "Update"));

            }
        }
    }
}

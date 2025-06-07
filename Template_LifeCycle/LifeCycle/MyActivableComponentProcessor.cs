using Stride.Engine;
using Stride.Games;
using Stride.Core.Annotations;
using Stride.Rendering;

namespace Template_LifeCycle.LifeCycle
{
    public class MyActivableComponentProcessor : EntityProcessor<MyActivableComponent>
    {
        #region Stride ECS

        //  MonoBehaviour Awake()
        protected override void OnEntityComponentAdding(Entity entity, [NotNull] MyActivableComponent component, [NotNull] MyActivableComponent data)
        {
            data.IsStart = true;
            Awake(data);
        }

        //  MonoBehaviour OnDestroy()
        protected override void OnEntityComponentRemoved(Entity entity, [NotNull] MyActivableComponent component, [NotNull] MyActivableComponent data)
        {
            if (data.Enabled)
            {
                OnDisable(data);
            }

            OnDestroy(data);
        }

        public override void Update(GameTime time)
        {
            foreach (var data in ComponentDatas.Values)
            {
                if (data.IsEnableChanged)
                {
                    data.IsEnableChanged = false;

                    //  MonoBehaviour OnEnable()
                    if (data.Enabled)
                    {
                        OnEnable(data);
                    }
                    //  MonoBehaviour OnDisable()
                    else
                    {
                        OnDisable(data);
                    }
                }


                if (!data.Enabled)
                {
                    //  in Unity, add a disabled component will call Awake() then OnEnable() then OnDisable()
                    if (data.IsDisabledOnAwake)
                    {
                        data.IsDisabledOnAwake = false;
                        OnEnable(data);
                        OnDisable(data);
                    }

                    continue;
                }


                //  MonoBehaviour Start()
                if (data.IsStart)
                {
                    data.IsStart = false;
                    Start(data);
                }


                //  MonoBehaviour Update()
                Update(data, time);
            }
        }

        //  MonoBehaviour LateUpdate()
        public override void Draw(RenderContext context)
        {
            foreach (var data in ComponentDatas.Values)
            {
                if (data.Enabled)
                {
                    LateUpdate(data);
                }
            }
        }

        #endregion


        #region Unity MonoBehaviour Simulation

        private static void Awake(MyActivableComponent component)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Info, "Awake"));
        }

        private static void Start(MyActivableComponent component)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Verbose, "Start"));
        }

        private static void Update(MyActivableComponent component, GameTime time)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Debug, "Update"));
        }

        private static void LateUpdate(MyActivableComponent component)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Debug, "LateUpdate"));
        }

        private static void OnDestroy(MyActivableComponent component)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Fatal, "OnDestroy"));
        }

        private static void OnEnable(MyActivableComponent component)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnEnable"));
        }

        private static void OnDisable(MyActivableComponent component)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnDisable"));
        }

        #endregion
    }
}

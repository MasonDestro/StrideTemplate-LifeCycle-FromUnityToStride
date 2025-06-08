using Stride.Games;

namespace Template_LifeCycle.LifeCycle
{
    public class OtherMonoBehaviourScript : MonoBehaviour
    {
        protected override void Awake()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Info, "000"));
        }

        protected override void Start()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Verbose, "111"));
        }

        //protected override void Update(GameTime gameTime)
        //{
        //    ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Debug, "222"));
        //}

        //protected override void LateUpdate()
        //{
        //    ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Debug, "333"));
        //}

        protected override void OnDestroy()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Fatal, "444"));
        }

        protected override void OnEnable()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Warning, "555"));
        }

        protected override void OnDisable()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Warning, "666"));
        }
    }
}

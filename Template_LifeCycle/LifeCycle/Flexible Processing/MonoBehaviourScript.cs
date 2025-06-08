using Stride.Games;

namespace Template_LifeCycle.LifeCycle
{
    public class MonoBehaviourScript : MonoBehaviour
    {
        protected override void Awake()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Info, "Awake"));
        }

        protected override void Start()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Verbose, "Start"));
        }

        protected override void Update(GameTime gameTime)
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Debug, "Update"));
        }

        protected override void LateUpdate()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Debug, "LateUpdate"));
        }

        protected override void OnDestroy()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Fatal, "OnDestroy"));
        }

        protected override void OnEnable()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Warning, "OnEnable"));
        }

        protected override void OnDisable()
        {
            ProcessorLogger.Instance?.LogMessage((ProcessorLogger.LogType.Warning, "OnDisable"));
        }
    }
}

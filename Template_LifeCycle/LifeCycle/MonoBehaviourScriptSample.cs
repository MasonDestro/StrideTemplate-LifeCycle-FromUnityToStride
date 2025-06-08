using Stride.Core;
using Stride.Engine;
using Stride.Games;

namespace Template_LifeCycle.LifeCycle
{
    [DataContract]
    [AllowMultipleComponents]
    public class MonoBehaviourScriptSample : EntityComponent, IMonoBehaviour
    {
        #region Helper States of Unity MonoBehaviour style Life Cycle

        bool _isStart, _isDisabledOnAwake, _isEnableChanged;
        bool IMonoBehaviour.IsStart { get => _isStart; set => _isStart = value; }
        bool IMonoBehaviour.IsDisabledOnAwake { get => _isDisabledOnAwake; set => _isDisabledOnAwake = value; }
        bool IMonoBehaviour.IsEnableChanged { get => _isEnableChanged; set => _isEnableChanged = value; }

        #endregion


        bool _enabled = true;
        //[DataMember(-10)]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _isEnableChanged = _enabled ^ value;
                _enabled = value;
            }
        }



        #region Unity MonoBehaviour Simulation

        void IMonoBehaviour.Awake()
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Info, $"Awake"));
        }

        void IMonoBehaviour.Start()
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Verbose, "Start"));
        }

        void IMonoBehaviour.Update(GameTime gameTime)
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Debug, "Update"));
        }

        void IMonoBehaviour.LateUpdate()
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Debug, "LateUpdate"));
        }

        void IMonoBehaviour.OnDestroy()
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Fatal, "OnDestroy"));
        }

        void IMonoBehaviour.OnEnable()
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnEnable"));
        }

        void IMonoBehaviour.OnDisable()
        {
            ProcessorLogger.Instance.LogMessage((ProcessorLogger.LogType.Warning, "OnDisable"));
        }

        #endregion
    }
}

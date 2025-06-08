using Stride.Engine;
using Stride.Games;

namespace Template_LifeCycle.LifeCycle
{
    [AllowMultipleComponents]
    public class MonoBehaviourScript : StartupScript, IMonoBehaviour
    {
        #region Stride StartupScript
        public override void Start()
        {
            Log.ActivateLog(Stride.Core.Diagnostics.LogMessageType.Debug);
        }
        #endregion



        #region Helper States of Unity MonoBehaviour style Life Cycle

        bool _isStart;
        bool IMonoBehaviour.IsStart { get => _isStart; set => _isStart = value; }

        bool _isDisabledOnAwake, _isEnableChanged;
        public bool IsDisabledOnAwake { get => _isDisabledOnAwake; set => _isDisabledOnAwake = value; }
        public bool IsEnableChanged { get => _isEnableChanged; set => _isEnableChanged = value; }

        #endregion


        bool _enabled = true;
        public bool Enabled { get => _enabled; set => _enabled = value; }



        #region Unity MonoBehaviour Simulation

        void IMonoBehaviour.Awake()
        {
            Log.Info("Awake");
        }

        void IMonoBehaviour.Start()
        {
            Log.Verbose("Start");
        }

        void IMonoBehaviour.Update(GameTime gameTime)
        {
            Log.Debug("Update");
        }

        void IMonoBehaviour.LateUpdate()
        {
            Log.Debug("LateUpdate");
        }

        void IMonoBehaviour.OnDestroy()
        {
            Log.Fatal("OnDestroy");
        }

        void IMonoBehaviour.OnEnable()
        {
            Log.Warning("OnEnable");
        }

        void IMonoBehaviour.OnDisable()
        {
            Log.Warning("OnDisable");
        }

        #endregion
    }
}

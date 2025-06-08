using Stride.Core;
using Stride.Engine;
using Stride.Games;

namespace Template_LifeCycle.LifeCycle
{
    [DataContract("MonoBehaviour", Inherited = true)]
    [ComponentCategory("MonoBehaviour")]
    [AllowMultipleComponents]
    public abstract class MonoBehaviour : EntityComponent, IMonoBehaviour
    {
        #region Helper States of Unity MonoBehaviour style Life Cycle

        bool _isStart, _isDisabledOnAwake, _isEnableChanged;
        bool IMonoBehaviour.IsStart { get => _isStart; set => _isStart = value; }
        bool IMonoBehaviour.IsDisabledOnAwake { get => _isDisabledOnAwake; set => _isDisabledOnAwake = value; }
        bool IMonoBehaviour.IsEnableChanged { get => _isEnableChanged; set => _isEnableChanged = value; }

        #endregion
        #region Unity MonoBehaviour Simulation

        void IMonoBehaviour.Awake() { Awake(); }
        void IMonoBehaviour.Start() { Start(); }
        void IMonoBehaviour.Update(GameTime gameTime) { Update(gameTime); }
        void IMonoBehaviour.LateUpdate() { LateUpdate(); }
        void IMonoBehaviour.OnDestroy() { OnDestroy(); }
        void IMonoBehaviour.OnEnable() { OnEnable(); }
        void IMonoBehaviour.OnDisable() { OnDisable(); }

        #endregion



        bool _enabled = true;
        [DataMember(-10)]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _isEnableChanged = _enabled ^ value;
                _enabled = value;
            }
        }


        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void Update(GameTime gameTime) { }
        protected virtual void LateUpdate() { }
        protected virtual void OnDestroy() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
    }
}

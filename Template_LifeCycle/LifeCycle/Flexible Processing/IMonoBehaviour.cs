using Stride.Core;
using Stride.Engine.FlexibleProcessing;
using Stride.Games;
using Stride.Rendering;
using System.Collections.Generic;

namespace Template_LifeCycle.LifeCycle
{
    public interface IMonoBehaviour : IComponent<IMonoBehaviour.Processor, IMonoBehaviour>
    {
        #region Helper States of Unity MonoBehaviour style Life Cycle

        [DataMemberIgnore]
        bool IsDisabledOnAwake { get; set; }
        [DataMemberIgnore]
        bool IsEnableChanged { get; set; }
        [DataMemberIgnore]
        bool IsStart { get; set; }

        #endregion


        [DataMember(-10)]
        bool Enabled { get; set; }


        #region Unity MonoBehaviour Simulation

        void Awake() { }
        void Start() { }
        void Update(GameTime gameTime) { }
        void LateUpdate() { }
        void OnDestroy() { }
        void OnEnable() { }
        void OnDisable() { }

        #endregion


        public class Processor : IProcessor, IUpdateProcessor, IDrawProcessor
        {
            public List<IMonoBehaviour> Components = new();
            public int Order => 0;


            public void SystemAdded(IServiceRegistry registryParam) { }
            public void SystemRemoved() { }


            //  MonoBehaviour Awake()
            void IProcessor.OnComponentAdded(IMonoBehaviour item)
            {
                Components.Add(item);

                item.IsStart = true;
                item.IsEnableChanged = item.Enabled;
                item.IsDisabledOnAwake = !item.Enabled;
                item.Awake();
            }

            //  MonoBehaviour OnDestroy()
            void IProcessor.OnComponentRemoved(IMonoBehaviour item)
            {
                Components.Remove(item);

                if (item.Enabled)
                {
                    item.OnDisable();
                }

                item.OnDestroy();
            }

            public void Update(GameTime gameTime)
            {
                foreach (var item in Components)
                {
                    if (item.IsEnableChanged)
                    {
                        item.IsEnableChanged = false;

                        //  MonoBehaviour OnEnable()
                        if (item.Enabled)
                        {
                            item.OnEnable();
                        }
                        //  MonoBehaviour OnDisable()
                        else
                        {
                            item.OnDisable();
                        }
                    }

                    if (!item.Enabled)
                    {
                        //  in Unity, add a disabled component will call Awake() then OnEnable() then OnDisable()
                        if (item.IsDisabledOnAwake)
                        {
                            item.IsDisabledOnAwake = false;
                            item.OnEnable();
                            item.OnDisable();
                        }

                        continue;
                    }


                    //  MonoBehaviour Start()
                    if (item.IsStart)
                    {
                        item.IsStart = false;
                        item.Start();
                    }


                    //  MonoBehaviour Update()
                    item.Update(gameTime);
                }
            }

            //  MonoBehaviour LateUpdate()
            public void Draw(RenderContext context)
            {
                foreach (var item in Components)
                {
                    if (item.Enabled)
                    {
                        item.LateUpdate();
                    }
                }
            }
        }
    }
}

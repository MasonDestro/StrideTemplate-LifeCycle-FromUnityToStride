using Stride.Core;
using Stride.Engine;
using Stride.Input;
using System.Collections.Generic;
using System.ComponentModel;

namespace Template_LifeCycle.LifeCycle
{
    public class Test_FlexibleProcessing : SyncScript
    {
        [DataMember(-10)]
        [DefaultValue(true)]
        public virtual bool Enabled { get; set; } = true;

        Entity entt;
        List<MonoBehaviourScriptSample> comList;

        public override void Start()
        {
            if (!Enabled) return;

            Log.ActivateLog(Stride.Core.Diagnostics.LogMessageType.Verbose);
            Log.Verbose("Test Flexible Processing");


            entt = new();
            //SceneSystem.SceneInstance.RootScene.Entities.Add(entt);
            Entity.Scene.Entities.Add(entt);    //  Alternative add entity
            comList = new();
        }

        public override void Update()
        {
            if (!Enabled) return;



            if (Input.HasKeyboard)
            {
                if (Input.IsKeyReleased(Keys.A))
                {
                    //*

                    //  add enabled component
                    //  Awake() -> OnEnable() -> Start()

                    MonoBehaviourScriptSample com = new();
                    entt.Add(com);
                    comList.Add(com);

                    /*/

                    //  add disabled component
                    //  Awake() -> OnEnable() -> OnDisable()

                    MonoBehaviourScriptSample com = new() { Enabled = false };
                    entt.Add(com);
                    comList.Add(com);

                    //*/
                }
                if (Input.IsKeyReleased(Keys.D))
                {
                    //  OnDestroy()
                    //  OnDisable() if component.Enabled == true
                    if (comList.Count > 0)
                    {
                        entt.Remove(comList[^1]);
                        comList.RemoveAt(comList.Count - 1);
                    }
                }
                if (Input.IsKeyReleased(Keys.E))
                {
                    //  OnEnable() or OnDisable()
                    //  Start() if OnEnable() first time
                    foreach (var com in comList)
                    {
                        com.Enabled = !com.Enabled;
                    }
                }
            }
        }
    }
}

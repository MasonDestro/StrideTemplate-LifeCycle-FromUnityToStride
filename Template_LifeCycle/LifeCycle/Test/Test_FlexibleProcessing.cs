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

        List<Entity> enttList;

        public override void Start()
        {
            if (!Enabled) return;

            Log.ActivateLog(Stride.Core.Diagnostics.LogMessageType.Verbose);
            Log.Verbose("Test Flexible Processing");


            enttList = new();
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

                    enttList.Add(new Entity());
                    SceneSystem.SceneInstance.RootScene.Entities.Add(enttList[^1]);
                    MonoBehaviourScript com = new();
                    enttList[^1].Add(com);
                    com.IsEnableChanged = true;

                    /*/

                    //  add disabled component
                    //  Awake() -> OnEnable() -> OnDisable()

                    enttList.Add(new Entity());
                    Entity.Scene.Entities.Add(enttList[^1]);    //  Alternative add entity
                    var com = enttList[^1].GetOrCreate<MonoBehaviourScript>();
                    com.Enabled = false;
                    com.IsDisabledOnAwake = true;

                    //*/
                }
                if (Input.IsKeyReleased(Keys.D))
                {
                    //  OnDestroy()
                    //  OnDisable() if component.Enabled == true
                    if (enttList.Count > 0)
                    {
                        SceneSystem.SceneInstance.RootScene.Entities.Remove(enttList[^1]);
                        //Entity.Scene.Entities.Remove(enttList[^1]);     //  Alternative remove entity
                        enttList.RemoveAt(enttList.Count - 1);
                    }
                }
                if (Input.IsKeyReleased(Keys.E))
                {
                    //  OnEnable() or OnDisable()
                    //  Start() if OnEnable() first time
                    foreach (Entity entt in enttList)
                    {
                        var com = entt.Get<MonoBehaviourScript>();
                        com.Enabled = !com.Enabled;
                        com.IsEnableChanged = true;
                    }
                }
            }
        }
    }
}

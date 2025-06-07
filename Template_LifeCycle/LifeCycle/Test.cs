using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace Template_LifeCycle.LifeCycle
{
    public class Test : SyncScript
    {
        Entity testEntity;
        MyActivableComponent testCom;

        public override void Start()
        {
            testEntity = new();
            SceneSystem.SceneInstance.RootScene.Entities.Add(testEntity);

            Log.Verbose("Test");
        }

        public override void Update()
        {
            if (Input.HasKeyboard)
            {
                if (Input.IsKeyReleased(Keys.A))
                {
                    if (testCom == null)
                    {
                        //  Awake() -> OnEnable() -> Start()
                        testCom = testEntity.GetOrCreate<MyActivableComponent>();
                        testCom.isEnableChanged = true;
                        

                        //  Awake() only
                        //testCom = testEntity.GetOrCreate<MyActivableComponent>();
                        //testCom.Enabled = false;
                    }
                }
                if (Input.IsKeyReleased(Keys.D))
                {
                    //  OnDestroy()
                    //  OnDisable() if component.Enabled == true
                    testEntity.Remove(testCom);
                    testCom = null;
                }
                if (Input.IsKeyReleased(Keys.E))
                {
                    if (testCom != null)
                    {
                        //  OnEnable() or OnDisable()
                        //  Start() if OnEnable() first time
                        testCom.Enabled = !testCom.Enabled;
                        testCom.isEnableChanged = true;
                    }
                }
            }
        }
    }
}

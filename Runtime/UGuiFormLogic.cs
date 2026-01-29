using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace OldAge
{
    public class UGuiFormLogic : UIFormLogic
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            string pureName = gameObject.name.Replace("(Clone)", "");
            
            GameEntry.Data.SaveData(pureName);
        }

        public void Close()
        {
            GameEntry.UI.CloseUIForm(this.UIForm);
        }
    }
}
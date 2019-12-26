using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : Powered
{
    public Light Light1;
   
    public override void OnPowerOutage()
    {
        Light1.enabled = false;
      
        CameraManager.Instance.forcereturn();
        CameraManager.Instance.enabled = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powered : MonoBehaviour
{
    public float wattage = 0.0f;
    public abstract void OnPowerOutage();

    
  
}

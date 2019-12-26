using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public static PowerManager Instance { get; private set; }

    float powerSink = 0.1f;
    public float Charge { get; private set; }
    protected Powered[] poweredObjects;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Charge = 100.0f;
        poweredObjects = FindObjectsOfType<Powered>();
    }

    void OnGUI()
    {
        int info = (int)Charge;
        GUILayout.Label("Battery : "+info.ToString()+" %");
    }
    // Update is called once per frame
    void Update()
    {
        Charge -= powerSink * Time.deltaTime;

        if (Charge <= 0.0f)
        {
            Charge = 0.0f;
            foreach (var poweredItem in poweredObjects)
            {
                poweredItem.OnPowerOutage();
                //GameManager.Instance.GameOver = true;
            }
            this.enabled = false;
        }
    }

    public void UsePower(Powered poweredObject)
    {
        powerSink += poweredObject.wattage;
    }
    public void ReleasePower(Powered poweredObject)
    {
        powerSink -= poweredObject.wattage;
    }
}

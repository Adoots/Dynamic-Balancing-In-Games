using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRight : Powered
{
    public Light Rlight;
    private bool lightson = false;

    public bool Lightson { get => lightson; set => lightson = value; }


    public override void OnPowerOutage()
    {
        if (lightson == true)
        {
            Rlight.enabled = false;
        }
        this.enabled = false;
    }
    void OnMouseDown()
    {
        if (this.enabled == true)
        {
            if (lightson == true)
            {
                // off
                PowerManager.Instance.ReleasePower(this);
                Rlight.enabled = false;
                lightson = false;
                if (StatueManager.Instance.infront == true)
                {
                    StatueManager.Instance.Statue.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                // on
                PowerManager.Instance.UsePower(this);
                Rlight.enabled = true;
                lightson = true;
                if (StatueManager.Instance.infront == true)
                {
                    StatueManager.Instance.Statue.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }
    void OnMouseEnter()
    {
        transform.localScale = new Vector3(0.3f, 0.15f, 0.3f);
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
    }
    // Start is called before the first frame update
    void Start()
    {
        wattage = 0.1f;
        lightson = false;
        Rlight.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoorR : Powered
{
    public float doorHeight = 3.24f;
    public float doorSpeed = 5.0f;
    public Transform door;

    private bool doorInUse = false;
    private bool doorOpen = false;
    public bool DoorOpen { get => doorOpen; set => doorOpen = value; }

    protected Vector3 originalPosition;
    public static SecurityDoorR Instance;

    void OnMouseDown()
    {
        if (!doorInUse)
        {
            if (!doorInUse && this.enabled)
            {
                doorInUse = true;
                if (DoorOpen)

                    StartCoroutine("closeDoor");
                else
                    StartCoroutine("openDoor");
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
    IEnumerator openDoor()
    {
        float amount = 0.0f;
        PowerManager.Instance.ReleasePower(this);
        while (amount < doorHeight)
        {
            amount += doorSpeed * Time.deltaTime;
            door.localPosition = new Vector3(door.localPosition.x, originalPosition.y + amount, door.localPosition.z);
            yield return null;
        }
        door.localPosition = originalPosition + new Vector3(0.0f, doorHeight, 0.0f);
        doorInUse = false;
        DoorOpen = true;
    }
    IEnumerator closeDoor()
    {
        PowerManager.Instance.UsePower(this);
        float amount = doorHeight;

        while (amount > 0.0f)
        {
            amount -= doorSpeed * Time.deltaTime;
            door.localPosition = new Vector3(door.localPosition.x, originalPosition.y + amount, door.localPosition.z);
            yield return null;
        }
        door.localPosition = originalPosition;
        doorInUse = false;
        DoorOpen = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        wattage = 0.5f;
        originalPosition = door.localPosition;
        door.transform.Translate(0.0f, doorHeight, 0.0f);
        DoorOpen = true;
    }
    public override void OnPowerOutage()
    {
        if (DoorOpen == false)
        {
            StartCoroutine("openDoor");
        }

        this.enabled = false;
    }
}

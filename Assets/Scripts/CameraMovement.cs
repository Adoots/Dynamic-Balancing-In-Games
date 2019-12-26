using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;
    private float RotationSensitivity = 30.0f;
    private float minAngle = 135.0f;
    private float maxAngle = 225.0f;
    float xRotate = 0.0f;
    public void forcedreturn()
    {
        transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        this.enabled = false;
    }
    void Start()
    {
        Instance = this;
        
    }
    // Update is called once per frame
    void Update()
    {
        //Rotate X view
        xRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;
        xRotate = Mathf.Clamp(xRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(0.0f, xRotate, 0.0f);


    }
}

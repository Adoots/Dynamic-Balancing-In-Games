using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cameraSecurityRoom;
    public Camera camera1A;
    public Camera camera1B;
    public Camera camera2A;
    public Camera camera2B;
    public static CameraManager Instance;

    protected Camera[] cameras;
    [SerializeField]
    protected int currentCamera;
    [SerializeField]
    private TextMesh IconPlayer;
    [SerializeField]
    private TextMesh Icon1A;
    [SerializeField]
    private TextMesh Icon1B;
    [SerializeField]
    private TextMesh Icon2A;
    [SerializeField]
    private TextMesh Icon2B;

    void Awake()
    {
        cameras = new Camera[5];
        cameras[0] = cameraSecurityRoom;
        cameras[1] = camera1A;
        cameras[2] = camera1B;
        cameras[3] = camera2A;
        cameras[4] = camera2B;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void forcereturn()
    {
        cameras[currentCamera].GetComponent<AudioListener>().enabled = false;
        cameras[currentCamera].enabled = false;

        currentCamera = 0;

        cameras[currentCamera].enabled = true;
        cameras[currentCamera].GetComponent<AudioListener>().enabled = true;

    }
    void incCamera()
    {
        cameras[currentCamera].GetComponent<AudioListener>().enabled = false;
        cameras[currentCamera].enabled=false;

        currentCamera++;
        if (currentCamera >= cameras.Length)
        {
            currentCamera=0;
        }

        cameras[currentCamera].enabled=true;
        cameras[currentCamera].GetComponent<AudioListener>().enabled = true;
    }
    void decCamera()
    {
        cameras[currentCamera].GetComponent<AudioListener>().enabled = false;
        cameras[currentCamera].enabled=false;
        currentCamera--;
        if (currentCamera <0 )
        {
            currentCamera=cameras.Length-1;
        }
        cameras[currentCamera].enabled=true;
        cameras[currentCamera].GetComponent<AudioListener>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.RightArrow))
        {
           
            incCamera();
        }
        if (Input.GetKeyUp (KeyCode.LeftArrow))
        {
            
            decCamera();
        }
        if(currentCamera==0)
        {
            IconPlayer.color = Color.green;
            Icon1A.color = Color.white;
            Icon1B.color = Color.white;
            Icon2A.color = Color.white;
            Icon2B.color = Color.white;
        }
        else if (currentCamera==1)
        {

            IconPlayer.color = Color.white;
            Icon1A.color = Color.green;
            Icon1B.color = Color.white;
            Icon2A.color = Color.white;
            Icon2B.color = Color.white;
        }
        else if(currentCamera==2)
        {
            IconPlayer.color = Color.white;
            Icon1A.color = Color.white;
            Icon1B.color = Color.green;
            Icon2A.color = Color.white;
            Icon2B.color = Color.white;
        }
        else if (currentCamera==3)
        {
            IconPlayer.color = Color.white;
            Icon1A.color = Color.white;
            Icon1B.color = Color.white;
            Icon2A.color = Color.green;
            Icon2B.color = Color.white;
        }
        else if (currentCamera==4)
        {
            IconPlayer.color = Color.white;
            Icon1A.color = Color.white;
            Icon1B.color = Color.white;
            Icon2A.color = Color.white;
            Icon2B.color = Color.green;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueManager : MonoBehaviour
{
    public static StatueManager Instance;
    public GameObject Statue;
    public Transform Nodeleftdoor;
    public Transform Noderightdoor;
    public Transform Node1A;
    public Transform Node1B;
    public Transform Node2A;
    public Transform Node2B;
    public Transform NodePlayer;
    public bool infront=false;
    protected Vector3 originalPosition;

    private float statueHeight;
    private float statueSpeed = 5.0f;
    public int curr;

    IEnumerator Jumpscare()
    {
        statueHeight = NodePlayer.localPosition.y+3.5f;
        float amount = NodePlayer.localPosition.y;
        while (amount < statueHeight)
        {
            amount += statueSpeed * Time.deltaTime;
            NodePlayer.localPosition = new Vector3(NodePlayer.localPosition.x, originalPosition.y + amount, NodePlayer.localPosition.z);
            yield return null;
        }
        
    }
    // Start is called before the first frame update
    public void Movement()
    {
        //notes 0=Player 1=Ldoor 2=Rdoor 3=1A 4=1B 5=2A 6=2B
        int next;
        if (curr == 5)
        {//2A to 1A
            next = 3;
            curr = 4;
            Statue.transform.localPosition = Node1A.localPosition;
            Statue.transform.localRotation = Node1A.localRotation;
        }
        else if (curr == 3)
        {
            float chance = Random.Range(0.0f, 3.0f);
            if (chance < 1.0f)
            {//1A to LeftDoor
                next = 1;
                curr = next;
                Statue.transform.localPosition = Nodeleftdoor.localPosition;
                Statue.transform.localRotation = Nodeleftdoor.localRotation;
                Statue.GetComponent<MeshRenderer>().enabled = false;
                infront = true;
            }
            else if (chance > 2.0f)
            {//1A to 1B
                next = 4;
                curr = next;
                Statue.transform.localPosition = Node1B.localPosition;
                Statue.transform.localRotation = Node1B.localRotation;
            }
            else
            {//1A to 2A
                next = 5;
                curr = next;
                Statue.transform.localPosition = Node2A.localPosition;
                Statue.transform.localRotation = Node2A.localRotation;
            }
        }
        else if (curr == 1)
        {
            if (SecurityDoorL.Instance.DoorOpen == false)
            {//LeftDoor to 1A
                next = 3; curr = next;
                Statue.transform.localPosition = Node1A.localPosition;
                Statue.transform.localRotation = Node1A.localRotation;
                infront = false;
                Statue.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                next = 0;
                curr = next;
                CameraManager.Instance.forcereturn();
                CameraMovement.Instance.forcedreturn();
                NodePlayer.gameObject.SetActive(true);
                StartCoroutine("Jumpscare");
                Statue.transform.localPosition = NodePlayer.localPosition;
                GameManager.Instance.gameover();
            }
        }
        else if (curr == 2)
        {
            if (SecurityDoorR.Instance.DoorOpen == false)
            {//RightDoor to 1B
                next = 4; curr = next;
                Statue.transform.localPosition = Node1B.localPosition;
                Statue.transform.localRotation = Node1B.localRotation;
                infront = false;
                Statue.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                next = 0;
                curr = next;
                CameraManager.Instance.forcereturn();
                CameraMovement.Instance.forcedreturn();
                NodePlayer.gameObject.SetActive(true);
                StartCoroutine("Jumpscare");
                Statue.transform.localPosition = NodePlayer.localPosition;
                GameManager.Instance.gameover();
            }

        }
        else if (curr == 4)
        {
            float chance = Random.Range(0.0f, 3.0f);
            if (chance < 1.0f)
            {//1B to RightDoor
                next = 2;
                curr = next;
                Statue.transform.localPosition = Noderightdoor.localPosition;
                Statue.transform.localRotation = Noderightdoor.localRotation;
                Statue.GetComponent<MeshRenderer>().enabled = false;
                infront = true;
            }
            else if (chance > 2.0f)
            {//1B to 1A
                next = 3;
                curr = next;
                Statue.transform.localPosition = Node1A.localPosition;
                Statue.transform.localRotation = Node1A.localRotation;
            }
            else
            {//1B to 2B
                next = 6;
                curr = next;
                Statue.transform.localPosition = Node2B.localPosition;
                Statue.transform.localRotation = Node2B.localRotation;
            }
        }
        else
        {//2B to 1B
            next = 4;
            curr = next;
            Statue.transform.localPosition = Node1B.localPosition;
            Statue.transform.localRotation = Node1B.localRotation;
        }

    }
    void Start()
    {
        Instance = this;
        NodePlayer.gameObject.SetActive(false);
        float start = Random.Range(0.0f, 1.0f);
        if (start < 0.5f)
        {
            curr = 5; 
            Statue.transform.localPosition = Node2A.localPosition;
            Statue.transform.localRotation = Node2A.localRotation;
        }
        else
        {
            curr = 6;
            Statue.transform.localPosition = Node2B.localPosition;
            Statue.transform.localRotation = Node2B.localRotation;
        }
    }

}

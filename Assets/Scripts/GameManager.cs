using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private int startTime = 0;
    private int endTime = 6;
    public float timer;
    private float levelDuration = 5.0f;
    [SerializeField]
    float actualTime = 0.0f;
    [SerializeField]
    float gameTime = 0.0f;
    [SerializeField]
    private TextMesh gameOverText;

    private void OnGUI()
    {
        int info = 5 - (int)gameTime;
        //GUILayout.Label("Time : " + info.ToString());
        GUI.Label(new Rect(0, 20, 100, 20), "Time Left: " + info.ToString()+ " min");
    }

    public void gameover()
    {
        SecurityDoorL.Instance.enabled = false;
        SecurityDoorR.Instance.enabled = false;
        CameraManager.Instance.enabled = false;
        CameraMovement.Instance.enabled = false;
        PowerManager.Instance.enabled = false;
        gameOverText.gameObject.SetActive(true);
        this.enabled = false;
    }
    public static GameManager Instance;
   
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
       
        gameOverText.gameObject.SetActive(false);

        
    }

    
    
    // Update is called once per frame
    void Update()
    {
       
            timer -= Time.deltaTime;
            if (timer < 0)
            {
            //movestatue
                StatueManager.Instance.Movement();
                timer = Random.Range(10.0f, 20.0f);
            }
            actualTime += Time.deltaTime;
            gameTime = (actualTime / (levelDuration * 60.0f)) * (endTime - startTime);

            
            if (gameTime >= levelDuration)
            {
                this.enabled = false;
                SecurityDoorL.Instance.enabled = false;
                SecurityDoorR.Instance.enabled = false;
                CameraManager.Instance.enabled = false;
                CameraMovement.Instance.enabled = false;
                PowerManager.Instance.enabled = false;
                this.enabled = false;
            }
        }
    
}

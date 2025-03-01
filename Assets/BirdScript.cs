using UnityEngine;

public class BirdScript : MonoBehaviour
{
    AudioManager audioManager;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private float top;
    private float bottom;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        float screenHeight = Camera.main.orthographicSize;
        top = screenHeight;
        bottom = -screenHeight;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)== true && birdIsAlive == true){
             myRigidbody.linearVelocity = Vector2.up * flapStrength;
             audioManager.playSFX(audioManager.flap);
        }
       
        if(transform.position.y > top || transform.position.y < bottom){
              audioManager.playSFX(audioManager.hit);
            logic.gameOver();
            birdIsAlive = false;
    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       logic.gameOver(); 
       birdIsAlive = false;
    
    }
}

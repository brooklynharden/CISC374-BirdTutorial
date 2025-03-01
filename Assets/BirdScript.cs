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
        //when the space button is pressed the bird flaps/flies
        if(Input.GetKeyDown(KeyCode.Space)== true && birdIsAlive == true){
             myRigidbody.linearVelocity = Vector2.up * flapStrength;
             audioManager.playSFX(audioManager.flap);
        }
       //this ensures that if the bird is out of bounds the game ends
        if(transform.position.y > top || transform.position.y < bottom){
              audioManager.playSFX(audioManager.hit);
            logic.gameOver();
            birdIsAlive = false;
    
        }
    }

    //If the bird collides with the pipes or vice versa the game will end
    private void OnCollisionEnter2D(Collision2D collision)
    {
       logic.gameOver(); 
       birdIsAlive = false;
    
    }
}

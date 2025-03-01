using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        //When the game starts the title screen is active 
        titleScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // When player pushes the 'start' button the title screen will go away
    // Update is called once per frame
    public void StartGame(){
        titleScreen.SetActive(false);
        Time.timeScale = 1;
    }
    
}

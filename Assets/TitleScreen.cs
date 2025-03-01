using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        titleScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void StartGame(){
        titleScreen.SetActive(false);
        Time.timeScale = 1;
    }
    
}

using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
     [SerializeField] AudioSource SFXSource;

    [Header("-------- SFX Source ---------")]
    public AudioClip background;
    public AudioClip flap;
    public AudioClip playAgain;

    public AudioClip pointCheck;
    public AudioClip hit;
    public AudioClip over;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}

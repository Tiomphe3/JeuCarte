using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager Instance;

    public AudioSource src;
    public AudioClip jumpSound;
    public AudioClip backSound;




    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log($"Setting Instance to {this}");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        //if (jumpSound == null || backSound == null)
        //{
          //  Debug.LogError("Les sources audio ne sont pas assignées !");
        //}
    }

    public void ChangeSoundTrack(AudioClip myClip)
    {
        src.clip = myClip;
        src.Play();
    }

    public void playJumpSound () {
        src.clip = jumpSound;
        src.Play();
    }
    public void PlayBackgroundSound()
    {
        src.clip = backSound;
        src.Play();
    }
}
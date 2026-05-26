using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip powerUpClip;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip winClip;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayBackgroundMusic();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBackgroundMusic(){
        if(audioSource && backgroundMusic){
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void PlayJumpSound(){
        if(effectSource && jumpClip){
            effectSource.PlayOneShot(jumpClip);
        }
    }
    public void PlayCoinSound(){
        if(effectSource && coinClip){
            effectSource.PlayOneShot(coinClip);
        }
    }
    public void PlayPowerUpSound(){
        if(effectSource && powerUpClip){
            effectSource.PlayOneShot(powerUpClip);
        }
    }
    public void PlayGameOverSound(){
        if(effectSource && gameOverClip){
            effectSource.PlayOneShot(gameOverClip);
        }
    }
    public void PlayWinSound(){
        if(effectSource && winClip){
            effectSource.PlayOneShot(winClip);
        }
    }
}

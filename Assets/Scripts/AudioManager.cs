using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Music")]    
    public AudioSource musicSource;
    public AudioSource soundsSource;

    [Header("Sound Effects")]  
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    public AudioClip spawnSkull;
    public AudioClip collectStar;
    public AudioClip playerDeath;
    public AudioClip scorePoint;

    public static AudioManager instance;


    private void Awake(){

        if(instance == null){

            instance = this;
            DontDestroyOnLoad(gameObject);

        }else{

            Destroy(gameObject);

        }

    }
    public void PlayMusic(AudioClip musicClip){

        if(musicSource != null && musicClip != null){

            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();

        }

    }

    public void PlaySoundEffects(AudioClip soundClip){

        if(soundsSource != null && soundClip != null){

            soundsSource.pitch = UnityEngine.Random.Range(1f, 1.3f);
            soundsSource.PlayOneShot(soundClip);

        }

    }

    public void StopMusic(){

        if(musicSource != null){

            musicSource.Stop();

        }

    }

}

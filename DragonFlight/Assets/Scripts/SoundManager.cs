using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;
    public AudioClip SoundBullet;
    public AudioClip soundDie;

    private void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(SoundBullet);
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }

}

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, dash, coin, lose, progress;
    static AudioSource audioSrc;

    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        dash = Resources.Load<AudioClip>("dash");
        coin = Resources.Load<AudioClip>("coin");
        lose = Resources.Load<AudioClip>("lose");
        progress = Resources.Load<AudioClip>("progress");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "dash":
                audioSrc.PlayOneShot(dash);
                break;
            case "coin":
                audioSrc.PlayOneShot(coin);
                break;
            case "lose":
                audioSrc.PlayOneShot(lose);
                break;
            case "progress":
                audioSrc.PlayOneShot(progress);
                break;
        }
    }
}
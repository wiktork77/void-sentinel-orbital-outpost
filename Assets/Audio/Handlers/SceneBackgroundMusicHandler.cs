using UnityEngine;

public class SceneBackgroundMusicHandler : MonoBehaviour
{
    [Header("Ustawienia")]
    public AudioSource musicSource;
    public AudioClip backgroundMusicClip;
    public float delay = 0.5f;

    void Start()
    {
        if (musicSource != null && backgroundMusicClip != null)
        {
            musicSource.clip = backgroundMusicClip;

            musicSource.PlayDelayed(delay);
        }
        else
        {
            Debug.LogWarning("Brak przypisanego AudioSource lub klipu muzycznego!");
        }
    }
}
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public AudioClip FoodSound;
    public AudioClip DestroySound;
    public AudioClip BackgroundSound;

    [Min(0)]
    public float Volume;

    private AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        Audio.Play();
    }

    public void TakeFoodAudio()
    {
        Audio.PlayOneShot(FoodSound, Volume);
    }

    public void DestroyBlock()
    {
        Audio.PlayOneShot(DestroySound);
    }

    private void OnEnable()
    {
        Audio.PlayOneShot(BackgroundSound);
    }

    private void OnDisable()
    {
        Audio.Stop();
    }
    private void OnDestroy()
    {
        Audio.Stop();
    }
}

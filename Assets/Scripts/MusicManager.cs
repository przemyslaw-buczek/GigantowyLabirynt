using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    int currentClipIndex = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.time >= clips[currentClipIndex].length)
        {
            currentClipIndex++;

            if (currentClipIndex >= clips.Length)
            {
                currentClipIndex = 0;
            }

            audioSource.clip = clips[currentClipIndex];
            audioSource.Play();
        }
    }
}

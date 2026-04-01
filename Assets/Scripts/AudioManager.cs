using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource player;
    [SerializeField] private AudioClip clip;

    public void PlayClick()
    {
        player.clip = clip;
        player.Play();
    }
}

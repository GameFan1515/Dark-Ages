using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obt�m o AudioSource anexado ao GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource n�o encontrado! Adicione um AudioSource ao GameObject.");
        }
    }

    public void PlayButtonSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public AudioSource audio_;

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume")) audio_.volume = 1;
    }
    private void Update()
    {
        audio_.volume = PlayerPrefs.GetFloat("volume");

    }
}

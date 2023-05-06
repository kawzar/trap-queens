using FMODUnity;
using UnityEngine;

namespace Queens.Managers
{
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
}
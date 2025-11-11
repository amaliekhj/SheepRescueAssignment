using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // This is a public static variable, so it can be accessed from any other script. It stores a reference to a SoundManager component.

    public AudioClip shootClip; // A reference to an AudioClip containing the hay shooting sound effect.
    public AudioClip sheepHitClip; // Reference to the sound effect for when a sheep gets hit by hay.

    public AudioClip sheepDroppedClip; // A reference to the sound a sheep makes when it drops off the edge.

    private Vector3 cameraPosition; // The cached position of the camera.    

    void Awake()
    {
        Instance = this; // Cache this script inside the Instance variable.
        cameraPosition = Camera.main.transform.position; // Cache the position of the main camera (the camera with a MainCamera tag).
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip clip) // This method accepts an AudioClip to play.
    {
    AudioSource.PlayClipAtPoint(clip, cameraPosition); // Create a temporary AudioSource that plays the audio clip that was passed as a parameter at the location of the camera.

    }
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}

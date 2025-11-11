using UnityEngine;

public class DestroyOnEnter : MonoBehaviour
{
    // This function is automatically called by Unity's physics engine
    // whenever another collider enters the trigger zone.
    private void OnTriggerEnter(Collider other)
    {
        // We check if the object that entered has the "Character" tag.
        // This is important so it doesn't accidentally destroy sheep or hay bales.
        if (other.CompareTag("Character"))
        {
            // If it's a character, we destroy its GameObject.
            Destroy(other.gameObject);
        }
    }
}
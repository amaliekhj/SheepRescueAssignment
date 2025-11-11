using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;

    // We no longer need the angel prefab variable here,
    // because the GameStateManager is handling it.

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check for hitting a Sheep (This is unchanged)
        if (other.CompareTag("Sheep"))
        {
            GameStateManager.Instance.SavedSheep();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // 2. MODIFIED: Check for hitting a Character
        else if (other.CompareTag("Character"))
        {
            // --- THIS IS THE NEW LOGIC ---
            // Tell the GameStateManager to start the sequence,
            // passing along the character's position for the angel spawn.
            GameStateManager.Instance.InitiateGameOverSequence(other.transform.position);

            // Destroy the character and the hay bale immediately.
            // The GameStateManager will handle the rest.
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // 3. Original logic for the boundary (This is unchanged)
        else if (other.CompareTag(tagFilter))
        {
            Destroy(gameObject);
        }
    }
}
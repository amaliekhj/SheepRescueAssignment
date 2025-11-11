using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // <-- IMPORTANT: Add this line to use Coroutines

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    // --- ADD THIS LINE AT THE TOP ---
    public GameObject angelPrefab; // Reference to the angel prefab

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    // --- THIS IS THE NEW PUBLIC METHOD THE HAY BALE WILL CALL ---
    public void InitiateGameOverSequence(Vector3 spawnPosition)
    {
        // We start the coroutine here, on the GameStateManager which will not be destroyed.
        StartCoroutine(GameOverRoutine(spawnPosition));
    }

    // --- THIS IS THE NEW COROUTINE THAT HANDLES THE DELAY ---
    private IEnumerator GameOverRoutine(Vector3 spawnPosition)
    {
        // 1. Spawn the angel at the position where the character was hit
        if (angelPrefab != null)
        {
            Instantiate(angelPrefab, spawnPosition, Quaternion.identity);
        }

        // 2. Wait for a short delay (e.g., 2 seconds)
        yield return new WaitForSeconds(2.0f);

        // 3. Now, call the original GameOver logic
        GameOver();
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    // Make sure this is public so the coroutine can call it!
    public void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
}
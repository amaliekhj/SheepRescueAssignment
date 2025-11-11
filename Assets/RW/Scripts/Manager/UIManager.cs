using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // A reference to this UI Manager.

    public Text sheepSavedText; // Cached reference to the Text component of DroppedSheepText.
    public Text sheepDroppedText; // This references the Text component of SavedSheepText.
    public GameObject gameOverWindow; // Reference to the Game Over Window.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }
    public void UpdateSheepSaved() // Get the amount of sheep saved from the Game State Manager, convert it to a string and use it to set the text of sheepSavedText.
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() // Same as the other method, but use the amount of sheep dropped instead.
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow() //This activates the Game Over Window, so it becomes visible.


    {
        gameOverWindow.SetActive(true);
    }
}

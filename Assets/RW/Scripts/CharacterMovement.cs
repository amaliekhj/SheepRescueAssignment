using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust the speed as needed

    void Update()
    {
        // Move the character forward along its z-axis
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
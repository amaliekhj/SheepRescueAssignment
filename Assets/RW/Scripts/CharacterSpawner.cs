using System.Collections;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject characterPrefab;
    public float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnCharacter", 2f, spawnInterval);
    }

    void SpawnCharacter()
    {
        if (characterPrefab != null)
        {
            // This now uses the mill's rotation when creating the character
            Instantiate(characterPrefab, transform.position, transform.rotation);
        }
    }
}
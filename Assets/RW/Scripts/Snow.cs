using UnityEngine;

public class Snow : MonoBehaviour
{
    public GameObject snowPrefab;    // Your snow quad/cube
    public float spawnRate = 10f;    
    public float spawnHeight = 10f;  
    public int snowPerTick = 5;      
    public float initialDelay = 5f; // Delay before spawning snowPrefab

    private float timer = 0f;
    private float delayTimer = 0f;
    private bool startSpawning = false;

    void Update()
    {
        // Count up the delay timer
        if (!startSpawning)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= initialDelay)
            {
                startSpawning = true;
            }
            else
            {
                return; // Skip spawning until delay is over
            }
        }

        timer += Time.deltaTime;

        if (timer >= 1f / spawnRate)
        {
            timer = 0f;

            for (int i = 0; i < snowPerTick; i++)
            {
                Vector3 spawnPos = transform.position + new Vector3(
                    Random.Range(-50f, 50f),
                    spawnHeight,
                    Random.Range(-50f, 50f)
                );

                RaycastHit hit;
                if (Physics.Raycast(spawnPos, Vector3.down, out hit, spawnHeight + 20f))
                {
                    Instantiate(snowPrefab, hit.point + Vector3.up * 0.01f, Quaternion.Euler(90, Random.Range(0, 360), 0));
                }
            }
        }
    }
}
using UnityEngine;

public class AngelBehavior : MonoBehaviour
{
    public float moveSpeed = 2.0f;     // How fast the angel flies up
    public float scaleSpeed = 0.5f;    // How fast the angel shrinks
    public float lifeTime = 3.0f;      // How long before the angel disappears

    void Start()
    {
        // Tell Unity to destroy this angel GameObject after 'lifeTime' seconds
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // --- Move the angel upwards ---
        // Vector3.up is a shortcut for (0, 1, 0)
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // --- Shrink the angel ---
        // Vector3.one is a shortcut for (1, 1, 1). This shrinks it uniformly.
        transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
    }
}
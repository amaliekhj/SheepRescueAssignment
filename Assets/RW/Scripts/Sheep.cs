using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay;

    private Collider myCollider;
    private Rigidbody myRigidbody;

    private SheepSpawner sheepSpawner; 

    public float heartOffset; // The offset in the Y axis where the heart will spawn.
    public GameObject heartPrefab; // This holds a reference to the Heart prefab you just made.

    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    public void SetSpawner(SheepSpawner spawner) 
    {
        sheepSpawner = spawner;
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject); 
        hitByHay = true;
        runSpeed = 0;

        Destroy(gameObject, gotHayDestroyDelay);

        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity); //This line creates a new heart and positions it above the sheep, with heartOffset added to the Y position.
        
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();; // Add a TweenScale component to the GameObject this script is attached to and put a reference to it in a tweenScale variable.
        tweenScale.targetScale = 0; // Set the target scale of TweenScale to 0 so the sheep shrinks down all the way.
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // Set the time that TweenScale will take to the same time it takes to destroy the sheep.

        SoundManager.Instance.PlaySheepHitClip(); //plays a soundclip from SondManager

        GameStateManager.Instance.SavedSheep(); //This tells the manager that a sheep was saved.



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

    private void Drop()
    {
        GameStateManager.Instance.DroppedSheep(); //With this line, the manager gets notified that a sheep was dropped.
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
        SoundManager.Instance.PlaySheepDroppedClip(); // Plays a sound from soundmanager
    }
}
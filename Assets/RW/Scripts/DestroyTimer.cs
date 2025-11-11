using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{   
    public float timeToDestroy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }
}

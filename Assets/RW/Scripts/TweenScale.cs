using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale; // The final scale. This value will be applied on all axes.
    public float timeToReachTarget; // The time in seconds it will take to reach the target scale.
    private float startScale;  // This is the scale of the GameObject at the moment this script is activated.
    private float percentScaled; // A percent that’s between 0.0 and 1.0, this value will be incremented and used in calculations to change the scale from the starting value to the target value.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = transform.localScale.x; //Here, you get the value of the scale in the X-axis and store it in startScale.
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) // If the percent scaled isn't 1 (100%)...
        {
            percentScaled += Time.deltaTime / timeToReachTarget; // Add the time between this frame and the previous one, divided by the amount of seconds needed to reach the final value.
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // Create a temporary variable named scale and store the lerped value of the scale inside.
            transform.localScale = new Vector3(scale, scale, scale); // Get the scale value from the lerp and apply it to the transform on all axes.
        }
    }
}

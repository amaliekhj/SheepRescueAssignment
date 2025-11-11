using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 movementSpeed; //The speed in meters per second the attached GameObject will move in on the X, Y and Z axes.
    public Space space; //The space the movement will take place in, either World or Self. The World space transforms a GameObject in Unity's world space, ignoring the rotation of the GameObject, while Self considers the rotation of the GameObject in its calculations.

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}

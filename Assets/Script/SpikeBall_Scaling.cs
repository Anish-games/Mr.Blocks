using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpikeBall_Scaling : MonoBehaviour
{
    //rotation variables
    public float rotationAngle = 90f; // Controls how fast the spike ball rotates.

    //scaling variables
    private float scalingFactor = 1f; // Determines the direction of scaling (positive for growing, negative for shrinking).
    private float currentScale;       // Keeps track of the spike ball's current scale.
    public float scalingSpeed = 15f;  // Controls how fast the spike ball scales
    public float minScale = 0.5f;     // Define the limits for scaling.
    public float maxScale = 1.5f;

    //delay variables
    public float scaleDelay = 2f;   // Specifies how long the spike ball should pause at the extremes before changing direction.
    private float timer = 0f;       // Keeps track of the time elapsed during the pause.
    private bool isWaiting = false; // Indicates whether the spike ball is currently pausing.

    private void Start()
    {
        currentScale = minScale;  // Sets the initial scale of the spike ball to minScale
        ApplyCurrentScale();      // Calls ApplyCurrentScale() to update the spike ball's size.
    }
    private void Update()
    {
        RotateSpikeBall();    // Calls RotateSpikeBall() to rotate the spike ball.
        if (isWaiting)        // Checks if the spike ball is in a waiting state (isWaiting): 
            HandleWaiting();  // If true, calls HandleWaiting() to manage the waiting period.
        else
            ScaleSpikeBall(); // If false, calls ScaleSpikeBall() to adjust the spike ball's scale.
    }

    private void RotateSpikeBall() // Rotates the spike ball around the Z-axis at the rate of rotationAngle degrees per second.
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    private void ScaleSpikeBall()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime; // Adjusts the spike ball's scale based on scalingFactor and scalingSpeed
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);  // Checks if currentScale has reached maxScale or minScale
        if (currentScale >= maxScale || currentScale <= minScale)      // Checks if currentScale has reached maxScale or minScale:
        {
            scalingFactor = -scalingFactor; // If true, reverses the scalingFactor (changes the scaling direction)
            isWaiting = true;               // and sets isWaiting to true.
        } 
        ApplyCurrentScale();                // Calls ApplyCurrentScale() to update the spike ball's size.
    }

    private void ApplyCurrentScale()        // Updates the spike ball's scale on the X and Y axes using currentScale.
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }

    private void HandleWaiting() 
    {
        timer += Time.deltaTime; // Increments the timer by the time elapsed since the last frame (Time.deltaTime).
        if (timer >= scaleDelay)
        {
            isWaiting = false;
            timer = 0f;         // Checks if the timer has reached scaleDelay:  If true, sets isWaiting to false and resets timer to 0.


        }
    }
}
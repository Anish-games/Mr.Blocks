using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall_Wating_Patrolling : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    //delay variables
    public float scaleDelay = 2f;   // Specifies how long the spike ball should pause at the extremes before changing direction.
    private float timer = 0f;       // Keeps track of the time elapsed during the pause.
    private bool isWaiting = false; // Indicates whether the spike ball is currently pausing.


    private void Start() => SetPatrolPoints();
    private void Update()
    {
        RotateSpikeBall();
        if (isWaiting )
            HandleWaiting();
        else
        PatrolSpikeBall();
    }
    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }
    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
            isWaiting = true;
        }
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
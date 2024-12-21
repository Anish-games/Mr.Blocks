using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;

    public float speed;

    private void Update()
    {
        GetInput();
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

       // Debug.Log($"Horizontal: {horizontalInput}, Vertical: {verticalInput}");
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        moveDirection = moveDirection.normalized * speed * Time.deltaTime;
        transform.position += moveDirection; 
    }
}

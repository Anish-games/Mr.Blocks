using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LevelManager levelManager; 
    private float horizontalInput, verticalInput;
    private Rigidbody2D rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //This code finds the Rigidbody2D component on the same GameObject and stores a reference to it in the rb variable.
    }
    private void Update()
    {
        GetInput();
        MovePlayer();
    }
    private void FixedUpdate() => MovePlayer(); //FixedUpdate : An Event function called at a fixed time interval, independent of frame rate.
                                                //It's perfect for physics calculations because it keeps them consistent, even if your game's frame rate varies. 

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Debug.Log($"Horizontal: {horizontalInput}, Vertical: {verticalInput}");
    }

    private void MovePlayer() //Velocity: "The speed and direction of an object's movement. In 2D games, it's represented as a Vector2 (x and y components).”
    {
        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity; ;
    }
    private void OnCollisionEnter2D(Collision2D other) // OnCollisionEnter2D is called when the Player game object collides with any other game object.
    {
        if (other.gameObject.CompareTag("Obstacle"))  // Collision2D other: This provides information about another game object that has collided with the Player game object.
        {
            Debug.Log(gameObject.name + " Collided with: " + other.gameObject.name);
            PlayerDie();             // other.gameObject.name: This gives you the name of the other object involved in the interaction.
        }
    }
    private void OnTriggerEnter2D(Collider2D other)  // Trigger & collider.
    {
        if (other.gameObject.CompareTag("Finish"))    // finishing the level.
        {
            LevelComplete();
        }
    }


    private void PlayerDie()
    {
        levelManager.OnPlayerDeath();
        Destroy(gameObject);
    }

    
    private void LevelComplete()
    {
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }


}

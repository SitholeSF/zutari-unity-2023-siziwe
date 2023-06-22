using System.Collections;
using System.Collections.Generic;using UnityEngine;
using UnityEngine.UI; 

public class CubeMovement : MonoBehaviour
{

    public float moveSpeed = 2f; //Initializing a speed

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //left and right
        float moveVertical = Input.GetAxis("Vertical"); //up and down

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f );
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Increase speed when the "V"  key is pressed
        if (Input.GetKeyDown(KeyCode.V))
        {
            moveSpeed += 1f;
        }

        // Decrease speed when the "B"  key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            moveSpeed -= 1f;
            if (moveSpeed < 0f) moveSpeed = 0f;  // To ensure speed doesn't go below zero
        }

        // Moving the object based on the current speed
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}
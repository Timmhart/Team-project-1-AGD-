using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    private bool isFrozen_Player1 = false;
    private bool isFrozen_Player2 = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gameObject.name == "Player1")
            {
                isFrozen_Player1 = !isFrozen_Player1;
            }
            else if (gameObject.name == "Player2")
            {
                isFrozen_Player2 = !isFrozen_Player2;
            }
        }

        if (gameObject.name == "Player1" && isFrozen_Player1)
        {
            rb.velocity = Vector2.zero;
        }
        else if (gameObject.name == "Player2" && isFrozen_Player2)
        {
            rb.velocity = Vector2.zero; 
        }
        else
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void FixedUpdate()
    {
        if (gameObject.name == "Player1" && !isFrozen_Player1)
        {
            // Get the direction to look towards (i.e. the mouse position)
            Vector2 lookDir1 = mousePos - rb.position;
            float angle1 = Mathf.Atan2(lookDir1.y, lookDir1.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle1;

            // Calculate the movement vector based on the look direction and the "W" key input
            Vector2 movement_Player1 = lookDir1.normalized * Input.GetAxisRaw("Vertical_Player1");

            // Move player 1 based on the movement vector
            rb.MovePosition(rb.position + movement_Player1 * moveSpeed * Time.fixedDeltaTime);
        }
        else if (gameObject.name == "Player2" && !isFrozen_Player2)
        {
            // Get the direction to look towards (i.e. the mouse position)
            Vector2 lookDir2 = mousePos - rb.position;
            float angle2 = Mathf.Atan2(lookDir2.y, lookDir2.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle2;

            // Calculate the movement vector based on the look direction and the "W" key input
            Vector2 movement_Player2 = lookDir2.normalized * Input.GetAxisRaw("Vertical_Player2");

            // Move player 2 based on the movement vector
            rb.MovePosition(rb.position + movement_Player2 * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
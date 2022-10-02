using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Joystick
Name: Chloe Ma 
Student #: 101260013
Date last modified: 02/10/22
Description: Enables joystick control and player movement.
 */
public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform innerJoystick;
    public Transform joystickBorder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // setting point A to the touch position in the world view
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            innerJoystick.transform.position = pointA;
            joystickBorder.transform.position = pointA;

            innerJoystick.GetComponent<SpriteRenderer>().enabled = true;
            joystickBorder.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            // setting point B to the touch position in the world view
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            // calculates the offset between point B and point A
            Vector2 offset = pointB - pointA;
            // use clamp to calculate direction
            Vector2 dir = Vector2.ClampMagnitude(offset, 1.0f);
            movePlayer(dir);

            innerJoystick.transform.position = new Vector2(pointA.x + dir.x, pointA.y + dir.y);
        }
        else
        {
            innerJoystick.GetComponent<SpriteRenderer>().enabled = false;
            joystickBorder.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void movePlayer(Vector2 dir)
    {
        player.Translate(dir * speed * Time.deltaTime);
    }
}

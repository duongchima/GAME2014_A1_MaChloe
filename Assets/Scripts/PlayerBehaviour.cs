using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 startPosition;
    private bool usingMobileInput;
    private Camera camera;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                         Application.platform == RuntimePlatform.IPhonePlayer;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
            MobileInput();
        else
        KeyboardInput();
    }

   void KeyboardInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.position += new Vector3(x, y, 0.0f);
    }
    void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
        }
    }
}

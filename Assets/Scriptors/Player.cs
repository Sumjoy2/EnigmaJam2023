using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    float horizontal;
    float vertical;
    float mouseY;
    float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Character Movemnt
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        Vector3 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.z = position.z + speed * vertical * Time.deltaTime;
        transform.position = position;

        //Camera Movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector2 mouseMove = new Vector2(mouseX, mouseY);

    }
}

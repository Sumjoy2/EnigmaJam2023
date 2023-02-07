using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);

        Vector3 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.z = position.z + speed * vertical * Time.deltaTime;
        transform.position = position;

    }
}

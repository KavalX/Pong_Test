using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    Transform PlatformTransform;
    [SerializeField]
    int speed;

    [SerializeField]
    float minY = 12f;
    [SerializeField]
    float maxY = -12f;

    public bool isPaddle1;



    void Awake()
    {
        // Obtener la referencia al prefab de la bola


        PlatformTransform = GetComponent<Transform>();
    }

    private void Update()
    {

    }
    void FixedUpdate()
    {

        if (isPaddle1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                PlatformTransform.Translate(Vector2.up * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                PlatformTransform.Translate(Vector2.down * speed * Time.deltaTime);
            }


        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlatformTransform.Translate(Vector2.up * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.S))
            {
                PlatformTransform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }

        if (transform.position.y < maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }

        if (transform.position.y > minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }
        
       
}



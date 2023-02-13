using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movSpeed;
    float rotSpeed = 10f;
    private void Start()
    {
        movSpeed = 4f;
    }
    private void Update()
    {
        Vector2 Dir = new Vector2(0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            Dir.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Dir.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Dir.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Dir.x += 1;

        }

        Vector3 movDir = new Vector3(Dir.x, 0f, Dir.y);
        movDir = movDir.normalized;
        transform.position += movDir * movSpeed * Time.deltaTime;
        transform.forward += Vector3.Slerp(transform.forward, movDir, Time.deltaTime * rotSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    public Vector3 MovementNormalized()
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
        
       return movDir = movDir.normalized;
    }
}

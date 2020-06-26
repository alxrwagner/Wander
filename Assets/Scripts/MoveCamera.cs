using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Camera MainCamera;
    public int Speed;
    void Start()
    {
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += gameObject.transform.right * Speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position -= gameObject.transform.right * Speed * Time.fixedDeltaTime;
        }
      
    }
}

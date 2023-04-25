using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float velocityMovement;

    private AudioSource audio;

    public AudioClip audioJump;

    public float segIncrement;
    
    [SerializeField]
    private float forwardSpeed = 1.0f;
    
    private float minX = -15f;
    private float maxX = 15f;

    private float timeActual;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeActual -= 1f; 
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * (velocityMovement * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * (velocityMovement * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            velocityMovement += 0.01f;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            if(velocityMovement>1)
                velocityMovement -= 0.01f;
        }
        
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
        
        if (timeActual <= 0)
        {
            velocityMovement += 1;
            timeActual = segIncrement*60;
        }
    }
    
    private void FixedUpdate()
    {
        var direction = Quaternion.Euler(0, 0, 0) * Vector3.up;
        transform.position += direction * (velocityMovement * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float _movementSpeed = 8f;

    void Start()
    {
        
    }

    void Update()
    {
        CalculateMovement();
        DestroyObjectIfNeeded();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.up * _movementSpeed * Time.deltaTime);
    }

    void DestroyObjectIfNeeded()
    {
        if (transform.position.y >= 7f)
        {
            if (this.transform.parent != null)
            {
                Destroy(this.transform.parent.gameObject);
            }   
            Destroy(this.gameObject);
        }
    }
}

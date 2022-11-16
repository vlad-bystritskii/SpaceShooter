using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _startYPosition = 6f;
    private float _endYPosition = -6f;
    private float _xBounds = 8f;
    [SerializeField]
    private float _speed = 4.0f;

    void Start()
    {
        
    }

    void Update()
    {
        CalculateMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        } 
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void CalculateMovement() 
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= _endYPosition)
        {
           MoveToStartPosition();
        }
    }

    void MoveToStartPosition()
    {
        float randomX = Random.Range(_xBounds * -1f, _xBounds);
        transform.position = new Vector3(randomX, _startYPosition, 0);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private float _endYPosition = -7f;

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
                player.ActivateTripleShotPowerup();
            }

            Destroy(this.gameObject);
        } 
    }
    
    void CalculateMovement() 
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= _endYPosition)
        {
           Destroy(this.gameObject);
        }
    }

}

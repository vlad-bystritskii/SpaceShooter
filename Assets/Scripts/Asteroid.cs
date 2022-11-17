using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _rotateSpeed = 19f;
    private float _startYPosition = 7.5f;
    private float _endYPosition = -7.5f;
    private float _xBounds = 8f;
    private Player _player;
    private Animator _animator;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _animator = GetComponent<Animator>();

        if (_player == null)
        {
            Debug.LogError("Player is NULL");
        }
        if (_animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
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
            if (player != null) player.Damage();

            _animator.SetTrigger("OnAsteroidDead");
            _speed = 0;
            _rotateSpeed = 0;
            Destroy(this.gameObject, 2.633f);
        } 
        else if (other.tag == "Laser")
        {
            if (_player != null) _player.IncrementScore(Random.Range(1,15));

            _animator.SetTrigger("OnAsteroidDead");
            Destroy(other.gameObject);
            _speed = 0;
            _rotateSpeed = 0;
            Destroy(this.gameObject, 2.633f);
        }
    }

    void CalculateMovement() 
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

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

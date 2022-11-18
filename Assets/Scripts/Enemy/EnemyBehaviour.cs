using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _isDead = false; 
    private float _xBounds = 8f;
    private float _startYPosition = 6f;
    public float speed = 4.0f;
    public Animator animator;
    private Player _player;
    private AudioSource _audioSource;

    public void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        if (_player == null)
        {
            Debug.LogError("Player is NULL");
        }
        if (animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource is NULL");
        }
    }

    void Update()
    {
        CalculateMovement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDead) { return; }

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null) player.Damage();
            Deactivate();
        } 
        else if (other.tag == "Laser")
        {
            if (_player != null) _player.IncrementScore(Random.Range(1,15));
            Deactivate();
            Destroy(other.gameObject);

        }
        _isDead = true;
    }

    virtual public void CalculateMovement() 
    {
        Debug.LogError("CalculateMovement method is not overrided");
    }

    public void MoveToStartPosition()
    {
        float randomX = Random.Range(_xBounds * -1f, _xBounds);
        transform.position = new Vector3(randomX, _startYPosition, 0);
    }

    virtual public void Deactivate()
    {
        speed = 0;
        _audioSource.Play();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShootPrefab;
    [SerializeField]
    private GameObject _shieldObject;

    [SerializeField]
    private float _speed = 3.5f;
    private float _laserOffset = 0.958f;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private bool _isTripleShotEnabled = false;
    private bool _isSpeedPowerupEnabled = false;
    private bool _isShieldEnabled = false;
    private SpawnManager _spawManger;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawManger = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawManger == null)
        {
            Debug.LogError("SpawnManager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float speed = _speed * (_isSpeedPowerupEnabled ? 2 : 1);
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.8f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser() 
    {
        _canFire = Time.time + _fireRate;
        if (_isTripleShotEnabled)
        {
            Instantiate(_tripleShootPrefab, transform.position, Quaternion.identity);
        }
        else 
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, _laserOffset, 0), Quaternion.identity);
        }
    }

    IEnumerator StartTripleShootPowerupTimer()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotEnabled = false;
    }

    IEnumerator StartSpeedPowerupTimer()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedPowerupEnabled = false;
    }

    public void Damage() 
    {

        if (_isShieldEnabled)
        {
            _isShieldEnabled = false;
            _shieldObject.SetActive(false);
            return;
        }

        _lives--;
        if(_lives < 1)
        {
            _spawManger.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShotPowerup()
    {
        _isTripleShotEnabled = true;
        StartCoroutine(StartTripleShootPowerupTimer());
    }

    public void ActivateSpeedPowerup() 
    {
        _isSpeedPowerupEnabled = true;
        StartCoroutine(StartSpeedPowerupTimer());
    }

    public void ActivateShieldPowerup() {
        _isShieldEnabled = true;
        _shieldObject.SetActive(true);
    }
}
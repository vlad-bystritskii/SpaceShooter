using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 5f;
    private float _endYPosition = -7.5f;

    override public void CalculateMovement() 
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

        if (transform.position.y <= _endYPosition)
        {
           MoveToStartPosition();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _rotateSpeed = 0;
        animator.SetTrigger("OnAsteroidDead");
        Destroy(this.gameObject, 2.633f);
    }
}

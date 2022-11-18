using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : EnemyBehaviour
{
    private float _endYPosition = -6f;
    [SerializeField]

    override public void CalculateMovement() 
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= _endYPosition)
        {
           MoveToStartPosition();
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
        animator.SetTrigger("OnEnemyDead");
        Destroy(this.gameObject, 2.633f);
    }
}
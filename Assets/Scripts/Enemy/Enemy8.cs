using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : Enemy
{
    private void Awake()
    {
        SearchRange = 8;
        HP = 18;
        rangedAttack = 50;
        mass = 2;
        organic = 10;
        timer = 1.5f;
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.transform.position) >= 40)
            Destroy(this.gameObject);
        transform.Rotate(0,0,60*Time.deltaTime);
    }
}

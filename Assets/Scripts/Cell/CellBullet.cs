using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBullet : MonoBehaviour
{
    public int attack;
    public int Speed;
    private void Awake()
    {
        attack = 6;
        Speed = 10;
        GetComponent<Rigidbody2D>().velocity = (transform.position-Player.GetInstance.gameObject.transform.position).normalized*Speed;
    }
    private void Update()
    {
        if ((Player.GetInstance.gameObject.transform.position - transform.position).magnitude >= 50)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            if (collider.tag =="Enemy"|| collider.tag == "Weed"|| collider.tag == "Star")
            {
               Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouth : CellBase
{
    private int attack;
    private void Awake()
    {
        attack = 2;
        cost = 4;
        type = organelleType.Mouth;
        needEnergy = 2;
        timer = 0.5f;
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            TryUpdate();
            timer = 0.5f;
        }
    }
    void TryUpdate()
    {
        Player.GetInstance.getEnergy-=needEnergy;
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject enemy = collision.collider.gameObject;
                Player player=Player.GetInstance;
                int damage = attack;
                Player.GetInstance.Energy -= collision.gameObject.GetComponent<Enemy>().attack/2;
                enemy.GetComponent<Enemy>().HP-=damage;
                player.rb.AddForce((transform.position - enemy.transform.position).normalized * BoundForce);
                enemy.GetComponent<Rigidbody2D>().AddForce((-transform.position + enemy.transform.position).normalized * BoundForce);
            }
        }
    }
}

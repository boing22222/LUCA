using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Chloroplast : CellBase
{

    public bool isFull;
    private void Awake()
    {

        Player.GetInstance.mass += 1;
        cost = 5;
        type = organelleType.Chloroplast;
        productEnergy = 4;
        productOrganic = 1;
        timer = 0.5f;
        isFull= false;
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
    private void TryUpdate()
    {
// productEnergy = 8+(int)(transform.position.y);
//        productOrganic = 4 +(int)(0.3 * transform.position.y);
        if(productOrganic < 1) productOrganic = 1;
        if(productEnergy < 2) productEnergy = 2;
        if (!isFull)
        {
            Player.GetInstance.getEnergy += productEnergy;
        }
        if(Player.GetInstance.Energy==Player.GetInstance.maxEnergy) 
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
        Player.GetInstance.getOrganic += productOrganic;
    }
public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Player.GetInstance.Energy -= collision.gameObject.GetComponent<Enemy>().attack;
                Player.GetInstance.rb.AddForce((transform.position - collision.gameObject.transform.position).normalized * BoundForce);
            }
        }
    }
}

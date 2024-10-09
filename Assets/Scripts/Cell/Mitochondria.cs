using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CellBase;

public class Mitochondria : CellBase
{
    // Start is called before the first frame update
    private void Awake()
    {

        Player.GetInstance.mass += 1;
        cost = 6;
        type = organelleType.Mitochondria;
        productEnergy = 12;
        needOrganic = 5;
        timer = 0.5f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            TryUpdate();
            timer = 0.5f;
        }
    }
    // Update is called once per frame
    private void TryUpdate()
    {
        if (Player.GetInstance.AllOrganic >=needOrganic)
        {
            Player.GetInstance.AllOrganic-=needOrganic;
            Player.GetInstance.getEnergy += productEnergy;
        }
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
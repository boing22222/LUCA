using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter:MonoBehaviour 
{
    public GameObject BulletPrefab;
    [SerializeField]private float timer;
    private float SearchRange;
    [SerializeField]private int rangedAttack;
    private Enemy parent;
    private Player player;
    // Start is called before the first frame update
    private void Awake()
    {
        parent = GetComponentInParent<Enemy>();
        SearchRange = parent.SearchRange;
        player = Player.GetInstance;
        timer = parent.timer;
        rangedAttack = parent.rangedAttack;
    }
    private void Update()
    {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                TryFire();
                timer = 2;
            }
    }
    private void TryFire()
    {
        GameObject bullet = GameObject.Instantiate(BulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<EnemyBullet>().attack = rangedAttack;
        bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - bullet.transform.position).normalized * 50;
    }
}

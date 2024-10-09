using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public GameObject enemyGO;
    public GameObject[] enemyList;
    static float timer = 10f;
    private enum Block
    {
        left, mid, right
    }
    public float maxTimer;
    public float minTimer;
    private Block block;
    private Enemy enemy;
    public GameObject left;
    public GameObject midleft;
    public GameObject midright;
    public GameObject right;
    // Start is called before the first frame update
    void Start()
    {
        maxTimer = 3f;
        minTimer = 1f;
    }
    bool[] hasPass = new bool[3];

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            TryGenerate();
            timer = Random.Range(minTimer, maxTimer);
        }
    }
    private void GetBlock(float x)
    {
        if (x < midleft.transform.position.x)
        {
            block = Block.left;
        }
        else if (x < midright.transform.position.x)
        {
            block = Block.mid;
        }
        else
        {
            block = Block.right;
        }
    }
    private void TryGenerate()
    {
        float x, y;

        int sighx = Random.Range(0, 2);


        if (sighx == 0)
        {
            x = - Random.Range(12, 16);
        }
        else
        {
            x = + Random.Range(12, 16);
        }
        GetBlock(x + Player.GetInstance.transform.position.x);
        int sighy = Random.Range(0, 2);
        if (sighy == 0)
        {
            y =  - Random.Range(6, 12);
        }
        else
        {
            y =  Random.Range(6, 12);
        }

        switch (block)
        {
            case Block.left:
                int randomType = Random.Range(0, 5);
                enemyGO = enemyList[randomType];
                break;
            case Block.mid:
                randomType = Random.Range(5, 8);
                enemyGO = enemyList[randomType];
                break;
            case Block.right:
                randomType = Random.Range(8, 11);
                enemyGO = enemyList[randomType];
                break;
        }
        Vector3 dir = new Vector3(x, y, 0);
        Instantiate(enemyGO, Player.GetInstance.transform.position+dir, transform.rotation);
    }
}

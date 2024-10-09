using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WeedPrefab;
    public GameObject StarPrefab;
    static float timer = 7f;
    private enum Block
    {
        left, mid, right
    }
    private Block block;
    public GameObject left;
    public GameObject midleft;
    public GameObject midright;
    public GameObject right;
    public float maxTimer;
    public float minTimer;
    // Start is called before the first frame update
    void Start()
    {
        maxTimer = 3f;
        minTimer = 1f;
    }
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
            int sighy = Random.Range(0, 2);

            if (sighx == 0)
            {
                x = -Random.Range(8, 16);
            }
            else
            {
                x = Random.Range(8, 16);
            }
            GetBlock(x);
            if (sighy == 0)
            {
                y = -Random.Range(4, 8);
            }
            else
            {
                y = Random.Range(4, 8);
            }
        Vector3 dir = new Vector3(x, y, 0);
        if(Random.value>0.7)
            Instantiate(StarPrefab, Player.GetInstance.transform.position + dir, transform.rotation);
        else
        {
            Instantiate(WeedPrefab, Player.GetInstance.transform.position + dir, transform.rotation);
        }
    }
}

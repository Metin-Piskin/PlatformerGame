using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public GameObject[] platformPrefebs;
    public GameObject[] attackablePrefebs;
    public int platformSpawnCount;
    public Vector3 lastEndPoint;

    public void SpawnPlatforms() 
    {
        for (int i = 0; i < platformSpawnCount; i++)
        {
           GameObject platform  = GameObject.Instantiate(platformPrefebs[Random.Range(0, platformPrefebs.Length)]);
            Platform platformScript = platform.GetComponent<Platform>();
            platform.transform.position = lastEndPoint;

            int x = Random.Range(0, 10);
            if (x >= 8)
            {
                GameObject tree = GameObject.Instantiate(attackablePrefebs[Random.Range(0, attackablePrefebs.Length)]);
                {
                    tree.transform.position = lastEndPoint+ new Vector3(0,2.5f,10);
                }
            }

            lastEndPoint = platformScript.ReturnEndPoint();
        }
    }

    // playe basýldýðý anda çalýþan fonksiyon
    private void Awake()
    {
        //referanslar
    }

    // yapmanýz gereken ilk þeyler
    void Start()
    {
        //platformlarý yarat
        SpawnPlatforms();
    }

    /*
    // her frame de 1 kere çaðýrýlýr genelde karakter hareket ettirmede kullanýlýr
    void Update()
    {

    }
    */

    // 60 defa çaðýrýlýr
    private void FixedUpdate()
    {

    }
 /*
    private void OnEnable()
    {
        //dinleyiciler konur
    }

    private void OnDisable()
    {

    }
    */
}


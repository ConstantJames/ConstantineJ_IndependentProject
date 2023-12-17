using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;


public class BulletLogic : MonoBehaviour
{

    int bulletTime = 1000;
    public float points = 0f;
    public float totalPoints = 0f;
    public GameManager manager;
    public GameObject obstaclePrefab;
    

void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        GameObject.FindWithTag("Manager").GetComponent<GameManager>().AdjustPoints(1);
        GameObject.FindWithTag("Manager").GetComponent<GameManager>().AdjustPoints(1);
    }
    // Start is called before the first frame update
    void Start()
    {
        manager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if (bulletTime <= 0)
        {
            Destroy(this.gameObject);
        }

        else
        {
            bulletTime--;
        }
    }
}

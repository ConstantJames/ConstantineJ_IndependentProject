using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public GameManager manager;
    public GameObject player;
    public float moveSpeed = 0.05f;
    public float lifeAmount = 3;
    public float points = 1;
    public GameObject explodePrefab;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed, 0 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.LivesLost(lifeAmount);
            Destroy(gameObject);
        }
    }  
}

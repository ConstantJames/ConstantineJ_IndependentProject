using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 7000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public GameManager manager;
    public Material normalMat;
    public Material phasedMat;
    public float bounds = 3f;
    public float strafeSpeed = 4f;
    public float phaseCooldown = 2f;
    private GameObject explodePrefab;
    Renderer mesh;
    Collider collision;


    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        collision = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;

        Vector3 position = transform.position;
        position.x += xMove;
        position.x = Mathf.Clamp(position.x, -bounds, bounds);
        transform.position = position;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnCycle = .5f;
    GameManager manager;
    float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > spawnCycle)
		{
			GameObject temp;

				temp = Instantiate(obstaclePrefab) as GameObject;

			Vector3 position = temp.transform.position;
			position.x = UnityEngine.

				Random.Range(-15f, 15f);

			position.z = UnityEngine.

				Random.Range(-10f, 15f);

            temp.transform.position = position;

			Collidable col = temp.GetComponent<Collidable>();

			col.manager = manager;

			elapsedTime = 0;
		}
	}
}

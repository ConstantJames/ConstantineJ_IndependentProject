using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject player;
    public TextureScroller ground;
    public float points = 0;
    public float lives = 3;
    bool isGameOver = false;
    int respawnTime = 1;
    int pointTime = 1;
    public GameObject bulletLogic;
    public GameObject explodePrefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletLogic = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnTime > 0)
        {
        respawnTime--;
        }
        
        if (isGameOver)
            return;

        if (lives <= 0)
            isGameOver = true;
    }

    public void PositionPlayer()
    {
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
    }

    public void PlayerExplosion()
    {
        Instantiate(explodePrefab, player.transform.position, Quaternion.identity);
    }
        
    public void AdjustPoints(float amount)
    {
        if (pointTime <= 0)
        {
            print("Shot Enemy");
            points++;
            pointTime = 1;
        }
        else
        {
            pointTime--;
        }
    }

    public void LivesLost(float amount)
    {
        if (respawnTime <= 0)
        {
            lives--;
            print("lost a life");
            respawnTime = 75;
            PlayerExplosion();
        }
        
    }

    public void Exit()
    {
        print("Quit Works");
        Application.Quit();
    }

    void OnGUI()
    {
        if (!isGameOver)
        {
            Rect boxRect = new Rect(Screen.width / 2 - 50, Screen.height - 100, 100, 50);
            GUI.Box(boxRect, "Points: " + (float)points);
           

            Rect labelRect = new Rect(Screen.width / 2 - 20, Screen.height - 80, 50, 40);
            GUI.Label(labelRect, ("Lives: " + (int)lives).ToString());
        
        }
    
        else
        {
            Rect boxRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 100, 120, 50);
            GUI.Box(boxRect, "Game Over");
            Rect labelRect = new Rect(Screen.width / 2 - 55, Screen.height / 2 - 80, 90, 40);
            GUI.Label(labelRect, "Total Points: " + (int)points);

            Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

            if (GUI.Button(startButton,"QUIT") || Input.GetKeyDown(KeyCode.Return))
            {
                Application.Quit();
            }
                Time.timeScale = 0;
        }
    }
}

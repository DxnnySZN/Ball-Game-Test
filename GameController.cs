using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    // calls the 3D OBJECT Sphere (renamed Ball) made in the hierarchy tab
    public Transform spawnPoint;
    // calls the GameObject (renamed SpawnPoint) made in the hierarchy tab by clicking "Create Empty"
    public float maxX;
    // represents the maximum of the X-Axis value
    // you set the maximum of the X-Axis value by going into GameManager in the hierarchy tab, going into the inspector tab, and changing the value box of Max X
    public float maxZ;
    // represents the maximum of the Z-Axis value
    // you set the maximum of the Z-Axis value by going into GameManager in the hierarchy tab, going into the inspector tab, and changing the value box of Max Z

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", 1f, 0.025f);
        // 1f represents the amount of seconds you wait until the function starts
        // 2f represents the amount of seconds you wait until the function keeps on repeating
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SpawnBall();
            // anytime the spacebar is pressed, the ball will spawn
        }
        // 0 represents the left click, 1 represents the right click
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Input.mousePosition;
            // mousePos is now represented as the position where the mouse cursor is at
            mousePos.z = 5f;
            // the higher the number, the farther the balls will spawn from the plane
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mousePos);
            // this will allow the ball to spawn wherever the mouse cursor is due to the conversion of the mousePos to the WorldPoint
            Instantiate(ball, spawnPos, Quaternion.identity);
            // Quaternion.identity is the nerdy way of saying the rotation of the ball when spawned is set to zero
        }
    }

    // in order for the ball to keep on spawning, you must create a folder under the assets category and put the ball object inside the folder
    void SpawnBall(){
        float randomX = Random.Range(-maxX, maxX);
        // this creates a random range between the minimum of the X-Axis and the maximum of the X-Axis
        float randomZ = Random.Range(-maxZ, maxZ);
        // this creates a random range between the minimum of the Z-Axis and the maximum of the Z-Axis

        Vector3 randomSpawnPos = new Vector3(randomX, 5f, randomZ);
        // this sets the random spawn position at the random range of the X-Axis, the value of 5 for the Y-Axis, and the random range of the Z-Axis
        Instantiate(ball, randomSpawnPos, Quaternion.identity);

        // Instantiate(ball, spawnPoint.position, Quaternion.identity);
        // this will allow the ball to spawn in the spawnpoint position as many times as the user wants
    }
}

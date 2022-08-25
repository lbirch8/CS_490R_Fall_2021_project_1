using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpawnRocket rocket;
    public GameObject spawnRocket;
    public float speed;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //doesn't let you move until the game starts
        if (gameManager.gameActive)
        {
            if (playerRb.velocity.magnitude < 70)
            {
                playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(rocket, spawnRocket.transform.position, spawnRocket.transform.rotation);
            }
        }
    }
}

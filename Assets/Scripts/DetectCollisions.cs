using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private SpawnManager spawnManager;
    private GameManager gameManager;
    private Rigidbody enemyRb;
    public AudioClip soundFX;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //checks to see if the player triggers the objective
        if(gameObject.tag == "Objective" && other.gameObject.name == "Player")
        {
            Debug.Log("true");
            Destroy(gameObject);
            spawnManager.SpawnObjective();
            gameManager.UpdateHealth(10);
            gameManager.UpdateScore();
            gameManager.PlaySound(soundFX);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        //checks to see if the rocket hits an enemy
        if(collision.gameObject.tag  == "enemy" && gameObject.name == "Rocket(Clone)")
        {
            spawnManager.SpawnEnemy();
            gameManager.PlaySound(soundFX);
            gameManager.PlayParticle(gameObject.transform);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

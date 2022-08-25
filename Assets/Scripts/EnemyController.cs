using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 15000.0f;

    private Rigidbody enemyRb;
    private GameObject player;
    private GameManager gameManager;
    public AudioClip impactSound;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //destroys the enemy if they fall below the map
        if(transform.position.y < -10)
        {
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().SpawnEnemy();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //checks to see if enemy collides with the player
        if (collision.gameObject.name == "Player")
        {
            Vector3 awayFromPlayer = transform.position - collision.gameObject.transform.position;
            enemyRb.AddForce(awayFromPlayer * 75, ForceMode.Impulse);
            gameManager.UpdateHealth(-10);
            gameManager.PlaySound(impactSound);
        }
    }
}

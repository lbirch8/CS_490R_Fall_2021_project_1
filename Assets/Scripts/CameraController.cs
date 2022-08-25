using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed;

    private Vector3 positionOffset;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position - player.transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //doesn't let you look around until the game starts
        if (gameManager.gameActive)
        {
            transform.position = player.transform.position + positionOffset;
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public GameObject gameActiveScreen;
    public ParticleSystem explosionParticle;
    public bool gameActive = false;
    public AudioClip music;

    private AudioSource playAudio;
    private int score;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        playAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Objectives: " + score;
    }

    public void UpdateHealth(int updatedHealth)
    {
        if(!(health + updatedHealth > 100))
        {
            health += updatedHealth;
            healthText.text = "Health: " + health;
        }
        if(health <= 0)
        {
            healthText.text = "Health: 0";
            GameOver();
        }
    }
    public void PlaySound(AudioClip sound)
    {
        playAudio.PlayOneShot(sound, 1.0f);
    }

    public void PlayParticle(Transform spawnPos)
    {
        Instantiate(explosionParticle, spawnPos.position, spawnPos.rotation);
        explosionParticle.Play();
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameActiveScreen.SetActive(true);
        gameActive = true;
        score = 0;
        health = 100;
        playAudio.PlayOneShot(music, .25f);
    }
}

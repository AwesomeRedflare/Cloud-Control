using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public float upSpeed;
    public float downSpeed;
    public float randomMovement = 1;

    public static bool dsta = false;

    public int health = 3;
    public Text healthText;

    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject obstacleSpawner;
    public GameObject scoreManager;
    public GameObject collisionEffect;

    public Rigidbody2D rb;

    public ShakeBehavior shakeBehavior;

    private void Start()
    {
        if (dsta == false)
        {
            InvokeRepeating("MovePlane", randomMovement, randomMovement);
            startPanel.gameObject.SetActive(true);
            obstacleSpawner.gameObject.SetActive(false);
            scoreManager.gameObject.SetActive(true);
        }
        else
        {
            InvokeRepeating("MovePlane", randomMovement, randomMovement);
            StartGame();
        }
    }

    public void StartGame()
    {
        obstacleSpawner.gameObject.SetActive(true);
        startPanel.gameObject.SetActive(false);
        scoreManager.gameObject.SetActive(true);
    }

    public void Dsta()
    {
        dsta = true;
    }

    private void Update()
    {
        healthText.text = "Plane's Health: " + health.ToString();

        if(health <= 0)
        {
            PlaneDeath();
            scoreManager.gameObject.SetActive(false);
            obstacleSpawner.gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
        }
    }

    void PlaneDeath()
    {
        GetComponent<Collider2D>().enabled = false;
        transform.rotation = Quaternion.Euler(Vector3.forward * -30);
        transform.Translate(Vector2.right * Random.Range(3f, 7f) * Time.deltaTime);
        return;
    }

    void MovePlane()
    {
        bool moveUp = (Random.value > 0.5f);
        if (moveUp == true)
        {
            upSpeed = Random.Range(50, 300);
            rb.velocity = transform.up * upSpeed * Time.deltaTime;
        }
        else
        {
            downSpeed = Random.Range(-300, -50);
            rb.velocity = transform.up * downSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SoundManagerScript.PlaySound("hitSound");
            shakeBehavior.TriggerShake();
            Instantiate(collisionEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            health -= 1;
        }

    }
}

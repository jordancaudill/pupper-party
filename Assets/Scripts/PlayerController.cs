using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    private SpawnManager spawnManager;
    private GameManager gameManager;
    public ParticleSystem starParticle;
    public ParticleSystem explosionParticle;
    Animator animator;
    private AudioSource playerAudio;
    public AudioClip barkSound;
    public AudioClip crashSound;
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (gameManager.gameActive)
        {
            animator.SetFloat("Speed_f", 0.9f);

            // Constantly move forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Rotate character based on input
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.gameActive)

            if (other.gameObject.CompareTag("Stray"))
            {
                // add new dog to line
                spawnManager.SpawnDog();
                // delete old stray
                Destroy(other.gameObject);
                // spawn new stray
                spawnManager.SpawnStray();
                starParticle.Play();
                playerAudio.PlayOneShot(barkSound, 1.0f);
            }
            else if (other.gameObject.CompareTag("Dog") || other.gameObject.CompareTag("Wall"))
            {
                gameManager.GameOver();
                explosionParticle.Play();
                playerAudio.PlayOneShot(crashSound, 1.0f);
            }
    
    }

}

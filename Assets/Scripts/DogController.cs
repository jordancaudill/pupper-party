using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private float moveSpeed = 40;
    private GameObject dogToFollow;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetFloat("Speed_f", 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        // look at and add force -> doesn't work since some dogs will just rotate 
        // dogs need to follow exact same path as dogToFollow
        // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Vector3 targetPosition = dogToFollow.transform.position;

        // Keep our y position unchanged.
        targetPosition.y = transform.position.y;

        // Smooth follow.    
        transform.position += (targetPosition - transform.position) * 0.1f;
        transform.LookAt(dogToFollow.transform);

    }
    public void SetDogToFollow(GameObject dog)
    {
        dogToFollow = dog;
    }
}

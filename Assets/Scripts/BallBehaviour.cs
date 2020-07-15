using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Transform paddle;
    public Rigidbody2D rbBall;
    public bool gameStarted = false;
    public float vel; 
    float site;

    private Vector3 _initPos;
    // Start is called before the first frame update
    void Start()
    {
        _initPos = transform.position;
        site = Random.Range(-1,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            transform.position = _initPos;
            if (Input.GetMouseButtonDown(0))
            {
                rbBall.velocity = new Vector2(site <= 0 ? -vel : vel, Random.Range(-vel, vel));

                gameStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}

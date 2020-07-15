using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentBehaviour : MonoBehaviour
{
    public GameObject ball;
    public float speed;

    private Vector3 initPos;
    private float limit = 3.715f;

    void Start()
    {
        initPos = transform.position;
    }
    void Update()
    {
        if (ball.GetComponent<BallBehaviour>().gameStarted) {
            if (ball.transform.position.y > transform.position.y) {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            } else if (ball.transform.position.y < transform.position.y) {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - speed, -limit, limit), transform.position.z);
            }
        } else {
            transform.position = initPos;
        }
    }
}

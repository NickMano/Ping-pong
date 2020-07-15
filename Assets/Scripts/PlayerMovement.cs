using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer playerSpriteRender;
    float screenHeight, limit;
    // Start is called before the first frame update
    void Start()
    {
        playerSpriteRender = GetComponent<SpriteRenderer>();
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        limit = screenHeight - playerSpriteRender.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(mousePos.y, -limit, limit), transform.position.z);
    }
}

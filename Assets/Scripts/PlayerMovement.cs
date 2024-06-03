using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float initialSpeed;

    [SerializeField]
    private bool isPaused;

    public Rigidbody2D rb;
    private Vector2 direction;

    void Awake()
    {
        //Atribuir a mascara da camada
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        direction.Normalize();
        Turning();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    void Movement()
    {
        direction.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void Turning()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        transform.right = direction;
    }
}

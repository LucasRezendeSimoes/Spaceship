using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    private Rigidbody2D rb2d; // Referência para o Rigidbody2D
    private Vector2 moveDirection; // Direção do movimento
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimentação da nave
        float moveY = Input.GetAxisRaw("Vertical"); // Movimento na horizontal (A/D ou setas)
        float moveX = Input.GetAxisRaw("Horizontal"); // Movimento na horizontal (A/D ou setas)
        moveDirection = new Vector2(moveX, moveY);

        // Disparo do projétil
        if (Input.GetKeyDown(KeyCode.Space))
        {
            x = transform.position.x;

            var vel = rb2d.velocity;
            vel.x = speed/qtd;
            vel.y = -0.05f;
            rb2d.velocity = vel;

            tiros = GameObject.FindGameObjectsWithTag("Tiro");
        }
    }

    OnCollisionEnter2D(Collision2D coll)

    // FixedUpdate é chamado de forma mais consistente para física
    void FixedUpdate()
    {
        // Movimentação no Rigidbody2D
        Vector2 newPos = rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        // Limitar a posição dentro dos valores especificados
        newPos.y = Mathf.Clamp(newPos.y, -3.5f, 3.5f);  // Limitar o movimento na horizontal
        newPos.x = Mathf.Clamp(newPos.x, -4.5f, 4.5f);  // Limitar o movimento na horizontal

        rb2d.MovePosition(newPos);
    }
        
}

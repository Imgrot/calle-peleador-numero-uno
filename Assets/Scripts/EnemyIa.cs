using UnityEngine;

public class EnemyIa : MonoBehaviour
{
    public float speed = 2.0f;
    public bool isCollition = false;
    public Transform player;

    private bool isAttacking = false;

    void Update()
    {
        // if (player != null)
        // {
        //     float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //     if (distanceToPlayer < detectionRange && !isAttacking)
        //     {
        //         MoveTowardsPlayer(distanceToPlayer);
        //     }
        // }
    }

    public void Movimiento()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (transform.position.x > 5.7f)
        {
            speed = -speed;
        }
    }

    // void MoveTowardsPlayer(float distanceToPlayer)
    // {
    //     if (distanceToPlayer > attackRange)
    //     {
    //         Vector3 direction = (player.position - transform.position).normalized;
    //         transform.position += direction * speed * Time.deltaTime;
    //     }
    //     else
    //     {
    //         AttackPlayer();
    //     }
    // }
    private void EnemyRandomIa()
    {
        int aleatorio = Random.Range(0, 5);
    }

    private void OisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollition = true;
        }
    }
    private void OnCollissionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollition = false;
        }
    }
    void AttackPlayer()
    {
        isAttacking = true;
        Debug.Log("Enemy is attacking the player!");
    }
}
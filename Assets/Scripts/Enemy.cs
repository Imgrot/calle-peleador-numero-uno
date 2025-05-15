using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedX;
    public Animator anim;
    public Animator animPlayer;
    private bool isCollision;
    public GameManager gameManager;
    private int aleatorio;

    public Skills animations;
    public bool _block;

    void Start()
    {
        speedX = 5.0f;
        isCollision = false;
        InvokeRepeating("EnemyIA", 0, 0.5f);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _block = false;
    }
    void Update()
    {
        Movimiento();
        DeadAndWin();
    }

    private void Movimiento()
    {
        transform.position += new Vector3(-speedX * Time.deltaTime, 0, 0);
        if (transform.position.x < 5.7f)
        {
            speedX *= -1;
        }
    }

    private void EnemyIA()
    {
        aleatorio = Random.Range(0, 5);
        if (isCollision)
        {
            if (aleatorio == 0)
            {
                anim.SetBool("HighKick", true);
            }
            else
            {
                anim.SetBool("HighKick", false);
            }
            if (aleatorio == 1)
            {
                anim.SetBool("LowPunch", true);
            }
            else
            {
                anim.SetBool("LowPunch", false);
            }
            if (aleatorio == 2)
            {
                anim.SetBool("Punches", true);
            }
            else
            {
                anim.SetBool("Punches", false);
            }
            if (aleatorio == 3)
            {
                anim.SetBool("blocking", true);
                _block = true;
            }
            else
            {
                anim.SetBool("blocking", false);
                _block = false;
            }
            if (aleatorio == 4 | aleatorio == 5)
            {
                anim.SetBool("blocking", false);
                anim.SetBool("HighKick", false);
                anim.SetBool("LowPunch", false);
                anim.SetBool("Punches", false);
                speedX *= -1;
            }
        }
        else
        {
            anim.SetBool("blocking", false);
            anim.SetBool("HighKick", false);
            anim.SetBool("LowPunch", false);
            anim.SetBool("Punches", false);
            speedX *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isCollision = true;
            CheckAtaque();
        }
    }

    private void OllisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isCollision = false;
        }
    }

    private void CheckAtaque()
    {
        if (isCollision && animations.Blocking == false)
        {
            if (aleatorio == 0 || aleatorio == 1 || aleatorio == 2)
            {
                gameManager.numeroVidasPlayer -= 0.05f;
                gameManager.isDeadPlayer = true;
            }
        }
        Debug.Log(gameManager.numeroVidasPlayer);
        Debug.Log(gameManager.isDeadPlayer);

        if (isCollision)
        {
            if (animations.IsAttacking == true)
            {
                gameManager.numeroVidasEnemy -= 0.05f;
                gameManager.isDeadEnemy = true;
            }
        }
        Debug.Log("Al enemigo le quedan " + gameManager.numeroVidasPlayer);
        Debug.Log("¿Esta Muerto?" + gameManager.isDeadPlayer);
    }
    private void DeadAndWin()
    {
        if (gameManager.numeroVidasEnemy < 1)
        {
            anim.SetBool("LOSE", true);
            animPlayer.SetBool("WIN", true);
        }
        if (gameManager.numeroVidasPlayer < 1)
        {
            anim.SetBool("WIN", true);
            animPlayer.SetBool("LOSE", true);
        }
        speedX = 0f;
    }
}
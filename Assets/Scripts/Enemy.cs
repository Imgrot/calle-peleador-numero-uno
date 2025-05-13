using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float VelocidadHorizontal;
    public Animator anim;
    private bool isCollision;
    public GameManager gameManager;
    private int aleatorio;

    public Animations animations;
    private bool _block;

    void Start()
    {
        VelocidadHorizontal = 5.0f;
        isCollision = false;
        InvokeRepeating("RoiIA", 0, 0.5f);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _block = false;
    }
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        transform.position += new Vector3(-VelocidadHorizontal * Time.deltaTime, 0, 0);
        if (transform.position.x < 5.7f)
        {
            VelocidadHorizontal *= -1;
        }
    }

    private void RoiIA()
    {
        aleatorio = Random.Range(0, 5);
        if (isCollision)
        {
            if (aleatorio == 0)
            {
                anim.SetBool("AtaqueEnemy1 ", true);
            }
            else
            {
                anim.SetBool("AtaqueEnemy1 ", false);
            }
            if (aleatorio == 1)
            {
                anim.SetBool("AtaqueEnemy2 ", true);
            }
            else
            {
                anim.SetBool("AtaqueEnemy2 ", false);
            }
            if (aleatorio == 2)
            {
                anim.SetBool("AtaqueEnemy3 ", true);
            }
            else
            {
                anim.SetBool("AtaqueEnemy3 ", false);
            }
            if (aleatorio == 3)
            {
                anim.SetBool("BloqueoEnemy", true);
                _block = true;
            }
            else
            {
                anim.SetBool("BloqueoEnemy", false);
                _block = false;
            }
            if (aleatorio == 4 | aleatorio == 5)
            {
                VelocidadHorizontal *= -1;
                anim.SetBool("BloqueoEnemy", false);
                anim.SetBool("AtaqueEnemy1 ", false);
                anim.SetBool("AtaqueEnemy2 ", false);
                anim.SetBool("AtaqueEnemy3 ", false);
            }
        }
        else
        {
            anim.SetBool("BloqueoEnemy", false);
            anim.SetBool("AtaqueEnemy1 ", false);
            anim.SetBool("AtaqueEnemy2 ", false);
            anim.SetBool("AtaqueEnemy3 ", false);
            VelocidadHorizontal *= -1;
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
                gameManager.numeroVidasPlayer--;
                gameManager.isDeadPlayer = true;
            }
        }
        //Ver resultado en consola
        Debug.Log(gameManager.numeroVidasPlayer);
        Debug.Log(gameManager.isDeadPlayer);

        //Logica Player al enemigo
        if (isCollision)
        {
            if (animations.PatadaAltaPlayer == true || animations.PatadaMediaPlayer == true || animations.PatadaBajaPlayer == true)
            {
                gameManager.numeroVidasEnemy--;
                gameManager.isDeadEnemy = true;
            }
        }
        //Ver resultado en consola
        Debug.Log("Al enemigo le quedan " + gameManager.numeroVidasPlayer);
        Debug.Log("¿Esta Muerto?" + gameManager.isDeadPlayer);
    }
}
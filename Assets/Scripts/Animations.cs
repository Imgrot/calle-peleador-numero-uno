using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    public Mover mover;


    //Bloqueo
    public bool _blocking = false;
    public bool Blocking
    {
        get { return _blocking; }
        set { _blocking = value; }
    }
    //Ataque 1
    private bool _PatadaAltaPlayer = false;
    public bool PatadaAltaPlayer
    {
        get { return _PatadaAltaPlayer; }
        set { _PatadaAltaPlayer = value; }
    }
    //Ataque 2
    private bool _PatadaMediaPlayer = false;
    public bool PatadaMediaPlayer
    {
        get { return _PatadaMediaPlayer; }
        set { _PatadaMediaPlayer = value; }
    }
    //Ataque 3
    private bool _PatadaBajaPlayer = false;
    public bool PatadaBajaPlayer
    {
        get { return _PatadaBajaPlayer; }
        set { _PatadaBajaPlayer = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Bloqueo", true);
            mover.VelocidadHorizontal = 0;
            _blocking = true;
        }
        else
        {
            anim.SetBool("Bloqueo", false);
            mover.VelocidadHorizontal = 12;
            _blocking = false;
        }
        //Animacion ataque 1
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Ataque1", true);
        }
        else
        {
            anim.SetBool("Ataque1", false);
        }
        //Animacion ataque 2
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Ataque2", true);
            mover.VelocidadHorizontal = 0;
        }
        else
        {
            anim.SetBool("Ataque2", false);
            mover.VelocidadHorizontal = 12;
        }
        //Animacion ataque 3
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Ataque3", true);
        }
        else
        {
            anim.SetBool("Ataque3", false);
        }
    }

}

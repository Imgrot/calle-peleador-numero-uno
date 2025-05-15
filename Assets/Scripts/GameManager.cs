using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _numeroVidasPlayer = 10;
    private float _numeroVidasEnemy = 10;
    private bool _isDeadPlayer = false;
    private bool _isDeadEnemy = false;
    private bool _isBlockPlayer = false;
    private bool _isBlockEnemy = false;

    //Logica Vida Player
    public float numeroVidasPlayer
    {
        get { return _numeroVidasPlayer; }
        set { _numeroVidasPlayer = value; }
    }
    //Logica vida Enemigo
    public float numeroVidasEnemy
    {
        get { return _numeroVidasEnemy; }
        set { _numeroVidasEnemy = value; }
    }
    //Logica Muerte Player
    public bool isDeadPlayer
    {
        get { return _isDeadPlayer; }
        set
        {
            if (_numeroVidasPlayer < 1)
            {
                _isDeadPlayer = value;
            }
        }
    }
    //Logica Muerte Enemigo
    public bool isDeadEnemy
    {
        get { return _isDeadEnemy; }
        set
        {
            if (_numeroVidasEnemy < 1)
            {
                _isDeadEnemy = value;
            }
        }
    }

    //Logica Bloqueo Player
    public bool isBlockPlayer
    {
        get { return _isBlockPlayer; }
        set { _isBlockPlayer = value; }
    }
    //Logica Bloqueo Enemigo
    public bool isBlockEnemy
    {
        get { return _isBlockEnemy; }
        set { _isBlockEnemy = value; }
    }

    void Start()
    {

    }
    void Update()
    {

    }
}
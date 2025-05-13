using UnityEngine;

public class Mover : MonoBehaviour
{
    public float VelocidadHorizontal;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(VelocidadHorizontal * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > -6.0f)
        {
            transform.position += new Vector3(-VelocidadHorizontal * Time.deltaTime, 0, 0);
        }
    }
}
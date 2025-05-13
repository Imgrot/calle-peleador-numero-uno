using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedX = 4.0f;
    public bool isControlBlocked = false;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walking", false);
    }
    void Update()
    {
        Skills skillScript = GetComponent<Skills>();
        if (skillScript != null && (isControlBlocked || skillScript.IsBlocking))
        {
            anim.SetBool("walking", false);
            return;
        }

        if (Input.GetKey("left"))
        {
            anim.SetBool("walking", true);
            if (transform.position.x < -7.5f)
            {
                transform.position = new Vector3(-7.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(-speedX * Time.deltaTime, 0, 0);
            }
        }
        else if (Input.GetKey("right"))
        {
            anim.SetBool("walking", true);
            if (transform.position.x > 7.5f)
            {
                transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(speedX * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }
        if (transform.position.y != -2.0f)
        {
            transform.position = new Vector3(transform.position.x, -2.0f, transform.position.z);
        }
    }
}

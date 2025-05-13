using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public bool blocking = false;
    public bool walking = false;
    public float speedX = 4.0f;
    public bool isCharging = false;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walking", false);
        anim.SetBool("blocking", false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("SoulSword", false);
            StartCoroutine(SoulSwordRoutine());
            float duration = 0.6f;
            float timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.X) && !isCharging)
        {
            anim.SetBool("ShieldCharge", false);
            StartCoroutine(ShieldChargeRoutine());
            float boostDuration = 1.25f;
            float timer = 0f;
            while (timer < boostDuration)
            {
                timer += Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("Skeleport", false);
            StartCoroutine(SkeleportRoutine());
            float invDuration = 1.25f;
            float timer = 0f;
            while (timer < invDuration)
            {
                timer += Time.deltaTime;
            }
        }
        else if (Input.GetKey("left") && Input.GetKey("down"))
        {
            anim.SetBool("walking", false);
            anim.SetBool("blocking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("LowSword", true);
        }
        else if (Input.GetKey("down"))
        {
            anim.SetBool("blocking", true);
        }
        else if (Input.GetKey("left"))
        {
            transform.position += new Vector3(-speedX * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("right"))
        {
            transform.position += new Vector3(speedX * Time.deltaTime, 0, 0);
        }
        else
        {
            anim.SetBool("blocking", false);
        }
    }

    IEnumerator ShieldChargeRoutine()
    {
        isCharging = true;
        anim.SetBool("ShieldCharge", true);

        float boostDuration = 1.25f;
        float timer = 0f;
        while (timer < boostDuration)
        {
            transform.position += new Vector3(2 * speedX * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }

        anim.SetBool("ShieldCharge", false);
        isCharging = false;
    }

    IEnumerator SkeleportRoutine()
    {
        anim.SetBool("Skeleport", true);
        float duration = 1.36f;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        anim.SetBool("Skeleport", false);
    }

    IEnumerator SoulSwordRoutine()
    {
        anim.SetBool("SoulSword", true);
        float duration = 0.6f;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        anim.SetBool("SoulSword", false);
    }
}

using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour
{
    public bool blocking = false;
    public bool walking = false;
    public float speedX = 4.0f;

    public bool isCharging = false;
    public bool IsBlocking = false;

    public bool isAttacking = false;
    public bool canUseShieldCharge = true;
    public bool canUseSkeleport = true;

    public Movement movementScript;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        movementScript = GetComponent<Movement>();
        anim.SetBool("walking", false);
        anim.SetBool("blocking", false);
    }

    void Update()
    {
        if (isAttacking) return;

        if (Input.GetKey(KeyCode.Z))
        {
            if (IsBlocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(SoulSwordRoutine());
            }
        }
        else if (Input.GetKey(KeyCode.X) && canUseShieldCharge)
        {
            if (IsBlocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(ShieldChargeRoutine());
            }
        }
        else if (Input.GetKey(KeyCode.V) && canUseSkeleport)
        {
            if (IsBlocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(SkeleportRoutine());
            }
        }
        else if (Input.GetKey(KeyCode.C))
        {
            if (IsBlocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(LowSwordRoutine());
            }
        }
        else if (Input.GetKey("down"))
        {
            anim.SetBool("walking", false);
            anim.SetBool("blocking", true);
            IsBlocking = true;
        }
        else
        {
            anim.SetBool("blocking", false);
            IsBlocking = false;
        }
    }

    IEnumerator SoulSwordRoutine()
    {
        isAttacking = true;
        movementScript.isControlBlocked = true;

        anim.SetBool("SoulSword", true);
        yield return new WaitForSeconds(0.6f);

        anim.SetBool("SoulSword", false);
        movementScript.isControlBlocked = false;
        isAttacking = false;
    }
    IEnumerator LowSwordRoutine()
    {
        isAttacking = true;
        movementScript.isControlBlocked = true;

        anim.SetBool("LowSword", true);
        yield return new WaitForSeconds(0.53f);

        anim.SetBool("LowSword", false);
        movementScript.isControlBlocked = false;
        isAttacking = false;
    }
    IEnumerator ShieldChargeRoutine()
    {
        canUseShieldCharge = false;
        isAttacking = true;
        isCharging = true;
        movementScript.isControlBlocked = true;

        anim.SetBool("ShieldCharge", true);

        float duration = 1.5f;
        float timer = 0f;
        while (timer < duration)
        {
            transform.position += new Vector3(1.8f * speedX * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }

        anim.SetBool("ShieldCharge", false);
        isCharging = false;
        isAttacking = false;
        movementScript.isControlBlocked = false;

        yield return new WaitForSeconds(2f);
        canUseShieldCharge = true;
    }
    IEnumerator SkeleportRoutine()
    {
        canUseSkeleport = false;
        isAttacking = true;
        anim.SetBool("Skeleport", true);
        movementScript.isControlBlocked = true;

        yield return new WaitForSeconds(0.4f);

        Vector3 currentPos = transform.position;
        float targetX = currentPos.x - 3.0f;

        if (targetX < -7.5f)
            targetX = -7.5f;

        transform.position = new Vector3(targetX, currentPos.y, currentPos.z);

        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Skeleport", false);
        isAttacking = false;
        movementScript.isControlBlocked = false;

        yield return new WaitForSeconds(2.0f);
        canUseSkeleport = true;
    }
}

using UnityEngine;
using System.Collections;

public class Skills : MonoBehaviour
{
    public bool blocking = false;
    public float speedX = 4.0f;
    private bool _walking = false;
    public bool Walking
    {
        get { return _walking; }
        set { _walking = value; }
    }

    private bool _blocking = false;
    public bool Blocking
    {
        get { return _blocking; }
        set { _blocking = value; }
    }
    private bool _chargePlayer = false;
    public bool ChargePlayer
    {
        get { return _chargePlayer; }
        set { _chargePlayer = value; }
    }
    private bool _isAttacking = false;
    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value; }
    }
    private bool _canUseShieldCharge = true;
    public bool CanUseShieldCharge
    {
        get { return _canUseShieldCharge; }
        set { _canUseShieldCharge = value; }
    }
    private bool _canUseSkeleport = true;
    public bool CanUseSkeleport
    {
        get { return _canUseSkeleport; }
        set { _canUseSkeleport = value; }
    }

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
        if (_isAttacking) return;

        if (Input.GetKey(KeyCode.Z))
        {
            if (_blocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(SoulSwordRoutine());
            }
        }
        else if (Input.GetKey(KeyCode.X) && _canUseShieldCharge)
        {
            if (_blocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(ShieldChargeRoutine());
            }
        }
        else if (Input.GetKey(KeyCode.V) && _canUseSkeleport)
        {
            if (_blocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(SkeleportRoutine());
            }
        }
        else if (Input.GetKey(KeyCode.C))
        {
            if (_blocking == false)
            {
                anim.SetBool("walking", false);
                StartCoroutine(LowSwordRoutine());
            }
        }
        else if (Input.GetKey("down"))
        {
            anim.SetBool("walking", false);
            anim.SetBool("blocking", true);
            _blocking = true;
        }
        else
        {
            anim.SetBool("blocking", false);
            _blocking = false;
        }
    }

    IEnumerator SoulSwordRoutine()
    {
        _isAttacking = true;
        movementScript.isControlBlocked = true;

        anim.SetBool("SoulSword", true);
        yield return new WaitForSeconds(0.6f);

        anim.SetBool("SoulSword", false);
        movementScript.isControlBlocked = false;
        _isAttacking = false;
    }
    IEnumerator LowSwordRoutine()
    {
        _isAttacking = true;
        movementScript.isControlBlocked = true;

        anim.SetBool("LowSword", true);
        yield return new WaitForSeconds(0.53f);

        anim.SetBool("LowSword", false);
        movementScript.isControlBlocked = false;
        _isAttacking = false;
    }
    IEnumerator ShieldChargeRoutine()
    {
        _canUseShieldCharge = false;
        _isAttacking = true;
        _chargePlayer = true;
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
        _chargePlayer = false;
        _isAttacking = false;
        movementScript.isControlBlocked = false;

        yield return new WaitForSeconds(2f);
        _canUseShieldCharge = true;
    }
    IEnumerator SkeleportRoutine()
    {
        _canUseSkeleport = false;
        _isAttacking = true;
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
        _isAttacking = false;
        movementScript.isControlBlocked = false;

        yield return new WaitForSeconds(2.0f);
        _canUseSkeleport = true;
    }
}

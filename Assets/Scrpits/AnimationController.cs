using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    public Transform rigTransform;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //conditions
    }

    public void Fall()
    {
        animator.SetBool("Falling", true);
    }

    public void Land()
    {
        animator.SetBool("Surfing", true);
    }

    public void Dance()
    {
        animator.SetBool("Dancing", true);
    }

    public void Death()
    {
        animator.SetBool("isDead", true);
        if (!isDead)
        {
            isDead = true;

            animator.enabled = false;

            //foreach (Rigidbody item in rigTransform.GetComponentInChildren<RigidBody>())
            //{
            //    item.isKinematic = false;
            //    item.useGravity = true;
            //}

            //foreach (Collider item in rigTransform.GetComponentInChildren<Collider>())
            //{
            //    item.tag = "untagged";
            //    item.isTrigger = false;
            //}
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Land");
        if (other.CompareTag("Collect"))
        {
            Land();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collect"))
        {
            Land();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collect"))
        {
            Fall();
        }
    }
}

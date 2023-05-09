using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public Transform rigTransform;

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


    public void Land()
    {
        animator.SetBool("Surfing", true);
    }

    public void Dance()
    {
        animator.SetBool("Dancing", true);
    }

    public void Fall()
    {
        Debug.Log("Fall");
        animator.SetBool("Falling", true);
    }

    public void Death()
    {
        animator.SetBool("isDead", true);

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


}

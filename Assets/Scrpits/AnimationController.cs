using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
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
        animator.SetBool("Jump", true);
    }

    public void Death()
    {
        animator.SetBool("isDead", true);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Surfing", true);
        }
    }

}

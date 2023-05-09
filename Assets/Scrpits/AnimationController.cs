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
        Debug.Log("Dance");
        animator.SetBool("Dancing", true);
    }

    public void Death()
    {
        Debug.Log("Death");
        animator.SetBool("isDead", true);
        animator.SetBool("Surfing", false);

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

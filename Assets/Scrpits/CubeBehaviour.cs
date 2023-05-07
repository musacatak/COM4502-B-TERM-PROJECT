using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    [SerializeField] private CubeHandler cubeHandler;

    public Ease easeCurve;

    public float easeDuration;

    bool isLastCube = false;

    private void Start()
    {
        cubeHandler = GameObject.FindObjectOfType<CubeHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent != null && (other.CompareTag("Obstacle") || other.CompareTag("X1")))
        {
            transform.parent = null;
            cubeHandler.RemoveBlock(this.gameObject);
            if(other.tag=="X1")
            {
                cubeHandler.UpdateGroundLevel(0.5f);
            }
            if (isLastCube)
            {
                FindObjectOfType<GameManager>().PlayerFailed();
            }
            //this.GetComponent<BoxCollider>().size = new Vector3(0.0099f, 0.01f, 0.0099f);
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            this.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(this.gameObject, 5f);
        }
    }

    public void updateHeight(float _y, float delay = 0f)
    {
        float myFloat = transform.position.y;
        transform.DOMoveY(_y, easeDuration).SetDelay(delay).SetEase(easeCurve);//.OnComplete....
    }

    public void setLastCube(bool _isLast)
    {
        isLastCube = _isLast;
    }

    public bool getIsLastCube()
    {
        return isLastCube;
    }
}

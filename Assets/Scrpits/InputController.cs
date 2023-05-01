using UnityEngine;

public class InputController : MonoBehaviour
{

    private float horizontalValue;
    public float HorizontalValue
    {
        get { return horizontalValue; }
    }
    void Update()
    {
        HorizontalInput();
    }

    private void HorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }
}
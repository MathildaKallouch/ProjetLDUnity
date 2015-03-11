using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Vector3 _offset;
    public Transform _target;
    public float _rotateSpeed;

    void Start()
    {
        KeyBinder.Instance.DefineActions("MouseX", new AxisActionConfig(KeyType.Head, 0, MouseX));
        KeyBinder.Instance.DefineActions("MouseY", new AxisActionConfig(KeyType.Head, 0, MouseY));
    }

    void MouseX(float value)
    {
        Vector3 currEuler = transform.localRotation.eulerAngles;
        currEuler.y += (-value * _rotateSpeed);

        if (currEuler.y < 0  || currEuler.y > 270 && currEuler.y < 360)
        {
            currEuler.y = 0f;
        }

        if (currEuler.y > 180 && currEuler.y < 270)
        {
            currEuler.y = 180f;
        }

        transform.localRotation = Quaternion.Euler(currEuler);
        //_camera.transform.Rotate(Vector3.right, (-value * _rotateSpeed));
    }

    void MouseY(float value)
    {
        Vector3 currEuler = transform.localRotation.eulerAngles;
        currEuler.x += (-value * _rotateSpeed);

        if (currEuler.x >= 90 && currEuler.x < 180)
        {
            currEuler.x = 90f;
        }

        if (currEuler.x > 180 && currEuler.x < 270)
        {
            currEuler.x = 270;
        }

        transform.localRotation = Quaternion.Euler(currEuler);
        //_camera.transform.Rotate(Vector3.right, (-value * _rotateSpeed));
    }
}

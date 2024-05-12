using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 1.0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;

        float eulerAngelX = transform.eulerAngles.x - (mouseY * _mouseSensitivity);
        float eulerAngelY = transform.eulerAngles.y + (mouseX * _mouseSensitivity);
        float eulerAngelZ = transform.eulerAngles.z;
        transform.localEulerAngles = new Vector3(eulerAngelX, eulerAngelY, eulerAngelZ);
    }
}

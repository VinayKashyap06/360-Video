using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    void Update()
    {
        float v=Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        transform.eulerAngles += new Vector3(-v,h,0);
    }
}

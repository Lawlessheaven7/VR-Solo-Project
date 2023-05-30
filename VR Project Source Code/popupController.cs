using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupController : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //controll the rotation of the canvas

        transform.LookAt(Camera.main.transform);
    }
}

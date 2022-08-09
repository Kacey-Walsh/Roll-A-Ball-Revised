using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopRotator : MonoBehaviour
{

        public float spinSpeed = 4.0f;
        
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 0, 0) * Time.deltaTime * spinSpeed);
    }
}

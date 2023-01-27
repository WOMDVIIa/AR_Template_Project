using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rorationSpeed;
    //public Quaternion qwe = new Quaternion();// (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //qwe.x += 1;
        gameObject.transform.Rotate(0, 0, rorationSpeed, Space.World);
    }
}

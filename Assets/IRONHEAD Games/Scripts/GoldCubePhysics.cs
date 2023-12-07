using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCubePhysics : MonoBehaviour
{
    public float force = 100;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(force, 0, 0), ForceMode.Acceleration);
    }
}

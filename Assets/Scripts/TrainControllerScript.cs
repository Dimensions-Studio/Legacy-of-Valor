using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControllerScript : MonoBehaviour
{
    [SerializeField] int speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * speed);

    }
}

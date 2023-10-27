using MalbersAnimations.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControllerScript : MonoBehaviour
{
    public float TopSpeed;
    public float speed;
    public static TrainControllerScript Instance;

    private void Start()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * speed);
    }
}

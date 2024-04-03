using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new UnityEngine.Vector3(-0.46f, 2.505f, 0f);
        }
    }
}

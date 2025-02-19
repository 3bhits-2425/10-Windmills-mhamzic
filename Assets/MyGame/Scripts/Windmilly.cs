using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    public Animation rotation;

    // Start is called before the first frame update
    private void Start()
    {
        rotation.Stop();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rotation.Play();
        }
    }
}

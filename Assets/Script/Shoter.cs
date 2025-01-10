using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoter : MonoBehaviour
{
    public Shot shot;

    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if(input.Fire)
        {
            shot.Fire();
        }
    }
}

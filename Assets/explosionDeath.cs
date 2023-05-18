using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
public class explosionDeath : MonoBehaviour
{

    [SerializeField] float liveTime = 1.5f;
    float living;
    // Update is called once per frame
    void Update()
    {
        living+=Time.deltaTime;
        if (living > liveTime)
        {
            
            LeanPool.Despawn(this);
        }

        
    }


    private void OnEnable()
    {
        living = 0;
    }
}

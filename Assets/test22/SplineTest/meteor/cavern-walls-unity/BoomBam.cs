using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Lean.Pool;


public class BoomBam : MonoBehaviour
{
    SplineComputer splineComputer;
    SplineFollower splineFollower;
    // Start is called before the first frame update

    private void Awake()
    {
       
    }
    void Start()
    {
       // if (splineComputer == null) splineComputer = GameObject.FindWithTag("Spline1").GetComponent<SplineComputer>();
        if (splineFollower == null) splineFollower = GetComponent<SplineFollower>();

        splineFollower.spline = splineComputer;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(10f);
        LeanPool.Despawn(this);
    }
}

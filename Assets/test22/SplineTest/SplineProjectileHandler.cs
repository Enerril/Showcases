using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Lean.Pool;

public class SplineProjectileHandler : MonoBehaviour
{
    SplineFollower splineFollower;
    Rigidbody rb;
    [SerializeField] float releasePowerMult;
    [SerializeField] float randomAimMult;
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        splineFollower = GetComponent<SplineFollower>();
        rb = GetComponent<Rigidbody>();
    } 
     
        
    public void ReleaseFromSpline()
    {
        var g = splineFollower.result.forward * splineFollower.followSpeed;
        //Debug.Log(g);
        rb.velocity = g * releasePowerMult;
        rb.velocity += (Random.insideUnitSphere * randomAimMult).normalized;
        rb.AddTorque(7 * Random.insideUnitSphere);
        this.splineFollower.enabled = false;
        


    }

    private void OnEnable()
    {
        //Debug.Log("HERE1");
        if (splineFollower == null)
        {
            //Debug.Log("HERE2");
            splineFollower = GetComponent<SplineFollower>();
            
        }
        else
        {
            splineFollower.enabled = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // explosion and hit
        LeanPool.Spawn(explosion,transform.position,Quaternion.identity,null);
        LeanPool.Despawn(this);

    }

}

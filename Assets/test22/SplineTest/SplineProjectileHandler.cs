using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Lean.Pool;

public class SplineProjectileHandler : MonoBehaviour
{
    //SplineFollower splineFollower;
    Rigidbody rb;
    [SerializeField] float releasePowerMult;
    [SerializeField] float randomAimMult;
    [SerializeField] GameObject explosion;
    public int TeamNumber;
    [SerializeField]bool released;
    // Start is called before the first frame update
    void Start()
    {
        released = true;
        //Debug.Log("HERE1");
        /*
        if (splineFollower == null)
        {
            //Debug.Log("HERE2");
            splineFollower = GetComponent<SplineFollower>();
            // splineFollower.RebuildImmediate();
        }
        else
        {
            splineFollower.enabled = true;
            // splineFollower.RebuildImmediate();
        }*/

        rb = GetComponent<Rigidbody>();
    } 
     
        
    public void ReleaseFromSpline()
    {
        /*
        
        var g = splineFollower.result.forward * splineFollower.followSpeed;
        //Debug.Log(g);
        this.splineFollower.enabled = false;
        rb.velocity = g * releasePowerMult;
        rb.velocity += (Random.insideUnitSphere * randomAimMult).normalized;
        rb.AddTorque(7 * Random.insideUnitSphere);

        released = true;

        */
    }

    private void OnEnable()
    {
        /*
        //Debug.Log("HERE1");
        if (splineFollower == null)
        {
            //Debug.Log("HERE2");
            splineFollower = GetComponent<SplineFollower>();
           // splineFollower.RebuildImmediate();
        }
        else
        {
            splineFollower.enabled = true;
           // splineFollower.RebuildImmediate();
        }*/
        released = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // explosion and hit
        if (collision.gameObject.layer == 9)
        {
            if (collision.gameObject.GetComponent<NC_Stater>().MyTeamNumber != TeamNumber)
            {
                //this.splineFollower.enabled = true;
                //splineFollower.RebuildImmediate();
                LeanPool.Spawn(explosion, transform.position, Quaternion.identity, null);
                LeanPool.Despawn(this.gameObject);
            }
        }
            
        if((collision.gameObject.layer == 7 || collision.gameObject.layer == 10 || collision.gameObject.layer == 0) && released)
        {
            //this.splineFollower.enabled = true;
            //splineFollower.RebuildImmediate();
            LeanPool.Spawn(explosion, transform.position, Quaternion.identity, null);
            LeanPool.Despawn(this.gameObject);
            
        }

    }

    private void OnDisable()
    {
        released = false;
    }

}

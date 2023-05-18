using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Lean.Pool;

public class fireballSpawber : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] int projectileAmount;
    GameObject S_comp;
    SplineFollower splineFollower;
    SplineComputer splineComputer;
    SplineFollower splineFollowerTemp;
    [SerializeField]int spawnedAmount;
    [SerializeField]bool isActive;


    [SerializeField] float spawnDelay = 0.3f;
    float spawnTimeTrack;
    // Start is called before the first frame update
    void Start()
    {


      
    }
    private void OnEnable()
    {
        splineFollower = projectile.GetComponent<SplineFollower>();
        isActive=true;
        splineComputer = this.GetComponent<SplineComputer>();
        splineComputer.RebuildImmediate();
        //splineFollower.RebuildImmediate();
        //splineFollower.SetDistance(Random.Range(0.1f, 20f));
        //StartCoroutine(SpawnFireballs());
        spawnTimeTrack = 0;
        spawnedAmount = 0;
    }

    private void Update()
    {
        if (spawnedAmount < projectileAmount)
        {
            spawnTimeTrack += Time.deltaTime;
                if (spawnTimeTrack > spawnDelay)
                {

                    var p = LeanPool.Spawn(projectile);

                    splineFollowerTemp = p.GetComponent<SplineFollower>();
                    splineFollowerTemp.spline = splineComputer;
                    splineFollowerTemp.RebuildImmediate();
                    spawnedAmount++;

                }
        }
        else
        {
            //LeanPool.Despawn(this);
        }
        
    }
    IEnumerator SpawnFireballs()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(0.3f);

           
           // splineFollowerTemp.SetDistance(Random.Range(1f, 5f));
            //Debug.Log(splineFollowerTemp);
            // Debug.Log(splineFollowerTemp.spline);
            // Debug.Log(splineComputer);
           
            //Debug.Log(splineFollowerTemp.spline);
            

           

        }


    }

}

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
    [SerializeField]public int TeamNumber;

    [SerializeField] float spawnDelay = 0.3f;
    float spawnTimeTrack;
    // Start is called before the first frame update
    void Start()
    {
        /*
        splineComputer = GetComponent<SplineComputer>();
        splineComputer.RebuildImmediate();
        splineFollower = projectile.GetComponent<SplineFollower>();
        isActive = true;

        spawnTimeTrack = 0;
        spawnedAmount = 0;

        StartCoroutine(SpawnFireballs());*/
    }
    private void OnEnable()
    {
 
        splineComputer = GetComponent<SplineComputer>();
        splineComputer.RebuildImmediate();
        splineFollower = projectile.GetComponent<SplineFollower>();
        isActive=true;
        
        //splineFollower.RebuildImmediate();
        //splineFollower.SetDistance(Random.Range(0.1f, 20f));
        StartCoroutine(SpawnFireballs());
        spawnTimeTrack = 0;
        spawnedAmount = 0;
    }
    
    private void Update()
    {
        if (spawnedAmount > projectileAmount)
        {
            isActive = false;
            StopAllCoroutines();
            spawnedAmount = 0;
        }

        /*
        if (spawnedAmount < projectileAmount)
        {
            spawnTimeTrack += Time.deltaTime;
                if (spawnTimeTrack > spawnDelay)
                {

                    var p = LeanPool.Spawn(projectile);
                    p.GetComponent<SplineProjectileHandler>().TeamNumber = TeamNumber;
                    splineFollowerTemp = p.GetComponent<SplineFollower>();
                    splineFollowerTemp.spline = splineComputer;
                    splineFollowerTemp.RebuildImmediate();

                spawnTimeTrack = 0;
                    spawnedAmount++;

                }
        }
        else
        {
            spawnTimeTrack += Time.deltaTime;
            if (spawnTimeTrack>1)
            {
                LeanPool.Despawn(this);
            }
        }
        */
    }
    
    IEnumerator SpawnFireballs()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(spawnDelay);


            var p = LeanPool.Spawn(projectile);
            p.GetComponent<SplineProjectileHandler>().TeamNumber = TeamNumber;
            splineFollowerTemp = p.GetComponent<SplineFollower>();
            splineFollowerTemp.spline = splineComputer;
            splineFollowerTemp.RebuildImmediate();
            spawnedAmount++;


        }


    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Lean.Pool;
public class NC_Stater : MonoBehaviour, IGridUserSP
{
    [SerializeField] bool _isFighting;
    public GameObject myGameObject  => this.gameObject;
    [SerializeField] GameObject projectile;
    [SerializeField] byte _myTeamNumber;
    [SerializeField] Rigidbody projRigidbody;
    [SerializeField] float projSpeed = 2;
    //[SerializeField] byte someByte;
    // test values for nodeCanvas to test out behaviorTrees
    // 4 states. 1 - idle, eval enemies. 2 - run, if near. 3 - fight, until target dead or die. 4 - dead.
    [SerializeField] GameObject[] enemiesFrom_SP_GridTiles = new GameObject[10];  //for now can't have more than 10. why? CAUSE.

    //[SerializeField] GameObject[] AllUnitsFromTiles=new GameObject[10]; 

    byte enemiesCounterSP;    // for iterating enemiesFrom_SP_GridTiles

    IAstarAI aiPathf;


    [SerializeField] bool _isIdle;
    [SerializeField] bool _isPaused;
    [SerializeField] bool _isRunning;
    [SerializeField] bool _isStopped;
    [SerializeField] GameObject _target;
    [SerializeField] int _agentID;
    [SerializeField] int _currentTileID;
    public int CurrentTileID { get => _currentTileID; set => _currentTileID=value; }
    public int ID { get => _agentID;}
    public bool isFighting { get => _isFighting; set { _isFighting = value; } }

    public bool isIdle { get => _isIdle; set => _isIdle = value; }
    public bool isPaused { get => _isPaused; set => _isPaused = value; }
    public bool isRunning { get => _isRunning; set => _isRunning = value; }
    public bool isStopped { get => _isStopped; set => _isStopped = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public byte MyTeamNumber { get => _myTeamNumber; set => _myTeamNumber = value; }

    Vector3 tempVector;
    public void EnteredTile(TriggerColliderSpacePartitionTile tile)
    {
        CurrentTileID=tile.gridTileID;
    }


    private void Awake()
    {
        _agentID = StaticCounters.GetNewAgentID();
        aiPathf = GetComponent<IAstarAI>();


    }
    private void Start()
    {
        isIdle = true;
    }

    public bool SearchForEnemies()
    {
        // we search nearby territory using Space Partitioning... in the next version ??

        var nearbyEnemies = TriggerColliderSpacePartitionTile.GetAllNeighborUnits(CurrentTileID);
        //AllUnitsFromTiles = TriggerColliderSpacePartitionTile.GetAllNeighborUnits(CurrentTileID);

        for (int i = 0; i < nearbyEnemies.Length; i++)
        {
            if(enemiesCounterSP>=9)break;

            if (nearbyEnemies[i].GetComponent<NC_Stater>().MyTeamNumber != MyTeamNumber)
            {
                enemiesFrom_SP_GridTiles[enemiesCounterSP] = nearbyEnemies[i];
                enemiesCounterSP++;
            }
           
        }
        float temp = 50000;
        for (int i = 0; i < enemiesFrom_SP_GridTiles.Length; i++)
        {
            if (enemiesFrom_SP_GridTiles[i].gameObject != null)
            {
                tempVector = enemiesFrom_SP_GridTiles[i].gameObject.transform.position - transform.position;
                float sqrLen = tempVector.sqrMagnitude;

                if (sqrLen < temp * temp)
                {
                    temp = sqrLen;
                    Target = enemiesFrom_SP_GridTiles[i].gameObject;
                    // we have target, exit idle go into running state (for now, distance check later)
                    isIdle = false;
                    isRunning = true;


                }
            }
           
        }

        if(_target!=null) return true; else return false;

       // return false;
    }

    public void RunningToTheTarget()
    {
        aiPathf.canMove = true;
        aiPathf.destination = Target.transform.position;

        if (aiPathf.reachedDestination == true)
        {

            isRunning = false;
            isFighting = true;
            aiPathf.canMove = false;

        }


    }

    public void SpawnSplineCast()
    {
        var pos = transform.position + transform.forward+new Vector3(0,1,0);

        var g= LeanPool.Spawn(projectile, pos, Quaternion.identity, null);
      projRigidbody= g.GetComponent<Rigidbody>();

        projRigidbody.AddForce(transform.forward* projSpeed+(Random.insideUnitSphere*0.2f), ForceMode.Impulse);

        g.GetComponent<SplineProjectileHandler>().TeamNumber=MyTeamNumber;
        
    }

   
}

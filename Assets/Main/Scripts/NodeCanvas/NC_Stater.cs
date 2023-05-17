using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Stater : MonoBehaviour, IGridUserSP
{
    [SerializeField] bool _isFighting;
    public GameObject myGameObject  => this.gameObject;
    // test values for nodeCanvas to test out behaviorTrees
    // 4 states. 1 - idle, eval enemies. 2 - run, if near. 3 - fight, until target dead or die. 4 - dead.
    [SerializeField] public int MyTeamNumber;

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


    public void EnteredTile(TriggerColliderSpacePartitionTile tile)
    {
        CurrentTileID=tile.gridTileID;
    }


    private void Awake()
    {
        _agentID = StaticCounters.GetNewAgentID();
    }
    private void Start()
    {
        isIdle = true;
    }

    public bool SearchForEnemies()
    {
        // we search nearby territory using Space Partitioning... in the next version ??
        return true;
    }


   
}

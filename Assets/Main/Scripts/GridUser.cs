using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUser : MonoBehaviour, IGridUserSP
{

    public int CurrentTileID { get; set; }
    public int ID { get; set; }

    public GameObject myGameObject => this.gameObject;

    void Start()
    {
        ID = Random.Range(0, 5000000);
    }
    public void EnteredTile(TriggerColliderSpacePartitionTile tile)
    {
        CurrentTileID=tile.gridTileID;
    }

}

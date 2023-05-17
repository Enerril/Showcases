using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TriggerColliderSpacePartitionTile : MonoBehaviour
{

    public int gridTileID;
    public int gridUsersSPPositionerCounter;
    public int gridUsersSPCurrentAmount;

    IGridUserSP[] gridUsersSP=new IGridUserSP[100];
    //public GameObject[] gridUsersSP = new GameObject[100];
    public int[] gridUnitIDs = new int[100];
    BoxCollider boxCollider;
    IGridUserSP gridUserSP;
    private void Start()
    {
        gridUsersSPPositionerCounter = 0;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {

        AddUnitToTheGridArray(other.gameObject);

    }

    private void OnTriggerExit(Collider other)
    {
        RemoveUnitFromTheGridArray(other.gameObject);
    }

    public void AddUnitToTheGridArray(GameObject go)
    {

        //Debug.Log(go);
        gridUserSP = go.GetComponent<IGridUserSP>();
        //gridUserSP = go.GetComponent(typeof(IGridUserSP)) as IGridUserSP;
        //Debug.Log(gridUserSP);
        //GetComponent(typeof(IEnemy)) as IEnemy;
        gridUserSP.EnteredTile(this);
        gridUsersSP[gridUsersSPPositionerCounter] = gridUserSP;
        gridUnitIDs[gridUsersSPPositionerCounter] = gridUserSP.ID;

        //Debug.Log($"'{unitClass.UnidID}' Gameobject entered Grid tile '{gridID}'");
        IncreaseCounter();
    }

    public void RemoveUnitFromTheGridArray(GameObject go)
    {
        var a = gridUserSP = go.GetComponent<IGridUserSP>();

        for (int i = 0; i < gridUsersSP.Length; i++)
        {
            if (gridUserSP.ID == gridUnitIDs[i])
            {
                gridUsersSP[i] = null;
                gridUnitIDs[i] = 0;
                gridUsersSPCurrentAmount--;
                //Debug.Log($"'{unitClass.UnidID}' Gameobject removed Grid tile  '{gridID}' list");
                break;
            }


        }

    }

    private void IncreaseCounter()
    {
        // cant have big list for each tiles or too many iterations. Therefore we reset collider when the end of array reached. 
        // reset array, counter. disable/enable collider to re-add units.
        gridUsersSPPositionerCounter++;
        gridUsersSPCurrentAmount++;
        if (gridUsersSPPositionerCounter >= gridUsersSP.Length)
        {
            var k = gridUsersSP.Length;
            //gridUsersSP = new GameObject[k];
            Array.Clear(gridUsersSP,0,gridUsersSP.Length);
            gridUnitIDs = new int[k];
            gridUsersSPPositionerCounter = 0;
            boxCollider.enabled = false;
            StartCoroutine(EnableCollider());
        }


    }

    IEnumerator EnableCollider()
    {
        yield return 0;

        boxCollider.enabled = true;
    }

    public IGridUserSP[] UnitsInTile()
    {
        return gridUsersSP;
    }

}

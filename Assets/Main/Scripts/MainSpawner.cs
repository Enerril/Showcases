using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEditor.PlayerSettings;
using Lean.Pool;
public class MainSpawner : MonoBehaviour
{
    AstarPath astar;
    AstarData astar_Data;
    [SerializeField]GameObject prefab1;
    [SerializeField] GameObject prefab2;
    GridGraph grid;
    [SerializeField] int spawmAmount=20;
    [SerializeField] bool isActive;
    Vector3 pos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {

       // astar = GameObject.FindWithTag("Pather").GetComponent<AstarPath>();
        //astar_Data=astar.GetComponent<AstarData>();

        if (isActive)
        {
            grid = AstarPath.active.data.gridGraph;
            


            for (int i = 0; i < spawmAmount; i++)
            {

                pos = GetRandomOkNode();
                Instantiate(prefab1, pos, Quaternion.identity);
                pos = GetRandomOkNode();
                Instantiate(prefab2, pos, Quaternion.identity);
            }
        }

        StartCoroutine(SpawnUnits());

    }

    IEnumerator SpawnUnits()
    {
        while (true&&isActive)
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < spawmAmount; i++)
            {

                pos = GetRandomOkNode();
                Instantiate(prefab1, pos, Quaternion.identity);
                pos = GetRandomOkNode();
                Instantiate(prefab2, pos, Quaternion.identity);
            }
        }
    }


    private Vector3 GetRandomOkNode()
    {
        var randomNode = grid.nodes[Random.Range(0, grid.nodes.Length)];
        Vector3 pos=new Vector3();
        if (randomNode.Walkable == true)
        {
            pos = (Vector3)randomNode.position;
            return pos;
        }
        else
        {
            pos =GetRandomOkNode();
            return pos;
        }



    }

  
}

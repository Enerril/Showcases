using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEditor.PlayerSettings;

public class MainSpawner : MonoBehaviour
{
    AstarPath astar;
    AstarData astar_Data;
    [SerializeField]GameObject prefab1;
    [SerializeField] GameObject prefab2;
    GridGraph grid;
    [SerializeField] int spawmAmount=20;
    [SerializeField] bool isActive;

    // Start is called before the first frame update
    void Start()
    {

       // astar = GameObject.FindWithTag("Pather").GetComponent<AstarPath>();
        //astar_Data=astar.GetComponent<AstarData>();

        if (isActive)
        {
            grid = AstarPath.active.data.gridGraph;
            Vector3 pos = new Vector3();


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

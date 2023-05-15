using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderSpacePartition : MonoBehaviour
{
    Transform[] transformGrid = new Transform[100];
    [SerializeField] GameObject gridCollider;
    [SerializeField] bool enabled;
    //[SerializeField] Vector3 gridStartPos;
    BoxCollider boxCollider;
    Vector3 transformGridPoint;

    int counter;
    //Vector3 transformGridPoint;
    // Start is called before the first frame update
    void Start()
    {

        // transformGridPoint = gridStartPos;
        if (enabled)
        {
            for (int i = 0; i < 10; i++)
            {
                transformGridPoint = transform.position;
                transformGridPoint.z += i * 100;

                for (int j = 0; j < 10; j++)
                {

                    transformGridPoint.x = j * 100 + transform.position.x;
                    //Debug.Log(transformGridPoint);
                    var k = Instantiate(gridCollider, transformGridPoint, Quaternion.identity);
                    var b = k.gameObject.GetComponent<TriggerColliderSpacePartitionTile>();
                    b.gridTileID = counter;
                    counter++;
                    k.transform.parent = transform;

                    transformGrid[i + j] = k.transform;

                }


            }




            boxCollider = gridCollider.GetComponent<BoxCollider>();
        }

       // Debug.Log(boxCollider.bounds.size);
    }

   

}

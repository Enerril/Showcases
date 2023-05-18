
using UnityEngine;
using System.Collections;
using Pathfinding;

[HelpURL("http://arongranberg.com/astar/documentation/stable/class_wandering_destination_setter.php")]
public class WanderingDestinationSetter : MonoBehaviour
{
    public float radius = 20;
    [SerializeField] bool _isActive;
    
    public bool isActive { get { return _isActive; } set { _isActive = value; } }


    IAstarAI ai;

    void Start()
    {
        ai = GetComponent<IAstarAI>();
    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * radius;
         
        point.y = 0;
        point += ai.position;
        return point;
    }
    /*
    void Update()
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)&& isActive)
        {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
    }*/
}


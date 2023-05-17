using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCounters 
{
    public static int AgentID=0;


    public static int GetNewAgentID()
    {
        AgentID++;
        return AgentID;
    }
}

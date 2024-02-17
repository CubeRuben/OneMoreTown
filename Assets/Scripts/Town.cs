using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Town : MonoBehaviour, IGameSimulatable
{

    public int counter = 0;

    void Start()
    {
        GameSimulationManager.Instance.AddSimulatable(this);
    }

    void FixedUpdate()
    {
        
    }

    public void SimulationUpdate()
    {
        counter++;

        Debug.Log("Tick " + counter);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

[RequireComponent(typeof(LocalMarket))]
public class Town : MonoBehaviour, IGameSimulatable
{
    [SerializeField] public string Name { get; private set; }

    [SerializeField]
    private List<Population> _townPopulation = new List<Population>();

    void Start()
    {
        GameSimulationManager.Instance.AddSimulatable(this);
    }

    void FixedUpdate()
    {
        
    }

    public void SimulationUpdate()
    {
    
    }
}

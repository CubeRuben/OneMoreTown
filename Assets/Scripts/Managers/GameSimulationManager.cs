using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameSimulationManager : MonoBehaviour
{
    struct SimulationSpeed 
    {
        private int _speed;
        private int _maxSpeed;

        public SimulationSpeed(int maxSpeed) 
        {
            _maxSpeed = maxSpeed;
            _speed = 1;
        }

        public int GetSpeed() {  return _speed; }
        public int GetIndex() {  return _speed - 1; }

        public void SetSpeed(int speed) 
        { 
            _speed = Mathf.Clamp(speed, 1, _maxSpeed); 
        }

        public void AddSpeed(int speed) 
        {
            SetSpeed(_speed + speed);
        }
    }

    public int CurrentSimulationSpeed { get { return _currentSpeed.GetSpeed(); } }
    public bool OnPause { get { return _updateCoroutine == null; } }

    [SerializeField] private List<float> waitTimes = new List<float>(3);

    private List<IGameSimulatable> _simulatables;
    private List<WaitForSeconds> _sleepTimes;

    private SimulationSpeed _currentSpeed;

    private Coroutine _updateCoroutine;
    public static GameSimulationManager Instance { get; private set; }
    
    

    void Start()
    {
        if (Instance == null)
            Instance = this;

        _simulatables = new List<IGameSimulatable>();
        _currentSpeed = new SimulationSpeed(waitTimes.Count);
        _sleepTimes = new List<WaitForSeconds>();
        waitTimes.ForEach(time => { _sleepTimes.Add(new WaitForSeconds(time)); });

        StartSimulation();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause")) 
        {
            if (OnPause) 
            {
                StartSimulation();
            }
            else 
            {
                StopCoroutine(_updateCoroutine);
                _updateCoroutine = null;
            }
        }

        if (Input.GetButtonDown("AddSimSpeed")) 
        {
            _currentSpeed.AddSpeed(1);
        }

        if (Input.GetButtonDown("ReduceSimSpeed")) 
        { 
            _currentSpeed.AddSpeed(-1); 
        }
    }

    private void StartSimulation() 
    {
        _updateCoroutine = StartCoroutine(SimulationUpdate());
    }

    IEnumerator SimulationUpdate() 
    {
        while (true) 
        {
            UpdateSimulatables();

            yield return _sleepTimes[_currentSpeed.GetIndex()];
        }
    }

    private void UpdateSimulatables() 
    {
        _simulatables.ForEach(simulatable => { simulatable.SimulationUpdate(); });
    }

    public void AddSimulatable(IGameSimulatable simulatable) 
    {
        _simulatables.Add(simulatable);
    }

    public void RemoveSimulatable(IGameSimulatable simulatable) 
    {
        _simulatables.Remove(simulatable);
    }
}

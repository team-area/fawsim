using UnityEngine;
using System.Collections;

public class WearableToggle : MonoBehaviour {
    [SerializeField]
    private OverheadDoorToggle door;
    [SerializeField]
    private ScenarioData scenarioData;

    void Update() {
        scenarioData.Set(door.IsOpen);
    }
}
using UnityEngine;
using System.Collections;

public class WearableToggle : MonoBehaviour {
    [SerializeField]
    private OverheadDoorToggle door;

    void Update() {
        ScenarioData.Instance.Set(door.IsOpen);
    }
}
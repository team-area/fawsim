using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenarioSelector : MonoBehaviour {
    [SerializeField]
    private OverheadDoorToggle door;
    [SerializeField]
    private BinType binType;
    [SerializeField]
    private string scenarioName;
    [SerializeField]
    private StartPosition startPosition;
    [SerializeField]
    private bool isFacingFront;

    private void Update() {
        if (door.IsOpen) {
            ScenarioData.Instance.Set(binType, scenarioName, startPosition, isFacingFront);
            SceneManager.LoadScene("Main");
        }
    }
}
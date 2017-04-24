using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDUpdate : MonoBehaviour {

    [SerializeField]
    private Text text;

    // Use this for initialization
    private void Start() {
        ScenarioData sd = GameObject.Find("ScenarioData").GetComponent<ScenarioData>();
        text.text = string.Format("Scenario={0} | Wearable={1}", sd.ScenarioName, sd.IsWearableEnabled);
    }
}

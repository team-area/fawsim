using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSystem : MonoBehaviour {
    [SerializeField]
    private Text hud;
    [SerializeField]
    private ScenarioData sd;
    [SerializeField]
    private WearableToggle wearableToggle;
    [SerializeField]
    private ScenarioSelector scenario1Selector;
    [SerializeField]
    private ScenarioSelector scenario2Selector;
    [SerializeField]
    private ScenarioSelector scenario3Selector;

    private NameData nameData;

    private void Start() {
        nameData = GameObject.Find("NameData").GetComponent<NameData>();
        Debug.Log("Hello " + nameData.Username);
    }

    private void Update() {

    }
}

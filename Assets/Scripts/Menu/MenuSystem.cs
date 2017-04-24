using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSystem : MonoBehaviour {
    [SerializeField]
    private Text hud;
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
        PlayerStats.Instance.Name = nameData.Username;
        string directoryPath = string.Format("{0}/{1}", Application.dataPath, "Records");
        System.IO.Directory.CreateDirectory(directoryPath);
        System.IO.File.WriteAllText(
            directoryPath + "/" + PlayerStats.Instance.Name + ".JSON",
            JsonUtility.ToJson(PlayerStats.Instance, true));
    }
}

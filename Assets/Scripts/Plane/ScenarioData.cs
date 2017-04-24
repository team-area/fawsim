using UnityEngine;

public class ScenarioData : MonoBehaviour {
    public BinType BinToNotHaveItem;
    public string ScenarioName;
    public StartPosition PlayerStartPos;
    public bool IsFacingFront;
    public bool IsWearableEnabled;

    private static ScenarioData instance;

    public static ScenarioData Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<ScenarioData>();
            }
            return instance;
        }
    }

    public void Set(BinType binType, string scenarioName, StartPosition startPos, bool isFacingFront) {
        this.BinToNotHaveItem = binType;
        this.ScenarioName = scenarioName;
        this.PlayerStartPos = startPos;
        this.IsFacingFront = isFacingFront;
    }

    public void Set(bool isWearableEnabled) {
        this.IsWearableEnabled = isWearableEnabled;
    }

    public void Start() {
        DontDestroyOnLoad(this);
        if (Instance != this) {
            DestroyImmediate(this.gameObject);
        }
    }
}
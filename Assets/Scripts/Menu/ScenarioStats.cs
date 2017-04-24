using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class ScenarioStats {
    public string ScenarioName;
    public int BinsOpened;
    public int WearableCalls;
    public float SecondsElapsed;
    public bool IsWearableEnabled;

    public ScenarioStats(string scenarioName, int binsOpened, int wearableCalls, float secondsElapsed, bool isWearableEnabled) {
        this.ScenarioName = scenarioName;
        this.BinsOpened = binsOpened;
        this.WearableCalls = wearableCalls;
        this.SecondsElapsed = secondsElapsed;
        this.IsWearableEnabled = isWearableEnabled;
    }
}
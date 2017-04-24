using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerStats {
    public string Name;
    public List<ScenarioStats> ScenarioStats;

    private static PlayerStats instance;

    public static PlayerStats Instance {
        get {
            if (instance == null) {
                instance = new PlayerStats();
            }
            return instance;
        }
    }

    public PlayerStats() {
        ScenarioStats = new List<ScenarioStats>();
    }
}

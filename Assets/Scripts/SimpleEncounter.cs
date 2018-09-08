using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEncounter {

    public int Attempted { get; set; }
    public SimpleEncounterData Data { get; private set; }

    public SimpleEncounter(SimpleEncounterData simpleEncounter)
    {
        Data = simpleEncounter;
    }

    public SimpleEncounter(short id) {
        Data = GameData.SimpleEncounter[id];
    }
}

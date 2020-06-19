using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

// ReSharper disable once UnusedMember.Global
[SuppressMessage("ReSharper", "CheckNamespace")]
public class Constants
{
    // Ticks per second
    public static int TICK_RATE = 20;

    public static float TICK_INTERVAL = 0.05f;
}

// Numbered list of all the resource types, constant obv
public enum ResourceType
{
    Kibble,
    Grass,
    Cows,
    Puppies,
    Milkbones,
    Cowbones,
    Bonemeal
}

public enum PurchaseType
{
    KibbleTree,
    DogHouse
}

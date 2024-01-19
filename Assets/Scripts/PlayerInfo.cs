using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo
{
    private static Checkpoint lastCheckpoint;

    public static void UpdateLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpoint = checkpoint;
    }
}

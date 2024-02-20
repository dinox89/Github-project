using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESPAWADS : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();
        checkpointManager.RegisterCheckpoint(transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
   
    private Transform lastCheckpoint;

    public void RegisterCheckpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public Vector3 GetLastCheckpointPosition()
    {
        if (lastCheckpoint != null)
        {
            return lastCheckpoint.position;
        }
        else
        {
            // Si aucun point de contrôle n'a été enregistré, retournez une position par défaut.
            return Vector3.zero;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGoal : MonoBehaviour
{
    [SerializeField] Referee referee;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Goal")) {
            referee.UpdateScore();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Referee : MonoBehaviour
{
    int playerScore = 0;
    [SerializeField] TextMeshProUGUI scoreboard;
    [SerializeField] GameObject puck, mallet;

    public void UpdateScore() {
        playerScore++;
        scoreboard.text = $"Score: {playerScore}";
        ResetPuck(new Vector3(0, 0.01f, 0));
        ResetMallet(new Vector3(0, 0.05f, -3));
    }

    public void ResetPuck(Vector3 position) {
        var puckBody = puck.GetComponent<Rigidbody>();
        puck.transform.position = position;
        puckBody.Sleep();
    }

    public void ResetMallet(Vector3 position) {
        var malletBody = mallet.GetComponent<Rigidbody>();
        mallet.transform.position = position;
        malletBody.Sleep();
    }
}

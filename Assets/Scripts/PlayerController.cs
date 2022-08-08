using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerBody;
    float horizontalInput, verticalInput, shootInput;
    bool ignoreMovement = false;
    const float forceRate = 10, movementForce = 10;

    void ReadInputs() {
        if (!ignoreMovement) {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        if (Input.GetKey(KeyCode.Space)) {
            shootInput += forceRate * Time.deltaTime;
            playerBody.Sleep();
            Cursor.visible = true;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
            var targetPos = hit.point;
            targetPos.y = transform.position.y;
            playerBody.AddForce(shootInput * (targetPos - transform.position).normalized, ForceMode.Impulse);
            shootInput = 0;
            Cursor.visible = false;
        }
    }

    Vector3 ComputeMovement() {
        return movementForce * (horizontalInput * Vector3.right + verticalInput * Vector3.forward);
    }

    // Start is called before the first frame update
    void Start() {
        playerBody = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        ReadInputs();
    }

    void FixedUpdate() {
        playerBody.AddForce(ComputeMovement());
    }
}

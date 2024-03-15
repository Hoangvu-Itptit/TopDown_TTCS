using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var gameInstance = GameController.Instance;
        var playerPos = gameInstance.player.transform.position;
        var cameraPos = transform.position;
        cameraPos.x = playerPos.x;
        cameraPos.z = playerPos.z-6f;
        transform.position = cameraPos;
    }
}

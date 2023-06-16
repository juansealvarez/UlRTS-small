using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private CinemachineVirtualCamera myCamera;

    private Vector3 mDirection;
    private float mDeltaZoom;
    private CinemachineTransposer mCinemachineTransposer;

    private void Start()
    {
        mCinemachineTransposer = myCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        transform.position += mDirection * speed * Time.deltaTime;
        if (mDeltaZoom > 0f)
        {
            // Zoom in

        }else if (mDeltaZoom < 0f)
        {
            // Zoom out

        }

    }

    private void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        mDirection = new Vector3(
            dir.x,
            0f,
            dir.y
        );
    }

    private void OnZoom(InputValue value)
    {
        mDeltaZoom = value.Get<Vector2>().y;
    }
}
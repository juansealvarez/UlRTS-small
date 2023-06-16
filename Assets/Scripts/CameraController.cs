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
    [SerializeField]
    private float maxZoom = 20f;
    [SerializeField]
    private float minZoom = 2f;
    [SerializeField]
    private float zoom = 2f;

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
            var zoomActual = mCinemachineTransposer.m_FollowOffset;
            mCinemachineTransposer.m_FollowOffset = new Vector3(
                zoomActual.x,
                Mathf.Clamp(
                    Mathf.Lerp(zoomActual.y, zoomActual.y - zoom, Time.deltaTime * zoom),
                    minZoom,
                    maxZoom
                ),
                zoomActual.z
            );
        }else if (mDeltaZoom < 0f)
        {
            // Zoom out
            var zoomActual = mCinemachineTransposer.m_FollowOffset;
            mCinemachineTransposer.m_FollowOffset = new Vector3(
                zoomActual.x,
                Mathf.Clamp(
                    Mathf.Lerp(zoomActual.y, zoomActual.y + zoom, Time.deltaTime * zoom),
                    minZoom,
                    maxZoom
                ),
                zoomActual.z
            );
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
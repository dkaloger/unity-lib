using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Target for the camera to follow. Probably the player")]
    protected Transform _target;

    [SerializeField]
    [Tooltip("Offset this from the _target so we're not directly above the target")]
    protected Vector3 _moveOffset = Vector3.zero;

    [SerializeField]
    [Tooltip("Look offset from the _target position so it's not always in the middle of the screen")]
    protected Vector3 _lookOffset = Vector3.zero;

    [SerializeField]
    [Tooltip("Time in seconds. Smaller numbers mean a faster moving camera")]
    protected float _smoothTime = 0.4F;

    [SerializeField]
    [Tooltip("Max speed the camera can travel.")]
    protected float _cameraSpeed = 2F;

    protected Vector3 _velocity = Vector3.zero;

    protected Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        if (_target == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
                _target = GameObject.FindGameObjectWithTag("Player").transform;
            else
                Debug.LogWarning("Camera doesn't have a target to watch.");
        }

        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position + _moveOffset, ref _velocity, _smoothTime);
        //transform.rotation = Quaternion.LookRotation(_target.position + _lookOffset - transform.position); //The jitter of the camera is coming from the look transform. So I've just stopped it for now. Might bind it to the mouse later. 
    }
}
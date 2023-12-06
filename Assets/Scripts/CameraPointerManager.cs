using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    public static CameraPointerManager Instance;
    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer = 4.5f;
    [Range(0,100)]
    [SerializeField] private float disPointerObject = 0.95f;
    private const float _maxDistance = 100;
    private GameObject _gazedAtObject = null;

    private readonly string interactableTag = "Interactable";
    private float scaleSize = 0.025f;
    [HideInInspector]
    public Vector3 hitPoint;

    private void Awake()
    {
        if(Instance!=null && Instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }
    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
    }
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            hitPoint = hit.point;
            if (_gazedAtObject != hit.transform.gameObject)
            {
                
                _gazedAtObject?.SendMessage("OnPointerExitXR",null,SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }
            if (hit.transform.CompareTag(interactableTag)) 
            { 
                PointerOnGaze(hit.point);
            }
            else
            {
                PointerOutGaze();
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scaleFactor = scaleSize*Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale =Vector3.one * scaleFactor;
        pointer.transform.parent.position = CalcutePointerPosition(transform.position, hitPoint,disPointerObject);
    }

    private Vector3 CalcutePointerPosition(Vector3 p0,Vector3 p1,float t)
    {
        float x = p0.x+t*(p1.x-p0.x);
        float y = p0.y+t*(p1.y-p0.y);
        float z = p0.z+t*(p1.z-p0.z);

        return new Vector3(x,y,z);
    }
    private void PointerOutGaze()
    {
        pointer.transform.localScale = Vector3.one * 0.1f;
        pointer.transform.parent.transform.localPosition = new Vector3(0,0,maxDistancePointer);
        pointer.transform.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }
    
}

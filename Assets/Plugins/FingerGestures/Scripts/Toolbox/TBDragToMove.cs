using UnityEngine;
using System.Collections;

/// <summary>
/// Put this script on any scene object that you want to drag around
/// </summary>
[AddComponentMenu( "FingerGestures/Toolbox/Drag To Move" )]
public class TBDragToMove : MonoBehaviour
{
    public Collider DragPlaneCollider;      // collider used when dragPlaneType is set to DragPlaneType.UseCollider
    public float DragPlaneOffset = 0.0f;    // distance between dragged object and drag constraint plane
    public Camera RaycastCamera;

    // are we being dragged?
    bool dragging = false;
    FingerGestures.Finger draggingFinger = null;
    GestureRecognizer gestureRecognizer;

    bool oldUseGravity = false;
    bool oldIsKinematic = false;

    Vector3 physxDragMove = Vector3.zero;   // used for rigidbody drag only. This stores the drag amount to apply during the physics update in FixedUpdate()
    
    public bool Dragging
    {
        get { return dragging; }
        private set
        {
            if( dragging != value )
            {
                dragging = value;

                if( rigidbody )
                {
                    if( dragging )
                    {
                        oldUseGravity = rigidbody.useGravity;
                        oldIsKinematic = rigidbody.isKinematic;
                        rigidbody.useGravity = false;
                        rigidbody.isKinematic = true;
                    }
                    else
                    {
                        rigidbody.isKinematic = oldIsKinematic;
                        rigidbody.useGravity = oldUseGravity;
                        rigidbody.velocity = Vector3.zero;
                    }
                }
            }
        }
    }

    public enum DragPlaneType
    {
		Camera, // drag along a plane parallal to the camera/screen screen (XY)
        UseCollider, // project on the collider specified by dragPlaneCollider
    }

    void Start()
    {
        if( !RaycastCamera )
            RaycastCamera = Camera.main;
    }

    // converts a screen-space position to a world-space position constrained to the current drag plane type
    // returns false if it was unable to get a valid world-space position
    public bool ProjectScreenPointOnDragPlane( Vector3 refPos, Vector2 screenPos, out Vector3 worldPos )
    {
        worldPos = refPos;

        if( DragPlaneCollider )
        {
            Ray ray = RaycastCamera.ScreenPointToRay( screenPos );
            RaycastHit hit;

            if( !DragPlaneCollider.Raycast( ray, out hit, float.MaxValue ) )
                return false;

            worldPos = hit.point + DragPlaneOffset * hit.normal;
		}
		else // DragPlaneType.Camera
		{
            Transform camTransform = RaycastCamera.transform;

            // create a plane passing through refPos and facing toward the camera
            Plane plane = new Plane( -camTransform.forward, refPos );

            Ray ray = RaycastCamera.ScreenPointToRay( screenPos );

            float t = 0;
            if( !plane.Raycast( ray, out t ) )
                return false;

            worldPos = ray.GetPoint( t );
        }
               
		return true;
    }

    void HandleDrag( DragGesture gesture )
    {
        if( !enabled )
            return;

        if( gesture.Phase == ContinuousGesturePhase.Started )
        {
            Dragging = true;
            draggingFinger = gesture.Fingers[0];
        }
        else if( Dragging )
        {
            // make sure this is the finger we started dragging with
            if( gesture.Fingers[0] != draggingFinger )
                return;

            if( gesture.Phase == ContinuousGesturePhase.Updated )
            {
                Transform tf = transform;

                // figure out our previous screen space finger position
                Vector3 fingerPos3d, prevFingerPos3d;

                // convert these to world-space coordinates, and compute the amount of motion we need to apply to the object
                if( ProjectScreenPointOnDragPlane( tf.position, draggingFinger.PreviousPosition, out prevFingerPos3d ) &&
                    ProjectScreenPointOnDragPlane( tf.position, draggingFinger.Position, out fingerPos3d ) )
                {
                    Vector3 move = fingerPos3d - prevFingerPos3d;

                    if( rigidbody )
                        physxDragMove += move; // this will be used in FixedUpdate() to properly move the rigidbody
                    else
                        tf.position += move;
                }
            }
            else
            {
                Dragging = false;
            }
        }
    }

    void FixedUpdate()
    {
        if( Dragging && rigidbody )
        {
            // use MovePosition() for physics objects
            rigidbody.MovePosition( rigidbody.position + physxDragMove );

            // reset the accumulated drag amount value 
            physxDragMove = Vector3.zero;
        }
    }

    void OnFGDrag( DragGesture gesture )
    {
        HandleDrag( gesture );
    }

    void OnDisable()
    {
        // if this gets disabled while dragging, make sure we cancel the drag operation
        if( Dragging )
            Dragging = false;
    }
}
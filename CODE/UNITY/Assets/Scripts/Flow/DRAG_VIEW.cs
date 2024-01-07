// -- IMPORTS

using UnityEngine;
using UnityEngine.UIElements;

// -- TYPES

public class DRAG_VIEW : VisualElement
{
    public bool
        IsHorizontal,
        IsVertical,
        IsDragging,
        IsDampening;
    public float
        MinimumPixelDistance = 5,
        DampeningFactor = 0.95f,
        MinimumInertiaSpeed = 20.0f;
    public Vector2
        MousePositionVector;
    public Vector2
        ViewSizeVector,
        StripSizeVector;
    public VisualElement
        StripElement;
    public Vector2
        StripPositionVector,
        MinimumStripPositionVector,
        MaximumStripPositionVector;
    public Vector2
        DragMousePositionVector,
        DragVelocityVector;
    public IVisualElementScheduledItem
        InertiaScheduleItem;
    public float
        InertiaTime;

    // -- CONSTRUCTORS

    public DRAG_VIEW(
        )
    {
        InertiaScheduleItem = schedule.Execute( ApplyInertia ).Every( 1000 / 60 );
        InertiaScheduleItem.Pause();

        RegisterCallback<MouseDownEvent>( OnMouseDown );
        RegisterCallback<MouseMoveEvent>( OnMouseMove );
        RegisterCallback<MouseUpEvent>( OnMouseUp );
    }

    // -- OPERATIONS

    public void SetStripPosition(
        Vector2 strip_position_vector
        )
    {
        if ( IsHorizontal )
        {
            StripElement.style.left = Mathf.Clamp( strip_position_vector.x, MinimumStripPositionVector.x, MaximumStripPositionVector.x );
        }

        if ( IsVertical )
        {
            StripElement.style.top = Mathf.Clamp( strip_position_vector.y, MinimumStripPositionVector.y, MaximumStripPositionVector.y );
        }
    }

    // ~~

    public void ApplyInertia(
        )
    {
        StripPositionVector += DragVelocityVector * Time.deltaTime;
        DragVelocityVector *= DampeningFactor;

        if ( DragVelocityVector.magnitude <= MinimumInertiaSpeed )
        {
            InertiaScheduleItem.Pause();
        }

        SetStripPosition( StripPositionVector );
    }

    // ~~

    public void OnMouseDown(
        MouseDownEvent mouse_move_event
        )
    {
        if ( childCount > 0 )
        {
            this.CaptureMouse();

            IsDragging = false;
            MousePositionVector = mouse_move_event.localMousePosition;
            DragMousePositionVector = MousePositionVector;

            ViewSizeVector.x = resolvedStyle.width;
            ViewSizeVector.y = resolvedStyle.height;

            StripElement = this[ 0 ];
            StripSizeVector.x = StripElement.resolvedStyle.width;
            StripSizeVector.y = StripElement.resolvedStyle.height;
            StripPositionVector.x = StripElement.resolvedStyle.left;
            StripPositionVector.y = StripElement.resolvedStyle.top;

            MinimumStripPositionVector.x = ViewSizeVector.x - StripSizeVector.x;
            MinimumStripPositionVector.y = ViewSizeVector.y - StripSizeVector.y;
            MaximumStripPositionVector.x = 0.0f;
            MaximumStripPositionVector.y = 0.0f;

            InertiaScheduleItem.Pause();
        }
    }

    // ~~

    public void OnMouseMove(
        MouseMoveEvent mouse_move_event
        )
    {
        Vector2
            mouse_offset_vector,
            mouse_position_vector;

        if ( this.HasMouseCapture()
             && StripElement != null )
        {
            mouse_position_vector = mouse_move_event.localMousePosition;
            mouse_offset_vector = mouse_position_vector - MousePositionVector;

            if ( !IsDragging
                 && mouse_offset_vector.magnitude > MinimumPixelDistance )
            {
                IsDragging = true;
            }

            if ( IsDragging )
            {
                SetStripPosition( StripPositionVector + mouse_offset_vector );

                mouse_offset_vector = mouse_position_vector - DragMousePositionVector;
                DragVelocityVector = mouse_offset_vector / Time.deltaTime;
                DragMousePositionVector = mouse_position_vector;

                InertiaScheduleItem.Pause();
            }
        }
    }

    // ~~

    public void OnMouseUp(
        MouseUpEvent mouse_move_event
        )
    {
        if ( this.HasMouseCapture() )
        {
            this.ReleaseMouse();
        }

        IsDragging = false;
        StripPositionVector.x = StripElement.resolvedStyle.left;
        StripPositionVector.y = StripElement.resolvedStyle.top;

        InertiaScheduleItem.Resume();
    }
}

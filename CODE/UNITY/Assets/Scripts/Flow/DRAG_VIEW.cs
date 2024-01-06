// -- IMPORTS

using UnityEngine;
using UnityEngine.UIElements;

// -- TYPES

public class DRAG_VIEW : VisualElement
{
    public bool
        IsHorizontal,
        IsVertical,
        IsDragging;
    public float
        MinimumPixelDistance = 5;
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

    // -- CONSTRUCTORS

    public DRAG_VIEW(
        )
    {
        RegisterCallback<MouseDownEvent>( OnMouseDown );
        RegisterCallback<MouseMoveEvent>( OnMouseMove );
        RegisterCallback<MouseUpEvent>( OnMouseUp );
    }

    // -- OPERATIONS

    public void OnMouseDown(
        MouseDownEvent mouse_move_event
        )
    {
        if ( childCount > 0 )
        {
            this.CaptureMouse();

            IsDragging = false;
            MousePositionVector = mouse_move_event.localMousePosition;

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
        }
    }

    // ~~

    public void OnMouseMove(
        MouseMoveEvent mouse_move_event
        )
    {
        Vector2
            mouse_offset_vector;

        if ( this.HasMouseCapture()
             && StripElement != null )
        {
            mouse_offset_vector = mouse_move_event.localMousePosition - MousePositionVector;

            if ( !IsDragging
                 && mouse_offset_vector.magnitude > MinimumPixelDistance )
            {
                IsDragging = true;
            }

            if ( IsDragging )
            {
                if ( IsHorizontal )
                {
                    StripElement.style.left
                        = Mathf.Clamp( StripPositionVector.x + mouse_offset_vector.x, MinimumStripPositionVector.x, MaximumStripPositionVector.x );
                }

                if ( IsVertical )
                {
                    StripElement.style.top
                        = Mathf.Clamp( StripPositionVector.y + mouse_offset_vector.y, MinimumStripPositionVector.y, MaximumStripPositionVector.y );
                }
            }
        }
    }

    public void OnMouseUp(
        MouseUpEvent mouse_move_event
        )
    {
        if ( this.HasMouseCapture() )
        {
            this.ReleaseMouse();
        }

        IsDragging = false;
    }
}

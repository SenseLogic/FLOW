// -- IMPORTS

using UnityEngine;
using UnityEngine.UIElements;
using Element = UnityEngine.UIElements.VisualElement;

// -- TYPES

public class DRAG_VIEW : Element
{
    public bool
        IsTranslated,
        IsHorizontal,
        IsVertical,
        IsTracking,
        IsDragging,
        IsStopping;
    public float
        MinimumPixelDistance = 5,
        DraggingDampeningFactor = 0.5f,
        StoppingDampeningFactor = 0.95f,
        MinimumInertiaSpeed = 20.0f;
    public Vector2
        MousePositionVector;
    public Vector2
        ViewSizeVector,
        StripSizeVector;
    public Element
        StripElement;
    public Vector2
        StripPositionVector,
        MinimumStripPositionVector,
        MaximumStripPositionVector;
    public Vector2
        DragMousePositionVector,
        DragVelocityVector;
    public IVisualElementScheduledItem
        UpdateDragScheduleItem;
    public float
        InertiaTime;

    // -- CONSTRUCTORS

    public DRAG_VIEW(
        )
    {
        UpdateDragScheduleItem = schedule.Execute( UpdateDrag ).Every( 1000 / 60 );
        UpdateDragScheduleItem.Pause();

        RegisterCallback<MouseDownEvent>( HandleMouseDownEvent );
        RegisterCallback<MouseMoveEvent>( HandleMouseMoveEvent );
        RegisterCallback<MouseUpEvent>( HandleMouseUpEvent );
    }

    // -- OPERATIONS

    public Vector2 GetStripSize(
        )
    {
        return new Vector2( StripElement.resolvedStyle.width, StripElement.resolvedStyle.height );
    }

    // ~~

    public Vector2 GetStripPosition(
        )
    {
        if ( IsTranslated )
        {
            return StripElement.resolvedStyle.translate;
        }
        else
        {
            return new Vector2( StripElement.resolvedStyle.left, StripElement.resolvedStyle.top );
        }
    }

    // ~~

    public void SetStripPosition(
        Vector2 strip_position_vector
        )
    {
        if ( IsTranslated )
        {
            StripElement.style.translate
                = new StyleTranslate(
                      new Translate(
                          new Length( Mathf.Clamp( strip_position_vector.x, MinimumStripPositionVector.x, MaximumStripPositionVector.x ), LengthUnit.Pixel ),
                          new Length( Mathf.Clamp( strip_position_vector.y, MinimumStripPositionVector.y, MaximumStripPositionVector.y ), LengthUnit.Pixel )
                          )
                      );
        }
        else
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
    }

    // ~~

    public void UpdateDrag(
        )
    {
        if ( IsDragging )
        {
            DragVelocityVector *= DraggingDampeningFactor;
        }

        if ( IsStopping )
        {
            StripPositionVector += DragVelocityVector * Time.deltaTime;
            DragVelocityVector *= StoppingDampeningFactor;

            if ( DragVelocityVector.magnitude <= MinimumInertiaSpeed )
            {
                UpdateDragScheduleItem.Pause();
            }

            SetStripPosition( StripPositionVector );
        }
    }

    // ~~

    public void HandleMouseDownEvent(
        MouseDownEvent mouse_move_event
        )
    {
        if ( childCount > 0 )
        {
            if ( this.HasMouseCapture() )
            {
                this.ReleaseMouse();
            }

            IsTracking = true;
            IsDragging = false;
            IsStopping = false;
            MousePositionVector = mouse_move_event.localMousePosition;
            DragMousePositionVector = MousePositionVector;

            ViewSizeVector.x = resolvedStyle.width;
            ViewSizeVector.y = resolvedStyle.height;

            StripElement = this[ 0 ];
            StripSizeVector = GetStripSize();
            StripPositionVector = GetStripPosition();

            MinimumStripPositionVector.x = ViewSizeVector.x - StripSizeVector.x;
            MinimumStripPositionVector.y = ViewSizeVector.y - StripSizeVector.y;
            MaximumStripPositionVector.x = 0.0f;
            MaximumStripPositionVector.y = 0.0f;

            UpdateDragScheduleItem.Resume();
        }
    }

    // ~~

    public void HandleMouseMoveEvent(
        MouseMoveEvent mouse_move_event
        )
    {
        Vector2
            mouse_offset_vector,
            mouse_position_vector;

        if ( IsTracking
             && StripElement != null )
        {
            mouse_position_vector = mouse_move_event.localMousePosition;
            mouse_offset_vector = mouse_position_vector - MousePositionVector;

            if ( !IsDragging
                 && mouse_offset_vector.magnitude > MinimumPixelDistance )
            {
                if ( !this.HasMouseCapture() )
                {
                    this.CaptureMouse();
                }

                IsDragging = true;
                IsStopping = false;

            }

            if ( IsDragging )
            {
                SetStripPosition( StripPositionVector + mouse_offset_vector );

                mouse_offset_vector = mouse_position_vector - DragMousePositionVector;
                DragVelocityVector = mouse_offset_vector / Time.deltaTime;
                DragMousePositionVector = mouse_position_vector;
            }
        }
    }

    // ~~

    public void HandleMouseUpEvent(
        MouseUpEvent mouse_up_event
        )
    {
        if ( this.HasMouseCapture() )
        {
            this.ReleaseMouse();
        }

        IsTracking = false;
        IsDragging = false;
        IsStopping = true;
        StripPositionVector = GetStripPosition();
    }
}

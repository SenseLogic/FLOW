// -- IMPORTS

using System;
using UnityEngine;
using UnityEngine.UIElements;
using Element = UnityEngine.UIElements.VisualElement;

// -- TYPES

public class SLIDER : VisualElement
{
    // -- ATTRIBUTES

    public float
        Value,
        MinimumValue,
        MaximumValue;
    public VisualElement
        BarElement,
        ProgressElement,
        HandleElement;
    public Action<float>
        HandleValueChangedAction,
        HandleValueMovedAction;
    public bool
        IsTracking;

    // -- CONSTRUCTORS

    public SLIDER(
        )
    {
        MinimumValue = 0;
        MaximumValue = 100;
        Value = 50;

        BarElement = new Element();
        BarElement.AddClass( "slider-bar" );
        BarElement.style.width = new Length( 100, LengthUnit.Percent );
        Add( BarElement );

        ProgressElement = new Element();
        ProgressElement.AddClass( "slider-progress" );
        ProgressElement.style.position = Position.Absolute;
        ProgressElement.style.width = new Length( 0, LengthUnit.Percent );
        Add( ProgressElement );

        HandleElement = new Element();
        HandleElement.AddClass( "slider-handle" );
        HandleElement.style.position = Position.Absolute;
        Add( HandleElement );

        RegisterCallback<MouseDownEvent>( HandleMouseDownEvent );
        RegisterCallback<MouseMoveEvent>( HandleMouseMoveEvent );
        RegisterCallback<MouseUpEvent>( HandleMouseUpEvent );
    }

    // -- DESTRUCTOR

    ~SLIDER(
        )
    {
        UnregisterCallback<MouseDownEvent>( HandleMouseDownEvent );
        UnregisterCallback<MouseMoveEvent>( HandleMouseMoveEvent );
        UnregisterCallback<MouseUpEvent>( HandleMouseUpEvent );
    }

    // -- OPERATIONS

    public void UpdatePosition(
        )
    {
        float
            value_ratio;

        Value = Mathf.Clamp( Value, MinimumValue, MaximumValue );

        if ( MinimumValue < MaximumValue )
        {
            value_ratio = ( Value - MinimumValue ) / ( MaximumValue - MinimumValue ) * 100.0f;
        }
        else
        {
            value_ratio = 0.0f;
        }

        ProgressElement.style.width = new Length( value_ratio, LengthUnit.Percent );
        HandleElement.style.left = new Length( value_ratio, LengthUnit.Percent );
    }

    // ~~

    public void SetMinimumValue(
        float minimum_value
        )
    {
        MinimumValue = minimum_value;
        UpdatePosition();
    }

    // ~~

    public void SetMaximumValue(
        float maximum_value
        )
    {
        MaximumValue = maximum_value;
        UpdatePosition();
    }

    // ~~

    public void SetValue(
        float value
        )
    {
        Value = value;
        UpdatePosition();

        HandleValueChangedAction?.Invoke( Value );
    }

    // ~~

    public void MoveValue(
        float value
        )
    {
        SetValue( value );
        HandleValueMovedAction?.Invoke( Value );
    }

    // ~~

    public void MoveValue(
        Vector2 local_mouse_position_vector
        )
    {
        float
            ratio;

        ratio = ( local_mouse_position_vector.x - BarElement.worldBound.x ) / BarElement.resolvedStyle.width;
        MoveValue( Mathf.Clamp( ratio * ( MaximumValue - MinimumValue ) + MinimumValue, MinimumValue, MaximumValue ) );
    }

    // ~~

    public void HandleMouseDownEvent(
        MouseDownEvent mouse_down_event
        )
    {
        IsTracking = true;

        if ( !this.HasMouseCapture() )
        {
            this.CaptureMouse();
        }

        MoveValue( mouse_down_event.mousePosition );
    }

    // ~~

    public void HandleMouseMoveEvent(
        MouseMoveEvent mouse_move_event
        )
    {
        if ( IsTracking )
        {
            MoveValue( mouse_move_event.mousePosition );
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

        if ( IsTracking )
        {
            MoveValue( mouse_up_event.mousePosition );
        }

        IsTracking = false;
    }
}

// -- IMPORTS

using System;
using UnityEngine.UIElements;

// -- TYPES

public class BUTTON : VisualElement
{
    // -- ATTRIBUTES

    public Action<MouseEnterEvent>
        HandleMouseEnterAction;
    public Action<MouseMoveEvent>
        HandleMouseMoveAction;
    public Action<MouseLeaveEvent>
        HandleMouseLeaveAction;
    public Action<ClickEvent>
        HandleClickAction;
    public Action<PointerDownEvent>
        HandlePointerDownAction;
    public Action<PointerUpEvent>
        HandlePointerUpAction;

    // -- CONSTRUCTORS

    public BUTTON(
        )
    {
        RegisterCallback<MouseEnterEvent>( HandleMouseEnterEvent );
        RegisterCallback<MouseMoveEvent>( HandleMouseMoveEvent );
        RegisterCallback<MouseLeaveEvent>( HandleMouseLeaveEvent );
        RegisterCallback<ClickEvent>( HandleClickEvent );
        RegisterCallback<PointerDownEvent>( HandlePointerDownEvent );
        RegisterCallback<PointerUpEvent>( HandlePointerUpEvent );
    }

    // -- DESTRUCTOR

    ~BUTTON(
        )
    {
        UnregisterCallback<MouseEnterEvent>( HandleMouseEnterEvent );
        UnregisterCallback<MouseMoveEvent>( HandleMouseMoveEvent );
        UnregisterCallback<MouseLeaveEvent>( HandleMouseLeaveEvent );
        UnregisterCallback<ClickEvent>( HandleClickEvent );
        UnregisterCallback<PointerDownEvent>( HandlePointerDownEvent );
        UnregisterCallback<PointerUpEvent>( HandlePointerUpEvent );
    }

    // -- OPERATIONS

    public virtual void HandleMouseEnterEvent(
        MouseEnterEvent mouse_enter_event
        )
    {
        HandleMouseEnterAction?.Invoke( mouse_enter_event );
    }

    // ~~

    public virtual void HandleMouseMoveEvent(
        MouseMoveEvent mouse_move_event
        )
    {
        HandleMouseMoveAction?.Invoke( mouse_move_event );
    }

    // ~~

    public virtual void HandleMouseLeaveEvent(
        MouseLeaveEvent mouse_leave_event
        )
    {
        HandleMouseLeaveAction?.Invoke( mouse_leave_event );
    }

    // ~~

    public virtual void HandleClickEvent(
        ClickEvent click_event
        )
    {
        HandleClickAction?.Invoke( click_event );
    }

    // ~~

    public virtual void HandlePointerDownEvent(
        PointerDownEvent pointer_down_event
        )
    {
        HandlePointerDownAction?.Invoke( pointer_down_event );
    }

    // ~~

    public virtual void HandlePointerUpEvent(
        PointerUpEvent pointer_up_event
        )
    {
        HandlePointerUpAction?.Invoke( pointer_up_event );
    }
}

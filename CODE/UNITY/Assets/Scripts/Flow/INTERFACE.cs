// -- IMPORTS

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// -- TYPES

using Element = UnityEngine.UIElements.VisualElement;

// ~~

namespace FLOW
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class INTERFACE : MonoBehaviour
    {
        // -- ATTRIBUTES

        public UIDocument
            Document;
        public float
            CanvasWidth,
            CanvasHeight,
            CanvasHeightFactor,
            CanvasRatio,
            ScreenWidth,
            ScreenHeight,
            ScreenMinimumSize,
            ScreenMaximumSize,
            ScreenRatio,
            Width,
            Height,
            MinimumSize,
            MaximumSize,
            Ratio,
            Pixel;
        public Element
            Element;
        public List<Element>
            HandleResizeElementList = new List<Element>();
        public List<Action<Element>>
            HandleResizeActionList = new List<Action<Element>>();

        // -- OPERATIONS

        public virtual void UpdateSize(
            )
        {
            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;
            ScreenMinimumSize = Mathf.Min( ScreenWidth, ScreenHeight );
            ScreenMaximumSize = Mathf.Max( ScreenWidth, ScreenHeight );

            if ( ScreenHeight != 0.0f )
            {
                ScreenRatio = ScreenWidth / ScreenHeight;
            }
            else
            {
                ScreenRatio = 0.0f;
            }

            if ( CanvasRatio == 0.0f )
            {
                CanvasRatio = ScreenRatio;
            }

            if ( CanvasWidth == 0.0f
                 && CanvasHeight == 0.0f )
            {
                CanvasWidth = ScreenWidth;
                CanvasHeight = ScreenHeight;
            }
            else if ( CanvasWidth == 0.0f )
            {
                CanvasWidth = CanvasHeight * CanvasRatio;
            }
            else if ( CanvasHeight == 0.0f )
            {
                CanvasHeight = CanvasWidth / CanvasRatio;
            }
            else
            {
                CanvasRatio = CanvasWidth / CanvasHeight;
            }

            Width = Element.worldBound.width;
            Height = Element.worldBound.height;

            if ( float.IsNaN( Width )
                 || float.IsNaN( Height ) )
            {
                Width = ScreenWidth;
                Height = ScreenHeight;
            }

            MinimumSize = Mathf.Min( Width, Height );
            MaximumSize = Mathf.Max( Width, Height );

            if ( Height != 0.0f )
            {
                Ratio = Width / Height;
            }
            else
            {
                Ratio = 0.0f;
            }

            Element.EnableInClassList( "aspect-ratio-below-9-16", Ratio <= 0.57f );
            Element.EnableInClassList( "aspect-ratio-below-2-3", Ratio <= 0.67f );
            Element.EnableInClassList( "aspect-ratio-below-3-4", Ratio <= 0.75f );
            Element.EnableInClassList( "aspect-ratio-below-1", Ratio <= 1.0f );
            Element.EnableInClassList( "aspect-ratio-above-1", Ratio >= 1.0f );
            Element.EnableInClassList( "aspect-ratio-above-4-3", Ratio >= 1.33f );
            Element.EnableInClassList( "aspect-ratio-above-3-2", Ratio <= 1.5f );
            Element.EnableInClassList( "aspect-ratio-above-16-9", Ratio >= 1.77f );

            Pixel = Mathf.Lerp( Width / CanvasWidth, Height / CanvasHeight, Mathf.Clamp01( CanvasHeightFactor ) );
        }

        // ~~

        public virtual void HandleResize(
            Element element,
            Action<Element> action
            )
        {
            HandleResizeElementList.Add( element );
            HandleResizeActionList.Add( action );

            if ( element.panel != null )
            {
                action( element );
            }
        }

        // ~~

        public virtual void ClearDocument(
            )
        {
            Element.Clear();

            HandleResizeElementList = new List<Element>();
            HandleResizeActionList = new List<Action<Element>>();
        }

        // ~~

        public virtual void BuildDocument(
            )
        {
            ClearDocument();
        }

        // ~~

        public virtual void ResizeDocument(
            )
        {
            int
                element_index;
            Element
                element;

            for ( element_index = 0;
                  element_index < HandleResizeElementList.Count;
                  ++element_index )
            {
                element = HandleResizeElementList[ element_index ];

                if ( element.panel != null )
                {
                    HandleResizeActionList[ element_index ]( element );
                }
            }
        }

        // ~~

        public virtual void OnEnable(
            )
        {
            Document = GetComponent<UIDocument>();
            Element = Document.rootVisualElement;
            Element.RegisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );

            UpdateSize();
            BuildDocument();
            ResizeDocument();
        }

        // ~~

        public virtual void HandleGeometryChangedEvent(
            GeometryChangedEvent geometry_changed_event
            )
        {
            UpdateSize();
            ResizeDocument();
        }

        // ~~

        public virtual void OnDisable(
            )
        {
            Element.UnregisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );
        }
    }
}

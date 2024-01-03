// -- IMPORTS

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// -- TYPES

using Element = UnityEngine.UIElements.VisualElement;

// ~~

namespace Flow
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class ResponsiveDocument : MonoBehaviour
    {
        // -- ATTRIBUTES

        public UIDocument
            Document;
        public float
            ScreenWidth,
            ScreenHeight,
            ScreenMinimumSize,
            ScreenMaximumSize,
            ScreenRatio,
            DocumentWidth,
            DocumentHeight,
            DocumentMinimumSize,
            DocumentMaximumSize,
            DocumentRatio;
        public Element
            DocumentElement;
        public List<Element>
            ResizeElementList;
        public List<Action<Element>>
            ResizeFunctionList;

        // -- OPERATIONS

        public void ResizeElement(
            Element element,
            Action<Element> resize_function
            )
        {
            ResizeElementList.Add( element );
            ResizeFunctionList.Add( resize_function );

            if ( element.panel != null )
            {
                resize_function( element );
            }
        }

        // ~~

        public void UpdateScreenSize(
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
        }

        // ~~

        public void UpdateDocumentSize(
            )
        {
            DocumentWidth = DocumentElement.worldBound.width;
            DocumentHeight = DocumentElement.worldBound.height;
            DocumentMinimumSize = Mathf.Min( DocumentWidth, DocumentHeight );
            DocumentMaximumSize = Mathf.Max( DocumentWidth, DocumentHeight );

            if ( DocumentHeight != 0.0f )
            {
                DocumentRatio = DocumentWidth / DocumentHeight;
            }
            else
            {
                DocumentRatio = 0.0f;
            }
        }

        // ~~

        public virtual void HandleDocumentSizeEvent(
            )
        {
        }

        // ~~

        public virtual void HandleDocumentResizeEvent(
            )
        {
            int
                resize_element_index;
            Element
                resize_element;

            for ( resize_element_index = 0;
                  resize_element_index < ResizeElementList.Count;
                  ++resize_element_index )
            {
                resize_element = ResizeElementList[ resize_element_index ];

                if ( resize_element.panel != null )
                {
                    ResizeFunctionList[ resize_element_index ]( resize_element );
                }
            }
        }

        // ~~

        public virtual void HandleGeometryChangedEvent(
            GeometryChangedEvent geometry_changed_event
            )
        {
            UpdateScreenSize();
            UpdateDocumentSize();

            HandleDocumentSizeEvent();
            HandleDocumentResizeEvent();
        }

        // ~~

        public virtual void Clear(
            )
        {
            DocumentElement.Clear();

            ResizeElementList = new List<Element>();
            ResizeFunctionList = new List<Action<Element>>();
        }

        // ~~

        public virtual void OnEnable(
            )
        {
            Document = GetComponent<UIDocument>();
            DocumentElement = Document.rootVisualElement;
            DocumentElement.RegisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );

            Clear();

            UpdateScreenSize();
            UpdateDocumentSize();

            HandleDocumentSizeEvent();
        }

        // ~~

        public void OnDisable(
            )
        {
            DocumentElement.UnregisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );
        }
    }
}

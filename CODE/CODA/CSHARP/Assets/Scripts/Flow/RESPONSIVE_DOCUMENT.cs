// -- IMPORTS

using UnityEngine;
using UnityEngine.UIElements;

// -- TYPES

namespace FLOW
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class RESPONSIVE_DOCUMENT : MonoBehaviour
    {
        // -- ATTRIBUTES

        public UIDocument
            Document;
        public float
            ScreenWidth,
            ScreenHeight,
            ScreenRatio,
            DocumentWidth,
            DocumentHeight,
            DocumentRatio;
        public VisualElement
            DocumentElement;

        // -- OPERATIONS

        public virtual void HandleDocumentSizeEvent(
            )
        {
            if ( DocumentWidth != 0.0f
                 && DocumentHeight != 0.0f )
            {
                DocumentRatio = DocumentWidth / DocumentHeight;
            }
            else
            {
                DocumentRatio = 0.0f;
            }
        }

        // ~~

        public virtual void HandleDocumentResizeEvent(
            )
        {
        }

        // ~~

        public virtual void OnEnable(
            )
        {
            Document = GetComponent<UIDocument>();
            DocumentElement = Document.rootVisualElement;
            DocumentElement.RegisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );

            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;

            DocumentWidth = ScreenWidth;
            DocumentHeight = ScreenHeight;

            HandleDocumentSizeEvent();
        }

        // ~~

        public virtual void HandleGeometryChangedEvent(
            GeometryChangedEvent event_
            )
        {
            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;

            DocumentWidth = event_.newRect.width;
            DocumentHeight = event_.newRect.height;

            HandleDocumentSizeEvent();
            HandleDocumentResizeEvent();
        }

        // ~~

        public void OnDisable(
            )
        {
            DocumentElement.UnregisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );
        }
    }
}

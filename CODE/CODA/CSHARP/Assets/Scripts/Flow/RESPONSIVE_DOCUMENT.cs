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
            DocumentWidth,
            DocumentHeight;
        public VisualElement
            RootElement;
        public float
            AspectRatio;

        // -- OPERATIONS

        public void HandleGeometryChangedEvent(
            GeometryChangedEvent event_
            )
        {
            DocumentWidth = event_.newRect.width;
            DocumentHeight = event_.newRect.height;

            if ( DocumentWidth != 0
                 && DocumentHeight != 0 )
            {
                AspectRatio = DocumentWidth / DocumentHeight;

                RootElement.EnableInClassList( "portrait-screen-1-2", AspectRatio <= 0.5f );
                RootElement.EnableInClassList( "portrait-screen-9-16", AspectRatio <= 0.57f );
                RootElement.EnableInClassList( "portrait-screen-2-3", AspectRatio <= 0.67f );
                RootElement.EnableInClassList( "portrait-screen-3-4", AspectRatio <= 0.75f );
                RootElement.EnableInClassList( "portrait-screen", AspectRatio < 1.0f );
                RootElement.EnableInClassList( "landscape-screen", AspectRatio >= 1.0f );
                RootElement.EnableInClassList( "landscape-screen-4-3", AspectRatio >= 1.33f );
                RootElement.EnableInClassList( "landscape-screen-3-2", AspectRatio >= 1.5f );
                RootElement.EnableInClassList( "landscape-screen-16-9", AspectRatio >= 1.77f );
                RootElement.EnableInClassList( "landscape-screen-2-1", AspectRatio >= 2.0f );
            }
        }

        // ~~

        public void OnEnable(
            )
        {
            Document = GetComponent<UIDocument>();
            RootElement = Document.rootVisualElement;
            RootElement.RegisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );
        }

        // ~~

        public void OnDisable(
            )
        {
            RootElement.UnregisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );
        }
    }
}

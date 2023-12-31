// -- IMPORTS

using UnityEngine;
using UnityEngine.UIElements;

// -- TYPES

namespace FLOW
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class SCREEN : MonoBehaviour
    {
        // -- ATTRIBUTES

        public UIDocument
            Document;
        public VisualElement
            RootElement;
        public int
            ScreenWidth,
            ScreenHeight;
        public float
            AspectRatio;

        // -- OPERATIONS

        public void OnEnable(
            )
        {
            Document = GetComponent<UIDocument>();
            RootElement = Document.rootVisualElement;
        }

        // ~~

        public void UpdateClasses(
            )
        {
            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;
            AspectRatio = ( float )ScreenWidth / ScreenHeight;

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

        // ~~

        void Start(
            )
        {
            UpdateClasses();
        }

        // ~~

        void Update()
        {
            if ( Screen.width != ScreenWidth
                 || Screen.height != ScreenHeight )
            {
                UpdateClasses();
            }
        }
    }
}

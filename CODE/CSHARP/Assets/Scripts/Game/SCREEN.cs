// -- IMPORTS

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using FLOW;

// -- TYPES

using Element = UnityEngine.UIElements.VisualElement;

// ~~

namespace GAME
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class SCREEN : DOCUMENT
    {
        // -- OPERATIONS

        public void Start(
            )
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        // ~~

        public override void UpdateSize(
            )
        {
            base.UpdateSize();

            DocumentElement.EnableInClassList( "aspect-ratio-below-9-16", DocumentRatio <= 0.57f );
            DocumentElement.EnableInClassList( "aspect-ratio-below-2-3", DocumentRatio <= 0.67f );
            DocumentElement.EnableInClassList( "aspect-ratio-below-3-4", DocumentRatio <= 0.75f );
            DocumentElement.EnableInClassList( "aspect-ratio-below-1", DocumentRatio <= 1.0f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-1", DocumentRatio >= 1.0f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-4-3", DocumentRatio >= 1.33f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-3-2", DocumentRatio <= 1.5f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-16-9", DocumentRatio >= 1.77f );
        }

        // ~~

        public override void ResizeDocument(
            )
        {
            base.ResizeDocument();
        }
    }
}

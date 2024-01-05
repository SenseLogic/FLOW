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

        public override void UpdateSize(
            )
        {
            base.UpdateSize();

            Element.EnableInClassList( "aspect-ratio-below-9-16", Ratio <= 0.57f );
            Element.EnableInClassList( "aspect-ratio-below-2-3", Ratio <= 0.67f );
            Element.EnableInClassList( "aspect-ratio-below-3-4", Ratio <= 0.75f );
            Element.EnableInClassList( "aspect-ratio-below-1", Ratio <= 1.0f );
            Element.EnableInClassList( "aspect-ratio-above-1", Ratio >= 1.0f );
            Element.EnableInClassList( "aspect-ratio-above-4-3", Ratio >= 1.33f );
            Element.EnableInClassList( "aspect-ratio-above-3-2", Ratio <= 1.5f );
            Element.EnableInClassList( "aspect-ratio-above-16-9", Ratio >= 1.77f );
        }

        // ~~

        public override void ResizeDocument(
            )
        {
            base.ResizeDocument();
        }
    }
}

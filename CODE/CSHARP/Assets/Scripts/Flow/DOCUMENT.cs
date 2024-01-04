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
    public class DOCUMENT : MonoBehaviour
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
            DocumentResolution,
            DocumentWidth,
            DocumentHeight,
            DocumentMinimumSize,
            DocumentMaximumSize,
            DocumentRatio,
            DocumentPixel;
        public Element
            DocumentElement;
        public List<Element>
            ResizeElementList = new List<Element>();
        public List<Action<Element>>
            ResizeFunctionList = new List<Action<Element>>();

        // -- OPERATIONS

        public void SetDocumentResolution(
            float reference_width
            )
        {
            DocumentResolution = reference_width;
        }

        // ~~

        public UQueryBuilder<VisualElement> FindByClass(
            string class_name
            )
        {
            return DocumentElement.Query<VisualElement>().Class( class_name );
        }

        // ~~

        public void SetBottom(
            Element element,
            float bottom
            )
        {
            element.style.bottom = bottom;
        }

        // ~~

        public void SetBottom(
            UQueryBuilder<VisualElement> query_builder,
            float bottom
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.bottom = bottom;
            }
        }

        // ~~

        public void SetBottom(
            string class_name,
            float bottom
            )
        {
            SetBottom( DocumentElement.Query<VisualElement>().Class( class_name ), bottom );
        }

        // ~~

        public void SetBorderBottomLeftRadius(
            Element element,
            float borderBottomLeftRadius
            )
        {
            element.style.borderBottomLeftRadius = borderBottomLeftRadius;
        }

        // ~~

        public void SetBorderBottomLeftRadius(
            UQueryBuilder<VisualElement> query_builder,
            float borderBottomLeftRadius
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderBottomLeftRadius = borderBottomLeftRadius;
            }
        }

        // ~~

        public void SetBorderBottomLeftRadius(
            string class_name,
            float borderBottomLeftRadius
            )
        {
            SetBorderBottomLeftRadius( DocumentElement.Query<VisualElement>().Class( class_name ), borderBottomLeftRadius );
        }

        // ~~

        public void SetBorderBottomRightRadius(
            Element element,
            float borderBottomRightRadius
            )
        {
            element.style.borderBottomRightRadius = borderBottomRightRadius;
        }

        // ~~

        public void SetBorderBottomRightRadius(
            UQueryBuilder<VisualElement> query_builder,
            float borderBottomRightRadius
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderBottomRightRadius = borderBottomRightRadius;
            }
        }

        // ~~

        public void SetBorderBottomRightRadius(
            string class_name,
            float borderBottomRightRadius
            )
        {
            SetBorderBottomRightRadius( DocumentElement.Query<VisualElement>().Class( class_name ), borderBottomRightRadius );
        }

        // ~~

        public void SetBorderBottomWidth(
            Element element,
            float borderBottomWidth
            )
        {
            element.style.borderBottomWidth = borderBottomWidth;
        }

        // ~~

        public void SetBorderBottomWidth(
            UQueryBuilder<VisualElement> query_builder,
            float borderBottomWidth
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderBottomWidth = borderBottomWidth;
            }
        }

        // ~~

        public void SetBorderBottomWidth(
            string class_name,
            float borderBottomWidth
            )
        {
            SetBorderBottomWidth( DocumentElement.Query<VisualElement>().Class( class_name ), borderBottomWidth );
        }

        // ~~

        public void SetBorderLeftWidth(
            Element element,
            float borderLeftWidth
            )
        {
            element.style.borderLeftWidth = borderLeftWidth;
        }

        // ~~

        public void SetBorderLeftWidth(
            UQueryBuilder<VisualElement> query_builder,
            float borderLeftWidth
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderLeftWidth = borderLeftWidth;
            }
        }

        // ~~

        public void SetBorderLeftWidth(
            string class_name,
            float borderLeftWidth
            )
        {
            SetBorderLeftWidth( DocumentElement.Query<VisualElement>().Class( class_name ), borderLeftWidth );
        }

        // ~~

        public void SetBorderRightWidth(
            Element element,
            float borderRightWidth
            )
        {
            element.style.borderRightWidth = borderRightWidth;
        }

        // ~~

        public void SetBorderRightWidth(
            UQueryBuilder<VisualElement> query_builder,
            float borderRightWidth
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderRightWidth = borderRightWidth;
            }
        }

        // ~~

        public void SetBorderRightWidth(
            string class_name,
            float borderRightWidth
            )
        {
            SetBorderRightWidth( DocumentElement.Query<VisualElement>().Class( class_name ), borderRightWidth );
        }

        // ~~

        public void SetBorderTopLeftRadius(
            Element element,
            float borderTopLeftRadius
            )
        {
            element.style.borderTopLeftRadius = borderTopLeftRadius;
        }

        // ~~

        public void SetBorderTopLeftRadius(
            UQueryBuilder<VisualElement> query_builder,
            float borderTopLeftRadius
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderTopLeftRadius = borderTopLeftRadius;
            }
        }

        // ~~

        public void SetBorderTopLeftRadius(
            string class_name,
            float borderTopLeftRadius
            )
        {
            SetBorderTopLeftRadius( DocumentElement.Query<VisualElement>().Class( class_name ), borderTopLeftRadius );
        }

        // ~~

        public void SetBorderTopRightRadius(
            Element element,
            float borderTopRightRadius
            )
        {
            element.style.borderTopRightRadius = borderTopRightRadius;
        }

        // ~~

        public void SetBorderTopRightRadius(
            UQueryBuilder<VisualElement> query_builder,
            float borderTopRightRadius
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderTopRightRadius = borderTopRightRadius;
            }
        }

        // ~~

        public void SetBorderTopRightRadius(
            string class_name,
            float borderTopRightRadius
            )
        {
            SetBorderTopRightRadius( DocumentElement.Query<VisualElement>().Class( class_name ), borderTopRightRadius );
        }

        // ~~

        public void SetBorderTopWidth(
            Element element,
            float borderTopWidth
            )
        {
            element.style.borderTopWidth = borderTopWidth;
        }

        // ~~

        public void SetBorderTopWidth(
            UQueryBuilder<VisualElement> query_builder,
            float borderTopWidth
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.borderTopWidth = borderTopWidth;
            }
        }

        // ~~

        public void SetBorderTopWidth(
            string class_name,
            float borderTopWidth
            )
        {
            SetBorderTopWidth( DocumentElement.Query<VisualElement>().Class( class_name ), borderTopWidth );
        }

        // ~~

        public void SetFontSize(
            Element element,
            float fontSize
            )
        {
            element.style.fontSize = fontSize;
        }

        // ~~

        public void SetFontSize(
            UQueryBuilder<VisualElement> query_builder,
            float fontSize
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.fontSize = fontSize;
            }
        }

        // ~~

        public void SetFontSize(
            string class_name,
            float fontSize
            )
        {
            SetFontSize( DocumentElement.Query<VisualElement>().Class( class_name ), fontSize );
        }

        // ~~

        public void SetHeight(
            Element element,
            float height
            )
        {
            element.style.height = height;
        }

        // ~~

        public void SetHeight(
            UQueryBuilder<VisualElement> query_builder,
            float height
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.height = height;
            }
        }

        // ~~

        public void SetHeight(
            string class_name,
            float height
            )
        {
            SetHeight( DocumentElement.Query<VisualElement>().Class( class_name ), height );
        }

        // ~~

        public void SetLeft(
            Element element,
            float left
            )
        {
            element.style.left = left;
        }

        // ~~

        public void SetLeft(
            UQueryBuilder<VisualElement> query_builder,
            float left
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.left = left;
            }
        }

        // ~~

        public void SetLeft(
            string class_name,
            float left
            )
        {
            SetLeft( DocumentElement.Query<VisualElement>().Class( class_name ), left );
        }

        // ~~

        public void SetMarginBottom(
            Element element,
            float marginBottom
            )
        {
            element.style.marginBottom = marginBottom;
        }

        // ~~

        public void SetMarginBottom(
            UQueryBuilder<VisualElement> query_builder,
            float marginBottom
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.marginBottom = marginBottom;
            }
        }

        // ~~

        public void SetMarginBottom(
            string class_name,
            float marginBottom
            )
        {
            SetMarginBottom( DocumentElement.Query<VisualElement>().Class( class_name ), marginBottom );
        }

        // ~~

        public void SetMarginLeft(
            Element element,
            float marginLeft
            )
        {
            element.style.marginLeft = marginLeft;
        }

        // ~~

        public void SetMarginLeft(
            UQueryBuilder<VisualElement> query_builder,
            float marginLeft
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.marginLeft = marginLeft;
            }
        }

        // ~~

        public void SetMarginLeft(
            string class_name,
            float marginLeft
            )
        {
            SetMarginLeft( DocumentElement.Query<VisualElement>().Class( class_name ), marginLeft );
        }

        // ~~

        public void SetMarginRight(
            Element element,
            float marginRight
            )
        {
            element.style.marginRight = marginRight;
        }

        // ~~

        public void SetMarginRight(
            UQueryBuilder<VisualElement> query_builder,
            float marginRight
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.marginRight = marginRight;
            }
        }

        // ~~

        public void SetMarginRight(
            string class_name,
            float marginRight
            )
        {
            SetMarginRight( DocumentElement.Query<VisualElement>().Class( class_name ), marginRight );
        }

        // ~~

        public void SetMarginTop(
            Element element,
            float marginTop
            )
        {
            element.style.marginTop = marginTop;
        }

        // ~~

        public void SetMarginTop(
            UQueryBuilder<VisualElement> query_builder,
            float marginTop
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.marginTop = marginTop;
            }
        }

        // ~~

        public void SetMarginTop(
            string class_name,
            float marginTop
            )
        {
            SetMarginTop( DocumentElement.Query<VisualElement>().Class( class_name ), marginTop );
        }

        // ~~

        public void SetMaxHeight(
            Element element,
            float maxHeight
            )
        {
            element.style.maxHeight = maxHeight;
        }

        // ~~

        public void SetMaxHeight(
            UQueryBuilder<VisualElement> query_builder,
            float maxHeight
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.maxHeight = maxHeight;
            }
        }

        // ~~

        public void SetMaxHeight(
            string class_name,
            float maxHeight
            )
        {
            SetMaxHeight( DocumentElement.Query<VisualElement>().Class( class_name ), maxHeight );
        }

        // ~~

        public void SetMaxWidth(
            Element element,
            float maxWidth
            )
        {
            element.style.maxWidth = maxWidth;
        }

        // ~~

        public void SetMaxWidth(
            UQueryBuilder<VisualElement> query_builder,
            float maxWidth
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.maxWidth = maxWidth;
            }
        }

        // ~~

        public void SetMaxWidth(
            string class_name,
            float maxWidth
            )
        {
            SetMaxWidth( DocumentElement.Query<VisualElement>().Class( class_name ), maxWidth );
        }

        // ~~

        public void SetMinHeight(
            Element element,
            float minHeight
            )
        {
            element.style.minHeight = minHeight;
        }

        // ~~

        public void SetMinHeight(
            UQueryBuilder<VisualElement> query_builder,
            float minHeight
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.minHeight = minHeight;
            }
        }

        // ~~

        public void SetMinHeight(
            string class_name,
            float minHeight
            )
        {
            SetMinHeight( DocumentElement.Query<VisualElement>().Class( class_name ), minHeight );
        }

        // ~~

        public void SetMinWidth(
            Element element,
            float minWidth
            )
        {
            element.style.minWidth = minWidth;
        }

        // ~~

        public void SetMinWidth(
            UQueryBuilder<VisualElement> query_builder,
            float minWidth
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.minWidth = minWidth;
            }
        }

        // ~~

        public void SetMinWidth(
            string class_name,
            float minWidth
            )
        {
            SetMinWidth( DocumentElement.Query<VisualElement>().Class( class_name ), minWidth );
        }

        // ~~

        public void SetPaddingBottom(
            Element element,
            float paddingBottom
            )
        {
            element.style.paddingBottom = paddingBottom;
        }

        // ~~

        public void SetPaddingBottom(
            UQueryBuilder<VisualElement> query_builder,
            float paddingBottom
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.paddingBottom = paddingBottom;
            }
        }

        // ~~

        public void SetPaddingBottom(
            string class_name,
            float paddingBottom
            )
        {
            SetPaddingBottom( DocumentElement.Query<VisualElement>().Class( class_name ), paddingBottom );
        }

        // ~~

        public void SetPaddingLeft(
            Element element,
            float paddingLeft
            )
        {
            element.style.paddingLeft = paddingLeft;
        }

        // ~~

        public void SetPaddingLeft(
            UQueryBuilder<VisualElement> query_builder,
            float paddingLeft
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.paddingLeft = paddingLeft;
            }
        }

        // ~~

        public void SetPaddingLeft(
            string class_name,
            float paddingLeft
            )
        {
            SetPaddingLeft( DocumentElement.Query<VisualElement>().Class( class_name ), paddingLeft );
        }

        // ~~

        public void SetPaddingRight(
            Element element,
            float paddingRight
            )
        {
            element.style.paddingRight = paddingRight;
        }

        // ~~

        public void SetPaddingRight(
            UQueryBuilder<VisualElement> query_builder,
            float paddingRight
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.paddingRight = paddingRight;
            }
        }

        // ~~

        public void SetPaddingRight(
            string class_name,
            float paddingRight
            )
        {
            SetPaddingRight( DocumentElement.Query<VisualElement>().Class( class_name ), paddingRight );
        }

        // ~~

        public void SetPaddingTop(
            Element element,
            float paddingTop
            )
        {
            element.style.paddingTop = paddingTop;
        }

        // ~~

        public void SetPaddingTop(
            UQueryBuilder<VisualElement> query_builder,
            float paddingTop
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.paddingTop = paddingTop;
            }
        }

        // ~~

        public void SetPaddingTop(
            string class_name,
            float paddingTop
            )
        {
            SetPaddingTop( DocumentElement.Query<VisualElement>().Class( class_name ), paddingTop );
        }

        // ~~

        public void SetRight(
            Element element,
            float right
            )
        {
            element.style.right = right;
        }

        // ~~

        public void SetRight(
            UQueryBuilder<VisualElement> query_builder,
            float right
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.right = right;
            }
        }

        // ~~

        public void SetRight(
            string class_name,
            float right
            )
        {
            SetRight( DocumentElement.Query<VisualElement>().Class( class_name ), right );
        }

        // ~~

        public void SetTop(
            Element element,
            float top
            )
        {
            element.style.top = top;
        }

        // ~~

        public void SetTop(
            UQueryBuilder<VisualElement> query_builder,
            float top
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.top = top;
            }
        }

        // ~~

        public void SetTop(
            string class_name,
            float top
            )
        {
            SetTop( DocumentElement.Query<VisualElement>().Class( class_name ), top );
        }

        // ~~

        public void SetWidth(
            Element element,
            float width
            )
        {
            element.style.width = width;
        }

        // ~~

        public void SetWidth(
            UQueryBuilder<VisualElement> query_builder,
            float width
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.width = width;
            }
        }

        // ~~

        public void SetWidth(
            string class_name,
            float width
            )
        {
            SetWidth( DocumentElement.Query<VisualElement>().Class( class_name ), width );
        }

        // ~~

        public void SetWordSpacing(
            Element element,
            float wordSpacing
            )
        {
            element.style.wordSpacing = wordSpacing;
        }

        // ~~

        public void SetWordSpacing(
            UQueryBuilder<VisualElement> query_builder,
            float wordSpacing
            )
        {
            foreach ( var element in query_builder.Build() )
            {
                element.style.wordSpacing = wordSpacing;
            }
        }

        // ~~

        public void SetWordSpacing(
            string class_name,
            float wordSpacing
            )
        {
            SetWordSpacing( DocumentElement.Query<VisualElement>().Class( class_name ), wordSpacing );
        }

        // ~~

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

            if ( DocumentResolution == 0.0f )
            {
                DocumentResolution = ScreenWidth;
            }

            DocumentWidth = DocumentElement.worldBound.width;
            DocumentHeight = DocumentElement.worldBound.height;

            if ( float.IsNaN( DocumentWidth )
                 || float.IsNaN( DocumentHeight ) )
            {
                DocumentWidth = ScreenWidth;
                DocumentHeight = ScreenHeight;
            }

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

            DocumentPixel = DocumentWidth / DocumentResolution;
        }

        // ~~

        public virtual void Resize(
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

        public virtual void ClearDocument(
            )
        {
            DocumentElement.Clear();

            ResizeElementList = new List<Element>();
            ResizeFunctionList = new List<Action<Element>>();
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

        public virtual void OnEnable(
            )
        {
            Document = GetComponent<UIDocument>();
            DocumentElement = Document.rootVisualElement;
            DocumentElement.RegisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );

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
            DocumentElement.UnregisterCallback<GeometryChangedEvent>( HandleGeometryChangedEvent );
        }
    }
}

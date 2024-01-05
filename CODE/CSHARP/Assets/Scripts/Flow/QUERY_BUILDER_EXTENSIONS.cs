// -- IMPORTS

using UnityEngine.UIElements;

// -- TYPES

public static class QUERY_BUILDER_EXTENSIONS
{
    // -- OPERATIONS

    public static void SetBottom(
        this UQueryBuilder<VisualElement> query_builder,
        float bottom
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.bottom = bottom;
        }
    }

    // ~~

    public static void SetBorderBottomLeftRadius(
        this UQueryBuilder<VisualElement> query_builder,
        float borderBottomLeftRadius
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderBottomLeftRadius = borderBottomLeftRadius;
        }
    }

    // ~~

    public static void SetBorderBottomRightRadius(
        this UQueryBuilder<VisualElement> query_builder,
        float borderBottomRightRadius
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderBottomRightRadius = borderBottomRightRadius;
        }
    }

    // ~~

    public static void SetBorderBottomWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float borderBottomWidth
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderBottomWidth = borderBottomWidth;
        }
    }

    // ~~

    public static void SetBorderLeftWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float borderLeftWidth
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderLeftWidth = borderLeftWidth;
        }
    }

    // ~~

    public static void SetBorderRightWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float borderRightWidth
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderRightWidth = borderRightWidth;
        }
    }

    // ~~

    public static void SetBorderTopLeftRadius(
        this UQueryBuilder<VisualElement> query_builder,
        float borderTopLeftRadius
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderTopLeftRadius = borderTopLeftRadius;
        }
    }

    // ~~

    public static void SetBorderTopRightRadius(
        this UQueryBuilder<VisualElement> query_builder,
        float borderTopRightRadius
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderTopRightRadius = borderTopRightRadius;
        }
    }

    // ~~

    public static void SetBorderTopWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float borderTopWidth
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.borderTopWidth = borderTopWidth;
        }
    }

    // ~~

    public static void SetFontSize(
        this UQueryBuilder<VisualElement> query_builder,
        float fontSize
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.fontSize = fontSize;
        }
    }

    // ~~

    public static void SetHeight(
        this UQueryBuilder<VisualElement> query_builder,
        float height
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.height = height;
        }
    }

    // ~~

    public static void SetLeft(
        this UQueryBuilder<VisualElement> query_builder,
        float left
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.left = left;
        }
    }

    // ~~

    public static void SetMarginBottom(
        this UQueryBuilder<VisualElement> query_builder,
        float marginBottom
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.marginBottom = marginBottom;
        }
    }

    // ~~

    public static void SetMarginLeft(
        this UQueryBuilder<VisualElement> query_builder,
        float marginLeft
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.marginLeft = marginLeft;
        }
    }

    // ~~

    public static void SetMarginRight(
        this UQueryBuilder<VisualElement> query_builder,
        float marginRight
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.marginRight = marginRight;
        }
    }

    // ~~

    public static void SetMarginTop(
        this UQueryBuilder<VisualElement> query_builder,
        float marginTop
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.marginTop = marginTop;
        }
    }

    // ~~

    public static void SetMaxHeight(
        this UQueryBuilder<VisualElement> query_builder,
        float maxHeight
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.maxHeight = maxHeight;
        }
    }

    // ~~

    public static void SetMaxWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float maxWidth
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.maxWidth = maxWidth;
        }
    }

    // ~~

    public static void SetMinHeight(
        this UQueryBuilder<VisualElement> query_builder,
        float minHeight
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.minHeight = minHeight;
        }
    }

    // ~~

    public static void SetMinWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float minWidth
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.minWidth = minWidth;
        }
    }

    // ~~

    public static void SetPaddingBottom(
        this UQueryBuilder<VisualElement> query_builder,
        float paddingBottom
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.paddingBottom = paddingBottom;
        }
    }

    // ~~

    public static void SetPaddingLeft(
        this UQueryBuilder<VisualElement> query_builder,
        float paddingLeft
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.paddingLeft = paddingLeft;
        }
    }

    // ~~

    public static void SetPaddingRight(
        this UQueryBuilder<VisualElement> query_builder,
        float paddingRight
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.paddingRight = paddingRight;
        }
    }

    // ~~

    public static void SetPaddingTop(
        this UQueryBuilder<VisualElement> query_builder,
        float paddingTop
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.paddingTop = paddingTop;
        }
    }

    // ~~

    public static void SetRight(
        this UQueryBuilder<VisualElement> query_builder,
        float right
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.right = right;
        }
    }

    // ~~

    public static void SetTop(
        this UQueryBuilder<VisualElement> query_builder,
        float top
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.top = top;
        }
    }

    // ~~

    public static void SetWidth(
        this UQueryBuilder<VisualElement> query_builder,
        float width
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.width = width;
        }
    }

    // ~~

    public static void SetWordSpacing(
        this UQueryBuilder<VisualElement> query_builder,
        float wordSpacing
        )
    {
        foreach ( var query_element in query_builder.Build() )
        {
            query_element.style.wordSpacing = wordSpacing;
        }
    }
}

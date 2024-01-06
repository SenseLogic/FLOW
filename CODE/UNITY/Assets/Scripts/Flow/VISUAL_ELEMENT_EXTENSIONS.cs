// -- IMPORTS

using System;
using UnityEngine.UIElements;

// -- TYPES

using Element = UnityEngine.UIElements.VisualElement;

// ~~

public static class VISUAL_ELEMENT_EXTENSIONS
{
    // -- OPERATIONS

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );
        child_element.AddToClassList( fifth_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );
        child_element.AddToClassList( fifth_class_name );
        child_element.AddToClassList( sixth_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );
        child_element.AddToClassList( fifth_class_name );
        child_element.AddToClassList( sixth_class_name );
        child_element.AddToClassList( seventh_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );
        child_element.AddToClassList( fifth_class_name );
        child_element.AddToClassList( sixth_class_name );
        child_element.AddToClassList( seventh_class_name );
        child_element.AddToClassList( eighth_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name,
        string ninth_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );
        child_element.AddToClassList( fifth_class_name );
        child_element.AddToClassList( sixth_class_name );
        child_element.AddToClassList( seventh_class_name );
        child_element.AddToClassList( eighth_class_name );
        child_element.AddToClassList( ninth_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

    public static _ELEMENT_ Create<_ELEMENT_>(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name,
        string ninth_class_name,
        string tenth_class_name
        )
        where _ELEMENT_ : VisualElement, new()
    {
        _ELEMENT_
            child_element;

        child_element = new _ELEMENT_();
        child_element.AddToClassList( first_class_name );
        child_element.AddToClassList( second_class_name );
        child_element.AddToClassList( third_class_name );
        child_element.AddToClassList( fourth_class_name );
        child_element.AddToClassList( fifth_class_name );
        child_element.AddToClassList( sixth_class_name );
        child_element.AddToClassList( seventh_class_name );
        child_element.AddToClassList( eighth_class_name );
        child_element.AddToClassList( ninth_class_name );
        child_element.AddToClassList( tenth_class_name );

        element.Add( child_element );

        return child_element;
    }

    // ~~

        public static void AddClass(
        this Element element,
        string class_name
        )
    {
        element.AddToClassList( class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
        element.AddToClassList( fifth_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
        element.AddToClassList( fifth_class_name );
        element.AddToClassList( sixth_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
        element.AddToClassList( fifth_class_name );
        element.AddToClassList( sixth_class_name );
        element.AddToClassList( seventh_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
        element.AddToClassList( fifth_class_name );
        element.AddToClassList( sixth_class_name );
        element.AddToClassList( seventh_class_name );
        element.AddToClassList( eighth_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name,
        string ninth_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
        element.AddToClassList( fifth_class_name );
        element.AddToClassList( sixth_class_name );
        element.AddToClassList( seventh_class_name );
        element.AddToClassList( eighth_class_name );
        element.AddToClassList( ninth_class_name );
    }

    // ~~

    public static void AddClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name,
        string ninth_class_name,
        string tenth_class_name
        )
    {
        element.AddToClassList( first_class_name );
        element.AddToClassList( second_class_name );
        element.AddToClassList( third_class_name );
        element.AddToClassList( fourth_class_name );
        element.AddToClassList( fifth_class_name );
        element.AddToClassList( sixth_class_name );
        element.AddToClassList( seventh_class_name );
        element.AddToClassList( eighth_class_name );
        element.AddToClassList( ninth_class_name );
        element.AddToClassList( tenth_class_name );
    }

    // ~~

    public static void RemoveClass(
        this Element element,
        string class_name
        )
    {
        element.RemoveFromClassList( class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
        element.RemoveFromClassList( fifth_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
        element.RemoveFromClassList( fifth_class_name );
        element.RemoveFromClassList( sixth_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
        element.RemoveFromClassList( fifth_class_name );
        element.RemoveFromClassList( sixth_class_name );
        element.RemoveFromClassList( seventh_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
        element.RemoveFromClassList( fifth_class_name );
        element.RemoveFromClassList( sixth_class_name );
        element.RemoveFromClassList( seventh_class_name );
        element.RemoveFromClassList( eighth_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name,
        string ninth_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
        element.RemoveFromClassList( fifth_class_name );
        element.RemoveFromClassList( sixth_class_name );
        element.RemoveFromClassList( seventh_class_name );
        element.RemoveFromClassList( eighth_class_name );
        element.RemoveFromClassList( ninth_class_name );
    }

    // ~~

    public static void RemoveClasses(
        this Element element,
        string first_class_name,
        string second_class_name,
        string third_class_name,
        string fourth_class_name,
        string fifth_class_name,
        string sixth_class_name,
        string seventh_class_name,
        string eighth_class_name,
        string ninth_class_name,
        string tenth_class_name
        )
    {
        element.RemoveFromClassList( first_class_name );
        element.RemoveFromClassList( second_class_name );
        element.RemoveFromClassList( third_class_name );
        element.RemoveFromClassList( fourth_class_name );
        element.RemoveFromClassList( fifth_class_name );
        element.RemoveFromClassList( sixth_class_name );
        element.RemoveFromClassList( seventh_class_name );
        element.RemoveFromClassList( eighth_class_name );
        element.RemoveFromClassList( ninth_class_name );
        element.RemoveFromClassList( tenth_class_name );
    }

    // ~~

    public static void ToggleClass(
        this Element element,
        string class_name,
        bool condition
        )
    {
        element.EnableInClassList( class_name, condition );
    }

    // ~~

    public static UQueryBuilder<VisualElement> GetElements(
        this Element element,
        string class_name
        )
    {
        return element.Query<VisualElement>().Class( class_name );
    }

    // ~~

    public static void ProcessElements(
        this Element element,
        string class_name,
        Action<Element> action
        )
    {
        foreach ( var query_element in element.Query<VisualElement>().Class( class_name ).Build() )
        {
            action( element );
        }
    }

    // ~~

    public static void SetBottom(
        this Element element,
        float bottom
        )
    {
        element.style.bottom = bottom;
    }

    // ~~

    public static void SetBottom(
        this Element element,
        string class_name,
        float bottom
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBottom( bottom );
    }

    // ~~

    public static void SetBorderBottomLeftRadius(
        this Element element,
        float borderBottomLeftRadius
        )
    {
        element.style.borderBottomLeftRadius = borderBottomLeftRadius;
    }

    // ~~

    public static void SetBorderBottomLeftRadius(
        this Element element,
        string class_name,
        float borderBottomLeftRadius
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderBottomLeftRadius( borderBottomLeftRadius );
    }

    // ~~

    public static void SetBorderBottomRightRadius(
        this Element element,
        float borderBottomRightRadius
        )
    {
        element.style.borderBottomRightRadius = borderBottomRightRadius;
    }

    // ~~

    public static void SetBorderBottomRightRadius(
        this Element element,
        string class_name,
        float borderBottomRightRadius
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderBottomRightRadius( borderBottomRightRadius );
    }

    // ~~

    public static void SetBorderBottomWidth(
        this Element element,
        float borderBottomWidth
        )
    {
        element.style.borderBottomWidth = borderBottomWidth;
    }

    // ~~

    public static void SetBorderBottomWidth(
        this Element element,
        string class_name,
        float borderBottomWidth
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderBottomWidth( borderBottomWidth );
    }

    // ~~

    public static void SetBorderLeftWidth(
        this Element element,
        float borderLeftWidth
        )
    {
        element.style.borderLeftWidth = borderLeftWidth;
    }

    // ~~

    public static void SetBorderLeftWidth(
        this Element element,
        string class_name,
        float borderLeftWidth
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderLeftWidth( borderLeftWidth );
    }

    // ~~

    public static void SetBorderRightWidth(
        this Element element,
        float borderRightWidth
        )
    {
        element.style.borderRightWidth = borderRightWidth;
    }

    // ~~

    public static void SetBorderRightWidth(
        this Element element,
        string class_name,
        float borderRightWidth
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderRightWidth( borderRightWidth );
    }

    // ~~

    public static void SetBorderTopLeftRadius(
        this Element element,
        float borderTopLeftRadius
        )
    {
        element.style.borderTopLeftRadius = borderTopLeftRadius;
    }

    // ~~

    public static void SetBorderTopLeftRadius(
        this Element element,
        string class_name,
        float borderTopLeftRadius
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderTopLeftRadius( borderTopLeftRadius );
    }

    // ~~

    public static void SetBorderTopRightRadius(
        this Element element,
        float borderTopRightRadius
        )
    {
        element.style.borderTopRightRadius = borderTopRightRadius;
    }

    // ~~

    public static void SetBorderTopRightRadius(
        this Element element,
        string class_name,
        float borderTopRightRadius
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderTopRightRadius( borderTopRightRadius );
    }

    // ~~

    public static void SetBorderTopWidth(
        this Element element,
        float borderTopWidth
        )
    {
        element.style.borderTopWidth = borderTopWidth;
    }

    // ~~

    public static void SetBorderTopWidth(
        this Element element,
        string class_name,
        float borderTopWidth
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetBorderTopWidth( borderTopWidth );
    }

    // ~~

    public static void SetFontSize(
        this Element element,
        float fontSize
        )
    {
        element.style.fontSize = fontSize;
    }

    // ~~

    public static void SetFontSize(
        this Element element,
        string class_name,
        float fontSize
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetFontSize( fontSize );
    }

    // ~~

    public static void SetHeight(
        this Element element,
        float height
        )
    {
        element.style.height = height;
    }

    // ~~

    public static void SetHeight(
        this Element element,
        string class_name,
        float height
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetHeight( height );
    }

    // ~~

    public static void SetLeft(
        this Element element,
        float left
        )
    {
        element.style.left = left;
    }

    // ~~

    public static void SetLeft(
        this Element element,
        string class_name,
        float left
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetLeft( left );
    }

    // ~~

    public static void SetMarginBottom(
        this Element element,
        float marginBottom
        )
    {
        element.style.marginBottom = marginBottom;
    }

    // ~~

    public static void SetMarginBottom(
        this Element element,
        string class_name,
        float marginBottom
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMarginBottom( marginBottom );
    }

    // ~~

    public static void SetMarginLeft(
        this Element element,
        float marginLeft
        )
    {
        element.style.marginLeft = marginLeft;
    }

    // ~~

    public static void SetMarginLeft(
        this Element element,
        string class_name,
        float marginLeft
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMarginLeft( marginLeft );
    }

    // ~~

    public static void SetMarginRight(
        this Element element,
        float marginRight
        )
    {
        element.style.marginRight = marginRight;
    }

    // ~~

    public static void SetMarginRight(
        this Element element,
        string class_name,
        float marginRight
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMarginRight( marginRight );
    }

    // ~~

    public static void SetMarginTop(
        this Element element,
        float marginTop
        )
    {
        element.style.marginTop = marginTop;
    }

    // ~~

    public static void SetMarginTop(
        this Element element,
        string class_name,
        float marginTop
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMarginTop( marginTop );
    }

    // ~~

    public static void SetMaxHeight(
        this Element element,
        float maxHeight
        )
    {
        element.style.maxHeight = maxHeight;
    }

    // ~~

    public static void SetMaxHeight(
        this Element element,
        string class_name,
        float maxHeight
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMaxHeight( maxHeight );
    }

    // ~~

    public static void SetMaxWidth(
        this Element element,
        float maxWidth
        )
    {
        element.style.maxWidth = maxWidth;
    }

    // ~~

    public static void SetMaxWidth(
        this Element element,
        string class_name,
        float maxWidth
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMaxWidth( maxWidth );
    }

    // ~~

    public static void SetMinHeight(
        this Element element,
        float minHeight
        )
    {
        element.style.minHeight = minHeight;
    }

    // ~~

    public static void SetMinHeight(
        this Element element,
        string class_name,
        float minHeight
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMinHeight( minHeight );
    }

    // ~~

    public static void SetMinWidth(
        this Element element,
        float minWidth
        )
    {
        element.style.minWidth = minWidth;
    }

    // ~~

    public static void SetMinWidth(
        this Element element,
        string class_name,
        float minWidth
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetMinWidth( minWidth );
    }

    // ~~

    public static void SetPaddingBottom(
        this Element element,
        float paddingBottom
        )
    {
        element.style.paddingBottom = paddingBottom;
    }

    // ~~

    public static void SetPaddingBottom(
        this Element element,
        string class_name,
        float paddingBottom
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetPaddingBottom( paddingBottom );
    }

    // ~~

    public static void SetPaddingLeft(
        this Element element,
        float paddingLeft
        )
    {
        element.style.paddingLeft = paddingLeft;
    }

    // ~~

    public static void SetPaddingLeft(
        this Element element,
        string class_name,
        float paddingLeft
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetPaddingLeft( paddingLeft );
    }

    // ~~

    public static void SetPaddingRight(
        this Element element,
        float paddingRight
        )
    {
        element.style.paddingRight = paddingRight;
    }

    // ~~

    public static void SetPaddingRight(
        this Element element,
        string class_name,
        float paddingRight
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetPaddingRight( paddingRight );
    }

    // ~~

    public static void SetPaddingTop(
        this Element element,
        float paddingTop
        )
    {
        element.style.paddingTop = paddingTop;
    }

    // ~~

    public static void SetPaddingTop(
        this Element element,
        string class_name,
        float paddingTop
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetPaddingTop( paddingTop );
    }

    // ~~

    public static void SetRight(
        this Element element,
        float right
        )
    {
        element.style.right = right;
    }

    // ~~

    public static void SetRight(
        this Element element,
        string class_name,
        float right
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetRight( right );
    }

    // ~~

    public static void SetTop(
        this Element element,
        float top
        )
    {
        element.style.top = top;
    }

    // ~~

    public static void SetTop(
        this Element element,
        string class_name,
        float top
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetTop( top );
    }

    // ~~

    public static void SetWidth(
        this Element element,
        float width
        )
    {
        element.style.width = width;
    }

    // ~~

    public static void SetWidth(
        this Element element,
        string class_name,
        float width
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetWidth( width );
    }

    // ~~

    public static void SetWordSpacing(
        this Element element,
        float wordSpacing
        )
    {
        element.style.wordSpacing = wordSpacing;
    }

    // ~~

    public static void SetWordSpacing(
        this Element element,
        string class_name,
        float wordSpacing
        )
    {
        element.Query<VisualElement>().Class( class_name ).SetWordSpacing( wordSpacing );
    }
}

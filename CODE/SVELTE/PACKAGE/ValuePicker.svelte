<script>
    // -- IMPORTS

    import { createEventDispatcher, onMount } from 'svelte';

    // -- VARIABLES

    export let value = undefined;
    export let valuePrecision = 1;
    export let valuePrefix = '';
    export let valueSuffix = '';
    export let limitArray = [ 0, 100 ];
    export let limitTextArray = [ valuePrefix + limitArray[ 0 ] + valueSuffix, valuePrefix + limitArray[ 1 ] + valueSuffix ];
    export let valueArray = [ limitArray[ 0 ], value ];
    export let hasText = true;
    export let onChange = () => {};
    export let getValueText
        = ( valueArray ) =>
          ( value === undefined )
          ? valuePrefix + valueArray[ 0 ] + valueSuffix + ' - ' + valuePrefix + valueArray[ 1 ] + valueSuffix
          : valuePrefix + valueArray[ 1 ] + valueSuffix;
    export let ariaLabel = "Value picker";

    let valueCount = ( value === undefined ) ? 2 : 1;
    let valuePickerElement;
    let firstSliderElement;
    let secondSliderElement;
    let isDraggingFirstSlider = false;
    let isDraggingSecondSlider = false;

    // -- STATEMENTS

    onMount(
        () =>
        {
            document.addEventListener( 'mousemove', handleMouseMoveEvent );
            document.addEventListener( 'mouseup', handleMouseUpEvent );
            document.addEventListener( 'touchmove', handleTouchMoveEvent, { passive: false } );
            document.addEventListener( 'touchend', handleMouseUpEvent );
        }
        );

    // -- FUNCTIONS

    function getLimitedValue(
        value
        )
    {
        if ( value <= limitArray[ 0 ] )
        {
            return limitArray[ 0 ];
        }
        else if ( value >= limitArray[ 1 ] )
        {
            return limitArray[ 1 ];
        }
        else
        {
            return value;
        }
    }

    // ~~

    function getRoundedValue(
        value
        )
    {
        if ( value <= limitArray[ 0 ] )
        {
            return limitArray[ 0 ];
        }
        else if ( value >= limitArray[ 1 ] )
        {
            return limitArray[ 1 ];
        }
        else
        {
            value = Math.floor( value / valuePrecision ) * valuePrecision;

            return getLimitedValue( value );
        }
    }

    // ~~

    function getRoundedValueArray(
        valueArray
        )
    {
        return [ getRoundedValue( valueArray[ 0 ] ), getRoundedValue( valueArray[ 1 ] ) ];
    }

    // ~~

    function getLeftPositionRatio(
        event
        )
    {
        let clientRectangle = valuePickerElement.getBoundingClientRect();

        let clientXPosition = event.clientX;

        if ( clientXPosition === undefined
             && event.touches !== undefined
             && event.touches.length > 0 )
        {
            clientXPosition = event.touches[ 0 ].clientX;
        }

        if ( clientXPosition === undefined )
        {
            return 0;
        }
        else
        {
            let ratio = ( clientXPosition - clientRectangle.left ) / clientRectangle.width;

            return Math.max( 0, Math.min( 1, ratio ) );
        }
    }

    // ~~

    function getLeftPosition(
        value
        )
    {
        return 100 * ( getLimitedValue( value ) - limitArray[ 0 ] ) / ( limitArray[ 1 ] - limitArray[ 0 ] );
    }

    // ~~

    function handleMouseDownEvent(
        event,
        isFirstSlider
        )
    {
        event.preventDefault();

        if ( isFirstSlider )
        {
            isDraggingFirstSlider = true;
        }
        else
        {
            isDraggingSecondSlider = true;
        }
    }

    // ~~

    function updateSliderValue(
        sliderValue,
        isFirstSlider
        )
    {
        if ( isFirstSlider )
        {
            valueArray = [ Math.min( sliderValue, valueArray[ 1 ] ), valueArray[ 1 ] ];
        }
        else
        {
            valueArray = [ valueArray[ 0 ], Math.max( sliderValue, valueArray[ 0 ] ) ];
        }

        if ( valueCount === 1 )
        {
            value = valueArray[ 1 ];
            onChange( getRoundedValue( value ) );
        }
        else
        {
            onChange( getRoundedValueArray( valueArray ) );
        }
    }

    // ~~

    function handleMouseMoveEvent(
        event
        )
    {
        if ( isDraggingFirstSlider
             || isDraggingSecondSlider )
        {
            let ratio = getLeftPositionRatio( event );
            let sliderValue = limitArray[ 0 ] + ratio * ( limitArray[ 1 ] - limitArray[ 0 ] );

            updateSliderValue( sliderValue, isDraggingFirstSlider );
        }
    }

    // ~~

    function handleMouseUpEvent(
        )
    {
        isDraggingFirstSlider = false;
        isDraggingSecondSlider = false;
    }

    // ~~

    function handleTouchMoveEvent(
        event
        )
    {
        handleMouseMoveEvent( event );

        event.preventDefault();
    }

    // ~~

    function handleKeyDownEvent(
        event,
        isFirstSlider
        )
    {
        let sliderValue = isFirstSlider ? valueArray[ 0 ] : valueArray[ 1 ];

        if ( event.key == 'ArrowLeft' )
        {
            updateSliderValue( sliderValue - valuePrecision, isFirstSlider );
        }
        else if ( event.key == 'ArrowRight' )
        {
            updateSliderValue( sliderValue + valuePrecision, isFirstSlider );
        }
        else if ( event.key == 'ArrowDown' )
        {
            updateSliderValue( sliderValue - 5 * valuePrecision, isFirstSlider );
        }
        else if ( event.key == 'ArrowUp' )
        {
            updateSliderValue( sliderValue + 5 * valuePrecision, isFirstSlider );
        }
        else if ( event.key == 'Home' )
        {
            updateSliderValue( limitArray[ 0 ], isFirstSlider );
        }
        else if ( event.key == 'End' )
        {
            updateSliderValue( limitArray[ 1 ], isFirstSlider );
        }
    }
</script>

<div
    bind:this={ valuePickerElement }
    class="value-picker"
    class:is-range={ valueCount === 2 }
    role="group"
    aria-label="{ ariaLabel }"
>
    <div
        class="track"
    ></div>
    <div class="frame">
        <div
            class="range"
            style="left: { getLeftPosition( valueArray[ 0 ] ) }%; width: calc( 8px + { getLeftPosition( valueArray[ 1 ] ) - getLeftPosition( valueArray[ 0 ] ) }% )"
        ></div>
        { #if valueCount === 2 }
            <div
                bind:this={ firstSliderElement }
                class="slider"
                style="left: { getLeftPosition( valueArray[ 0 ] ) }%"
                tabindex="0"
                role="slider"
                aria-valuemin={ limitArray[ 0 ]}
                aria-valuemax={ limitArray[ 1 ] }
                aria-valuenow={ valueArray[ 0 ] }
                aria-valuetext={ getValueText( valueArray ) }
                aria-label="First value"
                on:mousedown={ ( event ) => handleMouseDownEvent( event, true ) }
                on:touchstart={ ( event ) => handleMouseDownEvent( event, true ) }
                on:keydown={ ( event ) => handleKeyDownEvent( event, true ) }
            ></div>
        { /if }
        <div
            bind:this={ secondSliderElement }
            class="slider"
            style="left: { getLeftPosition( valueArray[ 1 ] ) }%"
            tabindex="0"
            role="slider"
            aria-valuemin={ limitArray[ 0 ]}
            aria-valuemax={ limitArray[ 1 ] }
            aria-valuenow={ valueArray[ 1 ] }
            aria-valuetext={ getValueText( valueArray ) }
            aria-label="Second value"
            on:mousedown={ ( event ) => handleMouseDownEvent( event, false ) }
            on:touchstart={ ( event ) => handleMouseDownEvent( event, false ) }
            on:keydown={ ( event ) => handleKeyDownEvent( event, false ) }
        ></div>
    </div>
    { #if hasText }
        <div class="text">
            <span class="left-text">{ limitTextArray[ 0 ] }</span>
            <span class="middle-text">{ getValueText( getRoundedValueArray( valueArray ) ) }</span>
            <span class="right-text">{ limitTextArray[ 1 ] }</span>
        </div>
    { /if }
</div>

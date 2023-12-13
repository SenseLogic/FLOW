<script>
    // -- IMPORTS

    import { createEventDispatcher, onMount } from 'svelte';

    // -- EXPORTS

    export let limitArray = [ 0, 100 ];
    export let valueArray = [ 0, 50 ];
    export let valuePrefix = '';
    export let valueSuffix = '';
    export let valuePrecision = 1;
    export let onChange = () => {};

    // -- VARIABLES

    let valuePicker;
    let firstSlider;
    let secondSlider;
    let isDraggingFirstSlider = false;
    let isDraggingSecondSlider = false;

    // -- STATEMENTS

    onMount(
        () =>
        {
            document.addEventListener( 'mousemove', handleMouseMove );
            document.addEventListener( 'mouseup', handleMouseUp );
            document.addEventListener( 'touchmove', handleTouchMove, { passive: false } );
            document.addEventListener( 'touchend', handleMouseUp );
        }
        );

    // -- FUNCTIONS

    function getRoundValue(
        value
        )
    {
        return Math.floor( value / valuePrecision ) * valuePrecision;
    }

    // ~~

    function getLeftPositionRatio(
        event
        )
    {
        let clientRectangle = valuePicker.getBoundingClientRect();
        let clientXPosition = event.clientX || event.touches[ 0 ].clientX;

        let ratio = ( clientXPosition - clientRectangle.left ) / clientRectangle.width;

        return Math.max( 0, Math.min( 1, ratio ) );
    }

    // ~~

    function getLeftPosition(
        value
        )
    {
        return 100 * ( value - limitArray[ 0 ] ) / ( limitArray[ 1 ] - limitArray[ 0 ] );
    }

    // ~~

    function handleMouseDown(
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

    function handleMouseMove(
        event
        )
    {
        if ( isDraggingFirstSlider
             || isDraggingSecondSlider )
        {
            let ratio = getLeftPositionRatio( event );

            if ( isDraggingFirstSlider )
            {
                valueArray = [ Math.min( ratio * limitArray[ 1 ], valueArray[ 1 ] ), valueArray[ 1 ] ];
            }
            else
            {
                valueArray = [ valueArray[ 0 ], Math.max( ratio * limitArray[ 1 ], valueArray[ 0 ] ) ];
            }

            onChange( valueArray );
        }
    }

    // ~~

    function handleMouseUp(
        )
    {
        isDraggingFirstSlider = false;
        isDraggingSecondSlider = false;
    }

    // ~~

    function handleTouchMove(
        event
        )
    {
        handleMouseMove( event );
        event.preventDefault();
    }
</script>

<div bind:this={ valuePicker } class="value-picker">
    <div
        class="track"
    ></div>
    <div class="frame">
        <div
            class="range"
            style="left: { getLeftPosition( valueArray[ 0 ] ) }%; width: { getLeftPosition( valueArray[ 1 ] ) - getLeftPosition( valueArray[ 0 ] ) }%"
        ></div>
        <div
            bind:this={ firstSlider }
            class="slider"
            style="left: { getLeftPosition( valueArray[ 0 ] ) }%"
            on:mousedown={ ( event ) => handleMouseDown( event, true ) }
            on:touchstart={ ( event ) => handleMouseDown( event, true ) }
        ></div>
        <div
            bind:this={ secondSlider }
            class="slider"
            style="left: { getLeftPosition( valueArray[ 1 ] ) }%"
            on:mousedown={ ( event ) => handleMouseDown( event, false ) }
            on:touchstart={ ( event ) => handleMouseDown( event, false ) }
        ></div>
    </div>
    <div class="legend">
        <span>{ valuePrefix }{ getRoundValue( limitArray[ 0 ] ) }{ valueSuffix }</span>
        <span>{ valuePrefix }{ getRoundValue( valueArray[ 0 ] ) }{ valueSuffix } - { valuePrefix }{ getRoundValue( valueArray[ 1 ] ) }{ valueSuffix }</span>
        <span>{ valuePrefix }{ getRoundValue( limitArray[ 1 ] ) }{ valueSuffix }</span>
    </div>
</div>

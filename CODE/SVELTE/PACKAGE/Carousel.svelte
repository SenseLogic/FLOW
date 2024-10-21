<script>
    // -- IMPORTS

    import { onMount, onDestroy } from 'svelte';

    // -- VARIABLES

    export let columnCount = 1;
    export let hasCount = true;
    export let hasDots = true;
    export let hasButtons = true;
    export let isAutomatic = false;
    export let stayDuration = 2000;
    export let transitionDuration = 700;
    export let resumeDuration = 3000;
    export let onChange = () => {};

    let slideIndex = 0;
    let slideCount = 0;
    let carouselElement;
    let stripElement;
    let resizeObserver;
    let nextSlideInterval;
    let resumeTimeout;
    let isTransitioning = false;

    // -- FUNCTIONS

    function getColumnGapWidth(
        )
    {
        return parseFloat( getComputedStyle( stripElement ).columnGap ) || 0;
    }

    // ~~

    function getSlideWidth(
        columnGapWidth
        )
    {
        return ( carouselElement.offsetWidth - ( columnCount - 1 ) * columnGapWidth ) / columnCount;
    }

    // ~~

    function setSlideIndex(
        newSlideIndex,
        isImmediate = false
        )
    {
        slideIndex = newSlideIndex;

        if ( stripElement )
        {
            stripElement.style.transitionDuration = isImmediate ? '0ms' : transitionDuration + 'ms';

            let columnGapWidth = getColumnGapWidth();
            let slideWidth = getSlideWidth( columnGapWidth );
            stripElement.style.transform = 'translateX(' + -( slideIndex * ( slideWidth + columnGapWidth ) ) + 'px)';

            if ( !isImmediate )
            {
                onChange( { slideIndex, slideCount } );
            }
        }
    }

    // ~~

    function initialize()
    {
        slideCount = stripElement.children.length / 2;

        let columnGapWidth = getColumnGapWidth();
        let slideWidth = getSlideWidth( columnGapWidth );
        stripElement.style.width = ( slideCount * slideWidth + ( slideCount - 1 ) * columnGapWidth ) + 'px';

        for ( let slideElement of stripElement.children )
        {
            slideElement.style.flex = '0 0 ' + slideWidth + 'px';
        }

        setSlideIndex( slideIndex );

        if ( slideCount < columnCount )
        {
            for ( let slideIndex = slideCount;
                  slideIndex < slideCount * 2;
                  ++slideIndex )
            {
                stripElement.children[ slideIndex ].style.display = 'none';
            }
        }
    }

    // ~~

    function showPriorSlide(
        )
    {
        if ( slideCount > columnCount
             && !isTransitioning )
        {
            isTransitioning = true;

            if ( slideIndex === 0 )
            {
                setSlideIndex( slideCount, true );

                window.requestAnimationFrame(
                    () =>
                    {
                        setSlideIndex( slideCount - 1 );
                    }
                    );
            }
            else
            {
                setSlideIndex( slideIndex - 1 );
            }

            setTimeout(
                () =>
                {
                    isTransitioning = false;
                },
                transitionDuration
                );
        }
    }

    // ~~

    function showNextSlide(
        )
    {
        if ( slideCount > columnCount
             && !isTransitioning )
        {
            isTransitioning = true;
            setSlideIndex( slideIndex + 1 );

            setTimeout(
                () =>
                {
                    if ( slideIndex === slideCount )
                    {
                        setSlideIndex( 0, true );
                    }

                    isTransitioning = false;
                },
                transitionDuration
                );
        }
    }

    // ~~

    function resume(
        action
        )
    {
        if ( slideCount > columnCount )
        {
            pause();
            action();

            if ( resumeTimeout )
            {
                clearTimeout( resumeTimeout );
            }

            resumeTimeout = setTimeout( start, resumeDuration );
        }
    }

    // ~~

    function handleKeydown( event )
    {
        if ( event.key === 'ArrowLeft' )
        {
            resume( showPriorSlide );
        }
        else if ( event.key === 'ArrowRight' )
        {
            resume( showNextSlide );
        }
    }

    // ~~

    function start()
    {
        if ( slideCount > columnCount
             && isAutomatic )
        {
            nextSlideInterval = setInterval( showNextSlide, stayDuration + transitionDuration );
        }
    }

    // ~~

    function pause()
    {
        if ( nextSlideInterval )
        {
            clearInterval( nextSlideInterval );
        }
    }

    // -- STATEMENTS

    onMount(
        () =>
        {
            initialize();

            resizeObserver =
                new ResizeObserver(
                    () =>
                    {
                        initialize();
                    }
                );

            resizeObserver.observe( carouselElement );

            start();

            return (
                () =>
                {
                    if ( resizeObserver )
                    {
                        resizeObserver.disconnect();
                    }

                    pause();
                }
                );
        }
        );

    onDestroy(
        () =>
        {
            pause();

            if ( resumeTimeout )
            {
                clearTimeout( resumeTimeout );
            }
        }
        );
</script>

<div class="carousel" bind:this={ carouselElement } on:keydown={ handleKeydown } tabindex="0">
    <div bind:this={ stripElement } class="carousel-strip" style="transition-duration: { transitionDuration }ms;">
        <slot></slot>
        <slot></slot>
    </div>

    { #if hasCount && slideCount }
        <div class="carousel-count">{ ( slideIndex % slideCount ) + 1 }/{ slideCount }</div>
    { /if }

    { #if hasDots && slideCount }
        <div class="carousel-dot-list">
            { #each { length: slideCount } as _, dotIndex }
                <div class="carousel-dot { dotIndex === ( slideIndex % slideCount ) ? 'active' : '' }"></div>
            { /each }
        </div>
    { /if }

    { #if hasButtons }
        <button class="carousel-button carousel-prior-slide-button" on:click={ () => resume( showPriorSlide ) }>&#x276E;</button>
        <button class="carousel-button carousel-next-slide-button" on:click={ () => resume( showNextSlide ) }>&#x276F;</button>
    { /if }
</div>

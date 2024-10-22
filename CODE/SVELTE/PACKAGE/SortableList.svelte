<script>
    // -- IMPORTS

    import { onMount } from 'svelte';

    // -- VARIABLES

    export let elementArray;
    export let onChange = () => {};
    export let ariaLabel = "Sortable list";

    let listIndex = Math.floor( Math.random() * Number.MAX_SAFE_INTEGER );
    let listElement;
    let draggableElementArray = [];

    // -- FUNCTIONS

    function handleDragStartEvent(
        event,
        oldElementIndex
        )
    {
        event.dataTransfer.setData( 'oldListIndex', listIndex );
        event.dataTransfer.setData( 'oldElementIndex', oldElementIndex );
        event.currentTarget.setAttribute( 'aria-grabbed', 'true' );
    }

    // ~~

    function handleDropEvent(
        event,
        newElementIndex
        )
    {
        event.preventDefault();

        let oldListIndex = parseInt( event.dataTransfer.getData( 'oldListIndex' ) );

        if ( oldListIndex === listIndex )
        {
            let oldElementIndex = parseInt( event.dataTransfer.getData( 'oldElementIndex' ) );
            let oldElement = elementArray[ oldElementIndex ];

            elementArray.splice( oldElementIndex, 1 );
            elementArray.splice( newElementIndex, 0, oldElement );
            elementArray = elementArray;

            onChange( elementArray );

            for ( let draggableElement of draggableElementArray )
            {
                draggableElement.setAttribute( 'aria-grabbed', 'false' );
            }
        }
    }

    // ~~

    function handleDragOverEvent(
        event
        )
    {
        event.preventDefault();
    }

    // -- STATEMENTS

    onMount(
        () =>
        {
            draggableElementArray = [ ...listElement.querySelectorAll( '.element' ) ];
        }
        );
</script>

<div class="sortable-list" aria-label="{ ariaLabel }" bind:this={ listElement }>
    {#each elementArray as element, elementIndex }
        <div class="element"
            draggable="true"
            on:dragstart={ ( event ) => handleDragStartEvent( event, elementIndex ) }
            on:dragover={ handleDragOverEvent }
            on:drop={ ( event ) => handleDropEvent( event, elementIndex ) }
            role="listitem"
            aria-grabbed="false"
        >
            <slot { element }></slot>
        </div>
    {/each}
</div>

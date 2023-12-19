<script>
    // -- VARIABLES

    export let elementArray;
    export let onChange = () => {};

    let listIndex = Math.floor( Math.random() * Number.MAX_SAFE_INTEGER );

    // -- FUNCTIONS

    function handleDragStartEvent(
        event,
        oldElementIndex
        )
    {
        event.dataTransfer.setData( 'oldListIndex', listIndex );
        event.dataTransfer.setData( 'oldElementIndex', oldElementIndex );
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
        }
    }

    // ~~

    function handleDragOverEvent(
        event
        )
    {
        event.preventDefault();
    }
</script>

<div class="sortable-list">
    { #each elementArray as element, elementIndex }
        <div class="element"
            draggable="true"
            on:dragstart={ ( event ) => handleDragStartEvent( event, elementIndex ) }
            on:dragover={ handleDragOverEvent }
            on:drop={ ( event ) => handleDropEvent( event, elementIndex ) }
        >
            <slot { element }></slot>
        </div>
    { /each}
</div>

<style>
    /* Add your CSS styling here */
    li
    {
        cursor: grab;
    }
</style>

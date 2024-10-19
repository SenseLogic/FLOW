<script>
    // -- IMPORTS

    import { onMount, onDestroy } from 'svelte';
    import { writable } from 'svelte/store';

    // -- VARIABLES

    export let optionArray = [];
    let searchedText = "";
    let selectedOptionArrayStore = writable( [] );
    let isDropdownOpen = false;
    let inputElement;
    let dropdownElement;
    let availableOptionArray = [];

    // -- FUNCTIONS

    function toggleDropdown(
        )
    {
        isDropdownOpen = !isDropdownOpen;
    }

    // ~~

    function hasSelectedOption(
        searchedOption
        )
    {
        return (
            $selectedOptionArrayStore.findIndex(
                ( selectedOption ) =>
                selectedOption.value === searchedOption.value
                )
            >= 0
            );
    }

    // ~~

    function addSelectedOption(
        addedOption
        )
    {
        selectedOptionArrayStore.update(
            ( currentSelectedOptionArray ) =>
            {
                if ( currentSelectedOptionArray.findIndex(
                         ( currentOption ) =>
                         currentOption.value === addedOption.value
                         )
                     < 0 )
                {
                    return [ ...currentSelectedOptionArray, addedOption ];
                }

                return currentSelectedOptionArray;
            }
            );

        searchedText = "";
        isDropdownOpen = false;
    }

    // ~~

    function removeSelectedOption(
        removedOption
        )
    {
        selectedOptionArrayStore.update(
            ( selectedOptionArray ) =>
            selectedOptionArray.filter(
                ( selectedOption ) =>
                selectedOption.value !== removedOption.value
                )
            );
    }

    // ~~

    function updateAvailableOptionArray()
    {
        if ( searchedText === '' )
        {
            availableOptionArray = optionArray;
        }
        else
        {
            availableOptionArray =
                optionArray.filter(
                    ( availableOption ) =>
                    availableOption.label.toLowerCase().includes( searchedText.toLowerCase() )
                    );
        }
    }

    // ~~

    function handleDocumentClickEvent(
        event
        )
    {
        if ( dropdownElement
             && !dropdownElement.contains( event.target )
             && inputElement
             && !inputElement.contains( event.target ) )
        {
            isDropdownOpen = false;
        }
    }

    // -- STATEMENTS

    $: updateAvailableOptionArray( searchedText );

    onMount(
        () =>
        {
            document.addEventListener( 'click', handleDocumentClickEvent );

            return (
                () =>
                {
                    document.removeEventListener( 'click', handleDocumentClickEvent );
                }
                );
        }
        );
</script>

<div class="multi-select">
    <div class="multi-select-selected-option-list">
        { #each $selectedOptionArrayStore as selectedOption ( selectedOption.value ) }
            <div class="multi-select-selected-option">
                { selectedOption.label }
                <button on:click={ () => removeSelectedOption( selectedOption ) }>×</button>
            </div>
        { /each }
    </div>

    <input
        type="text"
        bind:this={ inputElement }
        bind:value={ searchedText }
        class="multi-select-input"
        on:click={ toggleDropdown }
        placeholder="Search..."
    />

    { #if isDropdownOpen }
        <div class="multi-select-dropdown" bind:this={ dropdownElement }>
            { #each availableOptionArray as availableOption ( availableOption.value ) }
                <div
                    class="multi-select-available-option { hasSelectedOption( availableOption ) ? 'is-selected' : ''}"
                    on:click={ () => addSelectedOption( availableOption ) }>
                    { availableOption.label }
                </div>
            { /each }
        </div>
    { /if }
</div>

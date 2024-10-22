<script>
    // -- IMPORTS

    import { onMount, onDestroy } from 'svelte';
    import { writable } from 'svelte/store';

    // -- VARIABLES

    export let optionArray = [];
    export let placeholder = '';
    export let valueArray = writable( [] );
    export let onChange = () => {};
    let searchedText = '';
    $: lowerCaseSearchText = searchedText.toLowerCase();
    let availableOptionArray = optionArray;
    let selectedOptionArray = [];
    let isDropdownOpen = false;
    let inputElement;
    let dropdownElement;
    let multiSelectElement;
    let inputElementWidth = '3em';

    // -- FUNCTIONS

    function hideDropdown(
        )
    {
        isDropdownOpen = false;
    }

    // ~~

    function showDropdown(
        )
    {
        isDropdownOpen = true;
    }

    // ~~

    function toggleDropdown(
        )
    {
        isDropdownOpen = !isDropdownOpen;
    }

    // ~~

    function handleDocumentClickEvent(
        event
        )
    {
        if ( !multiSelectElement.contains( event.target ) )
        {
            hideDropdown();
        }
    }

    // ~~

    function hasSelectedValue(
        value
        )
    {
        return selectedOptionArray.findIndex( ( selectedOption ) => selectedOption.value === value ) >= 0;
    }

    // ~~

    function hasSelectedOption(
        option
        )
    {
        return hasSelectedValue( option.value );
    }

    // ~~

    function isAvailableOption(
        option
        )
    {
        return (
            !hasSelectedOption( option )
            && ( searchedText === ''
                 || option.label.toLowerCase().includes( lowerCaseSearchText ) )
            );
    }

    // ~~

    function updateAvailableOptionArray(
        )
    {
        availableOptionArray = optionArray.filter( isAvailableOption );
    }

    // ~~

    function getTextWidth(
        text,
        font
        )
    {
        let canvas = document.createElement( 'canvas' );
        let context = canvas.getContext( '2d' );
        context.font = font;

        return context.measureText( text ).width;
    }

    // ~~

    function updateInputWidth(
        )
    {
        if ( inputElement )
        {
            let computedStyle = window.getComputedStyle( inputElement );
            let textWidth = getTextWidth( inputElement.value, computedStyle.font );

            inputElementWidth = ( textWidth + parseFloat( computedStyle.fontSize ) * 3 ) + 'px';
        }
    }

    // ~~

    function findOptionByValue(
        value
        )
    {
        for ( let option of optionArray )
        {
            if ( option.value === value )
            {
                return option;
            }
        }

        return null;
    }

    // ~~

    function updateValueArray(
        )
    {
        valueArray = selectedOptionArray.map( option => option.value );
        onChange( valueArray );
    }

    // ~~

    function updateSelectedOptionArray(
        )
    {
        updateValueArray();
        updateAvailableOptionArray();
    }

    // ~~

    function addSelectedOption(
        addedOption
        )
    {
        if ( selectedOptionArray.findIndex( ( currentOption ) => currentOption.value === addedOption.value ) < 0 )
        {
            selectedOptionArray.push( addedOption );
            selectedOptionArray = selectedOptionArray;

            updateSelectedOptionArray();
        }

        searchedText = "";
        updateInputWidth();
        showDropdown();
    }

    // ~~

    function removeSelectedOption(
        removedOption
        )
    {
        selectedOptionArray =
            selectedOptionArray.filter(
                ( selectedOption ) =>
                selectedOption.value !== removedOption.value
                );

        updateSelectedOptionArray();
    }

    // ~~

    function setSelectedOptionArray(
        )
    {
        selectedOptionArray = [];

        for ( let value of valueArray )
        {
            if ( !hasSelectedValue( value ) )
            {
                let selectedOption = findOptionByValue( value );

                if ( selectedOption !== null )
                {
                    selectedOptionArray.push( selectedOption );
                }
            }
        }

        selectedOptionArray = selectedOptionArray;
        updateAvailableOptionArray();
    }

    // ~~

    function handleMultiSelectClickEvent(
        )
    {
        if ( inputElement )
        {
            inputElement.focus();
            showDropdown();
        }
    }

    // ~~

    function handleInputFocusEvent(
        )
    {
        showDropdown();
    }

    // ~~

    function handleInputInputEvent(
        )
    {
        updateAvailableOptionArray();
        updateInputWidth();
        showDropdown();
    }

    // ~~

    function handleInputKeyDownEvent( event )
    {
        if ( event.key === 'Enter' )
        {
            event.preventDefault();

            if ( !isDropdownOpen )
            {
                showDropdown();
            }
            else if ( availableOptionArray.length > 0 )
            {
                addSelectedOption( availableOptionArray[ 0 ] );
            }
        }
    }

    // -- STATEMENTS

    setSelectedOptionArray();

    onMount(
        () =>
        {
            document.addEventListener( 'click' , handleDocumentClickEvent );

            return (
                () =>
                {
                    document.removeEventListener( 'click', handleDocumentClickEvent );
                }
                );
        }
        );
</script>

<div class="multi-select" bind:this={ multiSelectElement } on:click={ handleMultiSelectClickEvent }>
    <div class="multi-select-selected-option-list">
        {#each selectedOptionArray as selectedOption ( selectedOption.value ) }
            <div class="multi-select-selected-option" on:click|stopPropagation>
                { selectedOption.label }
                <button on:click={ () => removeSelectedOption( selectedOption ) }>×</button>
            </div>
        {/each}

        <input
            type="text"
            bind:this={ inputElement }
            bind:value={ searchedText }
            class="multi-select-input"
            on:click|stopPropagation={ handleInputFocusEvent }
            on:focus|stopPropagation={ handleInputFocusEvent }
            placeholder={ placeholder }
            style="width: {inputElementWidth};"
            on:input={ handleInputInputEvent }
            on:keydown={ handleInputKeyDownEvent }
        />

        <button class="multi-select-toggle-button" on:click={ toggleDropdown } on:click|stopPropagation>
            <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="none"
                stroke="currentColor"
                stroke-width="1"
                viewBox="0 0 10 10"
            >
                <path d="M2 4l3 3 3-3" />
            </svg>
        </button>
    </div>

    <div class="multi-select-dropdown { ( isDropdownOpen && availableOptionArray.length > 0 ) ? 'is-open' : '' }" bind:this={ dropdownElement }>
        {#each availableOptionArray as availableOption ( availableOption.value ) }
            <div
                class="multi-select-available-option"
                on:mousedown={ handleInputFocusEvent }
                on:touchstart={ handleInputFocusEvent }
                on:click={ () => addSelectedOption( availableOption ) }>
                { availableOption.label }
            </div>
        {/each}
    </div>
</div>

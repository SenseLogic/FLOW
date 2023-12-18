<script>
    // -- EXPORTS

    export let value = false;
    export let onChange = () => {};

    // -- STATEMENTS

    $: checked = value;

    // -- FUNCTIONS

    function handleChange(
        event
        )
    {
        value = event.target.checked;

        onChange( value);
    }
</script>

<div class="switch-container">
    <input
        class="switch"
        type="checkbox"
        bind:checked
        on:change={ handleChange }
    />
    <span class="switch-slider"></span>
</div>

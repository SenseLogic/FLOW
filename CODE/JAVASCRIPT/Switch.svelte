<script>
    // -- EXPORTS

    export let value = false;
    export let onChange = () => {};

    // -- STATEMENTS

    $: checked = value;

    // -- FUNCTIONS

    function handleChangeEvent(
        event
        )
    {
        value = event.target.checked;

        onChange( value);
    }
</script>

<div class="switch">
    <input
        class="input"
        type="checkbox"
        bind:checked
        on:change={ handleChangeEvent }
    />
    <span class="slider"></span>
</div>

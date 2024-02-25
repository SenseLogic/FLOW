<script>
    // -- EXPORTS

    export let value = false;
    export let onChange = () => {};
    export let ariaLabel = "Switch";

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

<div class="switch" role="switch" aria-checked={ checked.toString() } aria-label="{ ariaLabel }">
    <input
        class="input"
        type="checkbox"
        bind:checked
        on:change={ handleChangeEvent }
        aria-hidden="true"
    />
    <span class="slider"></span>
</div>

<style lang="stylus">
    // -- IMPORTS

    @import '../constant.styl';
</style>

<div class="padding-100 padding-lateral-200-large">
    <h1 class="font-size-200 font-weight-700 color-red">
        Welcome to SvelteKit
    </h1>
    <p class="margin-top-100 color-green-500">
        Visit <a class="color-green-300 color-green-500-hover" href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation
    </p>

    <div class="size-200 green-map-pin-icon">
    </div>

    <div class="margin-top-100 display-flex flex-direction-column gap-100">
        <div class="display-flex gap-50">
            <span class="switch-input-container">
                <input class="switch-input" type="checkbox"/>
                <span class="switch-input-slider">
                </span>
            </span>
            <span>Switch</span>
        </div>

        <input class="input" type="text"/>

        <textarea class="text-input"></textarea>

        <select class="enumeration-input">
            <option class="enumeration-input-option">
                First option
            </option>
            <option class="enumeration-input-option">
                Second option
            </option>
            <option class="enumeration-input-option">
                Third option
            </option>
        </select>
    </div>
</div>

<script>
    //import DatePicker from 'senselogic-flow/DatePicker.svelte';
    import DatePicker from '../../../CODE/JAVASCRIPT/DatePicker.svelte';
    //import ValuePicker from 'senselogic-flow/ValuePicker.svelte';
    import ValuePicker from '../../../CODE/JAVASCRIPT/ValuePicker.svelte';
</script>

<style lang="stylus">
    // -- IMPORTS

    @import '../constant.styl';

    // -- CLASSES

    .frame
    {
        margin-top: 1rem;
        margin-bottom: 1rem;
        border: 1px solid grayColor700;
        border-radius: 0.5rem;
        padding: 0.5rem;
    }
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

    <p class="frame">
        <ValuePicker value={ 100 } valuePrecision={ 10 } valueSuffix=" €" limitArray={ [ 5, 95 ] } onChange={ ( value ) => console.log( value ) }/>
    </p>
    <p class="frame">
        <ValuePicker valueArray={ [ 0, 100 ] } valuePrecision={ 10 } valueSuffix=" €" limitArray={ [ 5, 95 ] } onChange={ ( valueArray ) => console.log( valueArray ) }/>
    </p>
    <p class="frame">
        <ValuePicker value={ 50 } valuePrecision={ 5 } valueSuffix=" €" limitArray={ [ 0, 100 ] } onChange={ ( value ) => console.log( value ) }/>
    </p>
    <p class="frame">
        <ValuePicker valueArray={ [ 0, 50 ] } valuePrecision={ 5 } valueSuffix=" €" limitArray={ [ 0, 100 ] } onChange={ ( valueArray ) => console.log( valueArray ) }/>
    </p>
    <p class="frame">
        <DatePicker dateArray={ [ null ] } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>
    <p class="frame">
        <DatePicker dateArray={ [ null, null ] } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>
    <p class="frame">
        <DatePicker dateArray={ [ null ] } monthCount={ 2 } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>
    <p class="frame">
        <DatePicker dateArray={ [ null, null ] } monthCount={ 2 } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>
    <p class="frame">
        <DatePicker dateArray={ [ null ] } monthCount={ 3 } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>
    <p class="frame">
        <DatePicker dateArray={ [ null, null ] } monthCount={ 3 } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>
</div>

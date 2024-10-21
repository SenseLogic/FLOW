<script>
    // -- IMPORTS

    //import Carousel from 'senselogic-flow/Carousel.svelte';
    import Carousel from '../../../PACKAGE/Carousel.svelte';
    //import DatePicker from 'senselogic-flow/DatePicker.svelte';
    import DatePicker from '../../../PACKAGE/DatePicker.svelte';
    //import MultiSelect from 'senselogic-flow/MultiSelect.svelte';
    import MultiSelect from '../../../PACKAGE/MultiSelect.svelte';
    //import SortableList from 'senselogic-flow/SortableList.svelte';
    import SortableList from '../../../PACKAGE/SortableList.svelte';
    //import Switch from 'senselogic-flow/Switch.svelte';
    import Switch from '../../../PACKAGE/Switch.svelte';
    //import ValuePicker from 'senselogic-flow/ValuePicker.svelte';
    import ValuePicker from '../../../PACKAGE/ValuePicker.svelte';
    import CalendarDay from '$lib/CalendarDay.svelte';

    // -- VARIABLES

    let booleanValue = true;
    let realValue = 50;
    let dateValue = new Date( Date.UTC( 2023, 11, 1 ) );    // 2023-12-1
    let firstNameArray = [ "John", "Mike", "Adam", "Noah", "Jack", "Carl", "Theo" ];
    let secondNameArray = [ "John", "Mike", "Adam", "Noah", "Jack", "Carl", "Theo" ];
    let optionArray =
        [
            { value: 'apple', label: 'Apple' },
            { value: 'apricot', label: 'Apricot' },
            { value: 'banana', label: 'Banana' },
            { value: 'blueberry', label: 'Blueberry' },
            { value: 'cherry', label: 'Cherry' },
            { value: 'grape', label: 'Grape' },
            { value: 'kiwi', label: 'Kiwi' },
            { value: 'lemon', label: 'Lemon' },
            { value: 'lime', label: 'Lime' },
            { value: 'mango', label: 'Mango' },
            { value: 'orange', label: 'Orange' },
            { value: 'papaya', label: 'Papaya' },
            { value: 'peach', label: 'Peach' },
            { value: 'pear', label: 'Pear' },
            { value: 'pineapple', label: 'Pineapple' },
            { value: 'plum', label: 'Plum' },
            { value: 'pomegranate', label: 'Pomegranate' },
            { value: 'raspberry', label: 'Raspberry' },
            { value: 'strawberry', label: 'Strawberry' },
            { value: 'watermelon', label: 'Watermelon' }
        ];

    // -- STATEMENTS

    $: console.log( booleanValue );
    $: console.log( realValue );
    $: console.log( dateValue );
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

    <p class="title">
        Title
    </p>

    <p class="title.is-subtitle">
        Subtitle
    </p>

    <p class="frame">
        <SortableList
            elementArray={ firstNameArray }
            let:element
            onChange={ ( elementArray ) => console.log( elementArray ) }
        >
            <div>
                { element }
            </div>
        </SortableList>
    </p>

    <p class="frame">
        <SortableList
            elementArray={ secondNameArray }
            let:element
            onChange={ ( elementArray ) => console.log( elementArray ) }
        >
            <div>
                { element }
            </div>
        </SortableList>
    </p>

    <div class="margin-top-100 display-flex flex-direction-column gap-100">
        <div class="display-flex gap-50">
            <Switch value={ booleanValue } onChange={ ( value ) => booleanValue = value } />
            <span>Switch</span>
        </div>

        <div class="display-flex gap-50">
            <Switch value={ false } onChange={ ( value ) => console.log( value ) } />
            <span>Switch</span>
        </div>

        <div class="display-flex gap-50">
            <Switch value={ true } onChange={ ( value ) => console.log( value ) } />
            <span>Switch</span>
        </div>

        <input class="input" type="text"/>

        <textarea class="textarea"></textarea>

        <select class="select">
            <option class="select-option">
                First option
            </option>
            <option class="select-option">
                Second option
            </option>
            <option class="select-option">
                Third option
            </option>
        </select>
    </div>

    <p class="frame">
        <ValuePicker value={ realValue } valuePrecision={ 10 } valueSuffix=" €" limitArray={ [ 5, 95 ] } onChange={ ( value ) => realValue = value }/>
    </p>

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
        <DatePicker date={ dateValue } onChange={ ( date ) => dateValue = date }/>
    </p>

    <p class="frame">
        <DatePicker date={ null } onChange={ ( date ) => console.log( date ) }/>
    </p>

    <p class="frame">
        <DatePicker dateArray={ [ null, null ] } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>

    <p class="frame">
        <DatePicker date={ null } monthCount={ 2 } onChange={ ( date ) => console.log( date ) }/>
    </p>

    <p class="frame">
        <DatePicker dateArray={ [ null, null ] } monthCount={ 2 } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>

    <p class="frame">
        <DatePicker date={ new Date( '2023-3-15' ) } monthCount={ 3 } onChange={ ( date ) => console.log( date ) }/>
    </p>

    <p class="frame">
        <DatePicker dateArray={ [ new Date( '2023-3-5' ), new Date( '2023-4-25' ) ] } monthCount={ 3 } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>

    <p class="frame">
        <DatePicker dateArray={ [ new Date( '2023-3-5' ), new Date( '2023-4-25' ) ] } monthCount={ 3 } getDayComponent={ ( day ) => CalendarDay } onChange={ ( dateArray ) => console.log( dateArray ) }/>
    </p>

    <p class="frame">
        <MultiSelect { optionArray }/>
    </p>

    <p class="frame">
        <Carousel columnCount={ 1 } hasCount hasDots hasButtons isAutomatic>
            <div class="carousel-slide">Slide 1</div>
        </Carousel>
    </p>

    <p class="frame">
        <Carousel columnCount={ 1 } hasCount hasDots hasButtons isAutomatic>
            <div class="carousel-slide">Slide 1</div>
            <div class="carousel-slide">Slide 2</div>
            <div class="carousel-slide">Slide 3</div>
        </Carousel>
    </p>

    <p class="frame">
        <Carousel columnCount={ 3 } hasCount hasDots hasButtons isAutomatic>
        </Carousel>
    </p>

    <p class="frame">
        <Carousel columnCount={ 3 } hasCount hasDots hasButtons isAutomatic>
            <div class="carousel-slide">Slide 1</div>
        </Carousel>
    </p>

    <p class="frame">
        <Carousel columnCount={ 3 } hasCount hasDots hasButtons isAutomatic>
            <div class="carousel-slide">Slide 1</div>
            <div class="carousel-slide">Slide 2</div>
        </Carousel>
    </p>

    <p class="frame">
        <Carousel columnCount={ 3 } hasCount hasDots hasButtons isAutomatic stayDuration={ 2000 } transitionDuration={ 700 } resumeDuration={ 3000 }>
            <div class="carousel-slide">Slide 1</div>
            <div class="carousel-slide">Slide 2</div>
            <div class="carousel-slide">Slide 3</div>
            <div class="carousel-slide">Slide 4</div>
            <div class="carousel-slide">Slide 5</div>
            <div class="carousel-slide">Slide 6</div>
        </Carousel>
    </p>
</div>

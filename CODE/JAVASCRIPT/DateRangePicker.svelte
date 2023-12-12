<script>
    // -- IMPORTS

    import { writable } from 'svelte/store';

    // -- EXPORTS

    export let dateArray = writable( [ null, null ] );
    export let weekdayNameArray = [ 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun' ];
    export let monthNameArray = [ 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
    export let onChange = () => {};

    // -- VARIABLES

    let monthDateArray = [ new Date(), new Date() ];
    monthDateArray[ 1 ].setMonth( monthDateArray[ 1 ].getMonth() + 1 );

    // -- FUNCTIONS

    function getWeekdayIndex(
        date
        )
    {
        return ( date.getDay() + 6 ) % 7;
    }

    // ~~

    function getDay(
        date,
        isGrayed
        )
    {
        return (
            {
                date: new Date( date ),
                text: date.getDate(),
                weekdayIndex: getWeekdayIndex( date ),
                isGrayed
            }
            );
    }

    // ~~

    function getDayArray(
        year,
        month
        )
    {
        let dayArray = [];

        let priorDate = new Date( year, month, 1 );

        let priorWeekdayIndex = getWeekdayIndex( priorDate );

        while ( priorWeekdayIndex > 0 )
        {
            priorDate.setDate( priorDate.getDate() - 1 );
            dayArray.unshift( getDay( priorDate, true ) );
            --priorWeekdayIndex;
        }

        let date = new Date( year, month, 1 );

        while ( date.getMonth() === month )
        {
            dayArray.push( getDay( date, false ) );

            date.setDate( date.getDate() + 1 );
        }

        let nextDate = date;

        let nextWeekdayIndex = getWeekdayIndex( nextDate );

        if ( nextWeekdayIndex > 0 )
        {
            while ( nextWeekdayIndex < 7)
            {
                dayArray.push( getDay( nextDate, true ) );
                nextDate.setDate( nextDate.getDate() + 1 );
                ++nextWeekdayIndex;
            }
        }

        return dayArray;
    }

    // ~~

    function selectDate(
        date,
        dateIndex
        )
    {
        dateArray.update(
            dateArray =>
            {
                dateArray[ dateIndex ] = date;

                return dateArray;
            }
            );
    }

    // ~~

    function selectDay(
        day,
        dateIndex
        )
    {
        if ( !day.isGrayed )
        {
            selectDate( day.date, dateIndex );
            onChange( dateArray );
        }
    }

    // ~~

    function setPriorMonth(
        dateIndex
        )
    {
        monthDateArray[ dateIndex ].setMonth( monthDateArray[ dateIndex ].getMonth() - 1 );
        monthDateArray = [ ...monthDateArray ];
    }

    // ~~

    function setNextMonth(
        dateIndex
        )
    {
        monthDateArray[ dateIndex ].setMonth( monthDateArray[ dateIndex ].getMonth() + 1 );
        monthDateArray = [ ...monthDateArray ];
    }

    // ~~

    function isDateInRange(
        date,
        firstDate,
        lastDate
        )
    {
        return (
            firstDate
            && lastDate
            && date >= firstDate
            && date <= lastDate
            );
    };
</script>

<style>
    .date-range-picker
    {
        display: flex;
        justify-content: center;
        align-items: center;
        font-family: 'Arial', sans-serif;
    }

    .calendar
    {
        border: 1px solid #ddd;
        padding: 0.5rem;
        margin: 0.5rem;
        border-radius: 0.5rem;
        background-color: white;
    }

    .calendar button
    {
        border: none;
        background: none;
        cursor: pointer;
    }

    .calendar button:hover
    {
        background-color: #f0f0f0;
    }

    .calendar span
    {
        font-weight: bold;
        margin: 0 0.5rem;
    }

    .month-button
    {
        background-color: transparent;
        border: none;
        cursor: pointer;
        font-size: 1rem;
    }

    .month-button:hover
    {
        color: #007bff;
    }

    .day-button
    {
        cursor: pointer;
        text-align: center;
    }

    .day-button.in-range
    {
        font-weight: bold;
        color: green;
    }

    .day-button.selected
    {
        border: 2px solid blue;
        border-radius: 50%;
    }

    .day-button.is-grayed
    {
        color: lightgray;
    }

    .calendar-header
    {
        display: flex;
        justify-content: space-between;
        gap: 0.5rem;
    }

    .calendar-grid
    {
        display: grid;
        grid-template-columns: repeat( 7, 1fr );
        gap: 0.5rem;
    }

    .weekday
    {
        text-align: center;
        font-weight: bold;
    }
</style>

<div class="date-range-picker">
    { #each monthDateArray as monthDate, dateIndex }
        <div class="calendar">
            <div class="calendar-header">
                <div class="month-button" on:click={ () => setPriorMonth( dateIndex ) }>&lt;</div>
                <div>{ monthNameArray[ monthDate.getMonth() ] } { monthDate.getFullYear() }</div>
                <div class="month-button" on:click={ () => setNextMonth( dateIndex ) }>&gt;</div>
            </div>
            <div class="calendar-grid">
                { #each weekdayNameArray as weekdayName }
                    <div class="weekday">{ weekdayName }</div>
                { /each }
                { #each getDayArray( monthDate.getFullYear(), monthDate.getMonth() ) as day }
                    <div class="day-button"
                        class:in-range={ isDateInRange( day.date, $dateArray[ 0 ], $dateArray[ 1 ] ) }
                        class:selected={ day.date.getTime() === $dateArray[ dateIndex ]?.getTime() }
                        class:is-grayed={ day.isGrayed }
                        on:click={ () => selectDay( day, dateIndex ) }
                    >
                        { day.text }
                    </div>
                { /each }
            </div>
        </div>
    {/each}
</div>

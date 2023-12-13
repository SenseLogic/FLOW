<script>
    // -- IMPORTS

    import { writable } from 'svelte/store';

    // -- EXPORTS

    export let dateArray = [ null ];
    export let weekdayNameArray = [ 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun' ];
    export let monthNameArray = [ 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
    export let onChange = () => {};

    // -- VARIABLES

    let dateCount = dateArray.length;
    let monthDateArray;

    if ( dateCount === 2 )
    {
        monthDateArray = [ new Date(), new Date() ];
        monthDateArray[ 1 ].setMonth( monthDateArray[ 1 ].getMonth() + 1 );
    }
    else
    {
        monthDateArray = [ new Date() ];
    }

    if ( dateArray[ 0 ] !== null )
    {
        monthDateArray[ 0 ] = dateArray[ 0 ];
    }

    if ( dateCount === 2
         && dateArray[ 1 ] !== null )
    {
        monthDateArray[ 1 ] = dateArray[ 1 ];
    }

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
        dateArray[ dateIndex ] = date;
        dateArray = dateArray;
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

<div class="date-picker">
    { #each monthDateArray as monthDate, dateIndex }
        <div class="calendar">
            <div class="month-grid">
                <div class="month-button" on:click={ () => setPriorMonth( dateIndex ) }>&lt;</div>
                <div>{ monthNameArray[ monthDate.getMonth() ] } { monthDate.getFullYear() }</div>
                <div class="month-button" on:click={ () => setNextMonth( dateIndex ) }>&gt;</div>
            </div>
            <div class="day-grid">
                { #each weekdayNameArray as weekdayName }
                    <div class="weekday">{ weekdayName }</div>
                { /each }
                { #each getDayArray( monthDate.getFullYear(), monthDate.getMonth() ) as day }
                    <div class="day"
                        class:in-range={ dateCount === 2 && isDateInRange( day.date, dateArray[ 0 ], dateArray[ 1 ] ) }
                        class:selected={ day.date.getTime() === dateArray[ dateIndex ]?.getTime() }
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

<script>
    // -- IMPORTS

    import { writable } from 'svelte/store';

    // -- VARIABLES

    export let date = undefined;
    export let dateArray = [ date ];
    export let dateIndex = 0;
    export let monthCount = 1;
    export let monthNameArray = [ 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
    export let weekdayNameArray = [ 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun' ];
    export let isFordiddenDate = ( date ) => false;
    export let isUnavailableDate = ( date ) => false;
    export let onChange = () => {};

    let dateCount = dateArray.length;
    let todayDate = getTimelessDate( new Date() );
    let monthDateArray;

    // -- STATEMENTS

    if ( dateCount === 1 )
    {
        date = getTimelessDate( date );
        dateArray = [ date ];
    }
    else
    {
        dateArray = [ getTimelessDate( dateArray[ 0 ] ), getTimelessDate( dateArray[ 1 ] ) ];
    }

    if ( dateArray[ 0 ] === null )
    {
        monthDateArray = [ new Date( todayDate ) ];
    }
    else
    {
        monthDateArray = [ new Date( dateArray[ 0 ] ) ];
    }

    for ( let monthIndex = 1;
          monthIndex < monthCount;
          ++monthIndex )
    {
        monthDateArray.push( getMonthDate( monthDateArray[ monthIndex - 1 ], 1 ) );
    }

    // -- FUNCTIONS

    function getTimelessDate(
        date
        )
    {
        if ( date === null )
        {
            return null;
        }
        else
        {
            return new Date( Date.UTC( date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate() ) );
        }
    }

    // ~~

    function getMonthDate(
        date,
        monthOffset
        )
    {
        if ( monthOffset === -1 )
        {
            if ( date.getUTCMonth() === 0 )
            {
                return new Date( Date.UTC( date.getUTCFullYear() - 1, 11, 1 ) );
            }
            else
            {
                return new Date( Date.UTC( date.getUTCFullYear(), date.getUTCMonth() - 1, 1 ) );
            }
        }
        else if ( monthOffset === 1 )
        {
            if ( date.getUTCMonth() === 11 )
            {
                return new Date( Date.UTC( date.getUTCFullYear() + 1, 0, 1 ) );
            }
            else
            {
                return new Date( Date.UTC( date.getUTCFullYear(), date.getUTCMonth() + 1, 1 ) );
            }
        }
        else
        {
            return new Date( date );
        }
    }

    // ~~

    function isSameDate(
        date,
        otherDate
        )
    {
        return (
            date !== null
            && otherDate !== null
            && date.getUTCDate() === otherDate.getUTCDate()
            && date.getUTCMonth() === otherDate.getUTCMonth()
            && date.getUTCFullYear() === otherDate.getUTCFullYear()
            );
    }

    // ~~

    function isTodayDate(
        date
        )
    {
        return isSameDate( date, todayDate );
    }

    // ~~

    function isFirstDate(
        date
        )
    {
        return isSameDate( date, dateArray[ 0 ] );
    }

    // ~~

    function isLastDate(
        date
        )
    {
        return isSameDate( date, dateArray[ dateCount - 1 ] );
    }

    // ~~

    function isSelectedDate(
        date
        )
    {
        return (
            isSameDate( dateArray[ 0 ], date )
            || ( dateCount === 2
                 && isSameDate( dateArray[ 1 ], date ) )
            );
    }

    // ~~

    function isInsideDate(
        date
        )
    {
        return (
            dateCount === 2
            && dateArray[ 0 ] !== null
            && dateArray[ 1 ] !== null
            && date.getTime() >= dateArray[ 0 ].getTime()
            && date.getTime() <= dateArray[ 1 ].getTime()
            );
    }

    // ~~

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
                text: date.getUTCDate(),
                weekdayIndex: getWeekdayIndex( date ),
                isGrayed,
                isForbidden: isFordiddenDate( date ),
                isUnavailable: isUnavailableDate( date ),
                isToday: isTodayDate( date ),
                isFirst: isFirstDate( date ),
                isLast: isLastDate( date ),
                isSelected: isSelectedDate( date ),
                isInside: isInsideDate( date )
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

        let priorDate = new Date( Date.UTC( year, month, 1 ) );
        let priorWeekdayIndex = getWeekdayIndex( priorDate );

        while ( priorWeekdayIndex > 0 )
        {
            priorDate.setUTCDate( priorDate.getUTCDate() - 1 );
            dayArray.unshift( getDay( priorDate, true ) );
            --priorWeekdayIndex;
        }

        let date = new Date( Date.UTC( year, month, 1 ) );

        while ( date.getUTCMonth() === month )
        {
            dayArray.push( getDay( date, false ) );

            date.setUTCDate( date.getUTCDate() + 1 );
        }

        let nextDate = new Date( date );
        let nextWeekdayIndex = getWeekdayIndex( nextDate );

        if ( nextWeekdayIndex > 0 )
        {
            while ( nextWeekdayIndex < 7 )
            {
                dayArray.push( getDay( nextDate, true ) );
                nextDate.setUTCDate( nextDate.getUTCDate() + 1 );
                ++nextWeekdayIndex;
            }
        }

        return dayArray;
    }

    // ~~

    function updateMonth(
        monthOffset
        )
    {
        monthDateArray[ 0 ] = getMonthDate( monthDateArray[ 0 ], monthOffset );

        for ( let monthIndex = 1;
              monthIndex < monthCount;
              ++monthIndex )
        {
            monthDateArray[ monthIndex ] = getMonthDate( monthDateArray[ monthIndex - 1 ], 1 );
        }

        monthDateArray = monthDateArray;
    }

    // ~~

    function selectDate(
        date
        )
    {
        dateArray[ dateIndex ] = date;

        if ( dateCount === 2
             && dateArray[ 0 ] !== null
             && dateArray[ 1 ] !== null
             && dateArray[ 0 ].getTime() > dateArray[ 1 ].getTime() )
        {
            dateArray.reverse();
        }
        else
        {
            dateIndex = dateCount - 1 - dateIndex;
        }

        dateArray = dateArray;
        monthDateArray = monthDateArray;
    }

    // ~~

    function selectDay(
        day
        )
    {
        if ( !day.isGrayed
             && !day.isForbidden
             && !day.isUnavailable )
        {
            selectDate( day.date, dateIndex );

            if ( dateCount === 1 )
            {
                date = dateArray[ 0 ];
                onChange( date );
            }
            else
            {
                onChange( dateArray );
            }
        }
    }
</script>

<div class="date-picker">
    <div class="calendar-list">
        { #each monthDateArray as monthDate, monthIndex }
            <div class="calendar">
                <div class="month-grid">
                    <div class="month-button prior-month-button" on:click={ () => updateMonth( -1 ) }>&lt;</div>
                    <div class="month-name">{ monthNameArray[ monthDate.getUTCMonth() ] } { monthDate.getUTCFullYear() }</div>
                    <div class="month-button next-month-button" on:click={ () => updateMonth( 1 ) }>&gt;</div>
                </div>
                <div class="day-grid">
                    { #each weekdayNameArray as weekdayName }
                        <div class="weekday">{ weekdayName }</div>
                    { /each }
                    { #each getDayArray( monthDate.getUTCFullYear(), monthDate.getUTCMonth() ) as day }
                        <div class="day"
                            class:is-grayed={ day.isGrayed }
                            class:is-forbidden={ day.isForbidden }
                            class:is-unavailable={ day.isUnavailable }
                            class:is-today={ day.isToday }
                            class:is-first={ day.isFirst }
                            class:is-last={ day.isLast }
                            class:is-selected={ day.isSelected }
                            class:is-inside={ day.isInside }
                            on:click={ () => selectDay( day ) }
                        >
                            { day.text }
                        </div>
                    { /each }
                </div>
            </div>
        {/each}
    </div>
</div>

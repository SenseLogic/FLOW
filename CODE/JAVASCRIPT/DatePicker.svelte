<script>
    // -- IMPORTS

    import { writable } from 'svelte/store';

    // -- EXPORTS

    export let dateArray = [ null ];
    export let dateIndex = 0;
    export let monthCount = 1;
    export let weekdayNameArray = [ 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun' ];
    export let monthNameArray = [ 'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
    export let onChange = () => {};

    // -- VARIABLES

    let dateCount = dateArray.length;
    let todayDate = new Date();
    let monthDateArray;

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

    function getMonthDate(
        date,
        monthOffset
        )
    {
        if ( monthOffset === -1 )
        {
            if ( date.getMonth() === 0 )
            {
                return new Date( date.getFullYear() - 1, 11, 1 );
            }
            else
            {
                return new Date( date.getFullYear(), date.getMonth() - 1, 1 );
            }
        }
        else if ( monthOffset === 1 )
        {
            if ( date.getMonth() === 11 )
            {
                return new Date( date.getFullYear() + 1, 0, 1 );
            }
            else
            {
                return new Date( date.getFullYear(), date.getMonth() + 1, 1 );
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
            && date.getDate() === otherDate.getDate()
            && date.getMonth() === otherDate.getMonth()
            && date.getFullYear() === otherDate.getFullYear()
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
            date.getTime() === dateArray[ 0 ]?.getTime()
            || ( dateCount === 2
                 && date.getTime() === dateArray[ 1 ]?.getTime() )
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
            && date >= dateArray[ 0 ]
            && date <= dateArray[ 1 ]
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
                text: date.getDate(),
                weekdayIndex: getWeekdayIndex( date ),
                isGrayed,
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
        if ( !day.isGrayed )
        {
            selectDate( day.date, dateIndex );
            onChange( dateArray );
        }
    }
</script>

<div class="date-picker">
    <div class="calendar-grid">
        { #each monthDateArray as monthDate, monthIndex }
            <div class="calendar">
                <div class="month-grid">
                    <div class="month-button prior-month-button" on:click={ () => updateMonth( -1 ) }>&lt;</div>
                    <div class="month">{ monthNameArray[ monthDate.getMonth() ] } { monthDate.getFullYear() }</div>
                    <div class="month-button next-month-button" on:click={ () => updateMonth( 1 ) }>&gt;</div>
                </div>
                <div class="day-grid">
                    { #each weekdayNameArray as weekdayName }
                        <div class="weekday">{ weekdayName }</div>
                    { /each }
                    { #each getDayArray( monthDate.getFullYear(), monthDate.getMonth() ) as day }
                        <div class="day"
                            class:is-grayed={ day.isGrayed }
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

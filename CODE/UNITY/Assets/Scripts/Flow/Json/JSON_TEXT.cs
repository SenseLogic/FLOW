// -- IMPORTS

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UUID = System.Guid;
using FLOW;

// -- TYPES

namespace FLOW
{
    public class JSON_TEXT
    {
        // -- ATTRIBUTES

        StringBuilder
            StringBuilder_;
        List< int >
            CountList;

        // -- CONSTRUCTORS

        public JSON_TEXT(
            )
        {
            StringBuilder_ = new StringBuilder();
            CountList = new List< int >();
        }

        // -- INQUIRIES

        public String GetText(
            )
        {
            return StringBuilder_.ToString();
        }

        // -- OPERATIONS

        public void BeginCount(
            )
        {
            CountList.Add( 0 );
        }

        // ~~

        public void EndCount(
            )
        {
            CountList.RemoveAt( CountList.Count - 1 );
        }

        // ~~

        public void BeginList(
            )
        {
            StringBuilder_.Append( '[' );
            BeginCount();
        }

        // ~~

        public void EndList(
            )
        {
            EndCount();
            StringBuilder_.Append( ']' );
        }

        // ~~

        public void BeginDictionary(
            )
        {
            StringBuilder_.Append( '{' );
            BeginCount();
        }

        // ~~

        public void EndDictionary(
            )
        {
            EndCount();
            StringBuilder_.Append( '}' );
        }

        // ~~

        public void WriteComma(
            )
        {
            int
                count;

            count = CountList[ CountList.Count - 1 ];

            if ( count > 0 )
            {
                StringBuilder_.Append( ',' );
            }

            CountList[ CountList.Count - 1 ] = count + 1;
        }

        // ~~

        public void WriteColon(
            )
        {
            StringBuilder_.Append( ':' );
        }

        // ~~

        public void WriteQuotedText(
            String text
            )
        {
            char
                character;
            int
                character_index;

            StringBuilder_.Append( '\"' );

            for ( character_index = 0;
                  character_index < text.Length;
                  ++character_index )
            {
                character = text[ character_index ];

                if ( character == '\b' )
                {
                    StringBuilder_.Append( "\\b" );
                }
                else if ( character == '\f' )
                {
                    StringBuilder_.Append( "\\f" );
                }
                else if ( character == '\n' )
                {
                    StringBuilder_.Append( "\\n" );
                }
                else if ( character == '\r' )
                {
                    StringBuilder_.Append( "\\r" );
                }
                else if ( character == '\t' )
                {
                    StringBuilder_.Append( "\\t" );
                }
                else if ( character == '\\' )
                {
                    StringBuilder_.Append( "\\\\" );
                }
                else if ( character == '"' )
                {
                    StringBuilder_.Append( "\\\"" );
                }
                else
                {
                    StringBuilder_.Append( character );
                }
            }

            StringBuilder_.Append( '\"' );
        }

        // ~~

        public void WriteValue(
            bool boolean
            )
        {
            if ( boolean )
            {
                StringBuilder_.Append( "true" );
            }
            else
            {
                StringBuilder_.Append( "false" );
            }
        }

        // ~~

        public void WriteValue(
            char character
            )
        {
            WriteQuotedText( character.ToString() );
        }

        // ~~

        public void WriteValue(
            uint natural
            )
        {
            StringBuilder_.Append( natural.ToString() );
        }

        // ~~

        public void WriteValue(
            ulong natural
            )
        {
            StringBuilder_.Append( natural.ToString() );
        }

        // ~~

        public void WriteValue(
            int integer
            )
        {
            StringBuilder_.Append( integer.ToString() );
        }

        // ~~

        public void WriteValue(
            long integer
            )
        {
            StringBuilder_.Append( integer.ToString() );
        }

        // ~~

        public void WriteValue(
            float real
            )
        {
            StringBuilder_.Append( real.ToString( "F", CultureInfo.InvariantCulture ) );
        }

        // ~~

        public void WriteValue(
            double real
            )
        {
            StringBuilder_.Append( real.ToString( "F", CultureInfo.InvariantCulture ) );
        }

        // ~~

        public void WriteValue(
            String text
            )
        {
            WriteQuotedText( text );
        }

        // ~~

        public void WriteValue(
            UUID uuid
            )
        {
            StringBuilder_.Append( '"' );
            StringBuilder_.Append( uuid.ToString() );
            StringBuilder_.Append( '"' );
        }

        // ~~

        public void WriteValue(
            DateTime date_time
            )
        {
            long
                nanosecond_count;

            nanosecond_count = ( date_time.Ticks - JSON_VALUE.EpochDateTime.Ticks ) * 100;

            StringBuilder_.Append( nanosecond_count.ToString() );
        }

        // ~~

        public void WriteValue(
            List< String > text_list
            )
        {
            BeginList();

            foreach ( var text in text_list )
            {
                WriteComma();
                WriteValue( text );
            }

            EndList();
        }

        // ~~

        public void WriteValue(
            List< UUID > uuid_list
            )
        {
            BeginList();

            foreach ( var uuid in uuid_list )
            {
                WriteComma();
                WriteValue( uuid );
            }

            EndList();
        }

        // ~~

        public void WriteValue(
            Dictionary< UUID, uint > natural_dictionary
            )
        {
            BeginDictionary();

            foreach ( var natural_entry in natural_dictionary )
            {
                WriteComma();
                WriteValue( natural_entry.Key );
                WriteColon();
                WriteValue( natural_entry.Value );
            }

            EndDictionary();
        }

        // ~~

        public void WriteValue(
            Dictionary< UUID, ulong > natural_dictionary
            )
        {
            BeginDictionary();

            foreach ( var natural_entry in natural_dictionary )
            {
                WriteComma();
                WriteValue( natural_entry.Key );
                WriteColon();
                WriteValue( natural_entry.Value );
            }

            EndDictionary();
        }

        // ~~

        public void WriteValue(
            Dictionary< UUID, int > integer_dictionary
            )
        {
            BeginDictionary();

            foreach ( var integer_entry in integer_dictionary )
            {
                WriteComma();
                WriteValue( integer_entry.Key );
                WriteColon();
                WriteValue( integer_entry.Value );
            }

            EndDictionary();
        }

        // ~~

        public void WriteValue(
            Dictionary< UUID, long > integer_dictionary
            )
        {
            BeginDictionary();

            foreach ( var integer_entry in integer_dictionary )
            {
                WriteComma();
                WriteValue( integer_entry.Key );
                WriteColon();
                WriteValue( integer_entry.Value );
            }

            EndDictionary();
        }

        // ~~

        public void WriteValue(
            Dictionary< UUID, String > string_dictionary
            )
        {
            BeginDictionary();

            foreach ( var string_entry in string_dictionary )
            {
                WriteComma();
                WriteValue( string_entry.Key );
                WriteColon();
                WriteValue( string_entry.Value );
            }

            EndDictionary();
        }

        // ~~

        public void WriteValue(
            Dictionary< long, int > integer_dictionary
            )
        {
            BeginDictionary();

            foreach ( var integer_entry in integer_dictionary )
            {
                WriteComma();
                WriteValue( integer_entry.Key );
                WriteColon();
                WriteValue( integer_entry.Value );
            }

            EndDictionary();
        }

        // ~~

        public void WriteField(
            string field_name,
            bool boolean
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( boolean );
        }

        // ~~

        public void WriteField(
            string field_name,
            char character
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( character );
        }

        // ~~

        public void WriteField(
            string field_name,
            uint natural
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( natural );
        }

        // ~~

        public void WriteField(
            string field_name,
            ulong natural
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( natural );
        }

        // ~~

        public void WriteField(
            string field_name,
            int integer
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( integer );
        }

        // ~~

        public void WriteField(
            string field_name,
            long integer
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( integer );
        }

        // ~~

        public void WriteField(
            string field_name,
            float real
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( real );
        }

        // ~~

        public void WriteField(
            string field_name,
            double real
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( real );
        }

        // ~~

        public void WriteField(
            string field_name,
            UUID uuid
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( uuid );
        }

        // ~~

        public void WriteField(
            string field_name,
            DateTime date_time
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( date_time );
        }

        // ~~

        public void WriteField(
            string field_name,
            String text
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( text );
        }

        // ~~

        public void WriteField(
            string field_name,
            List< String > text_list
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( text_list );
        }

        // ~~

        public void WriteField(
            string field_name,
            List< UUID > uuid_list
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( uuid_list );
        }

        // ~~

        public void WriteField(
            string field_name,
            Dictionary< UUID, uint > natural_dictionary
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( natural_dictionary );
        }

        // ~~

        public void WriteField(
            string field_name,
            Dictionary< UUID, ulong > natural_dictionary
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( natural_dictionary );
        }

        // ~~

        public void WriteField(
            string field_name,
            Dictionary< UUID, int > integer_dictionary
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( integer_dictionary );
        }

        // ~~

        public void WriteField(
            string field_name,
            Dictionary< UUID, long > integer_dictionary
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( integer_dictionary );
        }

        // ~~

        public void WriteField(
            string field_name,
            Dictionary< UUID, String > string_dictionary
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( string_dictionary );
        }

        // ~~

        public void WriteField(
            string field_name,
            Dictionary< long, int > integer_dictionary
            )
        {
            WriteComma();
            WriteValue( field_name );
            WriteColon();
            WriteValue( integer_dictionary );
        }
    }
}

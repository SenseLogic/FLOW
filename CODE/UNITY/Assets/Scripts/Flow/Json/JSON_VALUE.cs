// -- IMPORTS

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UUID = System.Guid;
using FLOW;

// -- TYPES

namespace FLOW
{
    public class JSON_VALUE
    {
        // -- ATTRIBUTES

        public JSON_VALUE_TYPE
            Type;
        public String
            Text;
        public List< JSON_VALUE >
            ValueList;
        public Dictionary< JSON_VALUE, JSON_VALUE >
            ValueDictionary;
        public static DateTime
            EpochDateTime = new DateTime( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );

        // -- INQUIRIES

        public void AddText(
            ref StringBuilder string_builder
            )
        {
            int
                value_index;

            if ( IsConstant() )
            {
                string_builder.Append( Text );
            }
            else if ( IsString() )
            {
                string_builder.Append( JSON.GetQuotedText( Text ) );
            }
            else if ( IsList() )
            {
                string_builder.Append( '[' );

                for ( value_index = 0;
                      value_index < ValueList.Count;
                      ++value_index )
                {
                    if ( value_index > 0 )
                    {
                        string_builder.Append( ',' );
                    }

                    ValueList[ value_index ].AddText( ref string_builder );
                }

                string_builder.Append( ']' );
            }
            else if ( IsDictionary() )
            {
                string_builder.Append( '{' );

                value_index = 0;

                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_index > 0 )
                    {
                        string_builder.Append( ',' );
                    }

                    value_entry.Key.AddText( ref string_builder );
                    string_builder.Append( ':' );
                    value_entry.Value.AddText( ref string_builder );

                    ++value_index;
                }

                string_builder.Append( '}' );
            }
        }

        // ~~

        public String GetText(
            )
        {
            StringBuilder
                string_builder;

            string_builder = new StringBuilder();

            AddText( ref string_builder );

            return string_builder.ToString();
        }

        // ~~

        public bool IsConstant(
            )
        {
            return Type == JSON_VALUE_TYPE.Constant;
        }

        // ~~

        public bool IsString(
            )
        {
            return Type == JSON_VALUE_TYPE.String;
        }

        // ~~

        public bool IsList(
            )
        {
            return Type == JSON_VALUE_TYPE.List;
        }

        // ~~

        public bool IsDictionary(
            )
        {
            return Type == JSON_VALUE_TYPE.Dictionary;
        }

        // ~~

        public bool IsValidConstant(
            )
        {
            if ( Type == JSON_VALUE_TYPE.Constant )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid constant : " + GetText() );

                return false;
            }
        }

        // ~~

        public bool IsValidString(
            )
        {
            if ( Type == JSON_VALUE_TYPE.String )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid string : " + GetText() );

                return false;
            }
        }

        // ~~

        public bool IsValidList(
            )
        {
            if ( Type == JSON_VALUE_TYPE.List )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid list : " + GetText() );

                return false;
            }
        }

        // ~~

        public bool IsValidDictionary(
            )
        {
            if ( Type == JSON_VALUE_TYPE.Dictionary )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid dictionary : " + GetText() );

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out bool boolean
            )
        {
            if ( IsValidConstant() )
            {
                if ( Text == "false" )
                {
                    boolean = false;

                    return true;
                }
                else if ( Text == "true" )
                {
                    boolean = true;

                    return true;
                }
            }

            Debug.LogWarning( "Invalid boolean : " + GetText() );

            boolean = false;

            return false;
        }

        // ~~

        public bool ReadValue(
            out char character
            )
        {
            if ( IsValidString()
                 && Text.Length == 1 )
            {
                character = Text[ 0 ];

                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid character : " + GetText() );

                character = '\0';

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out uint natural
            )
        {
            if ( IsValidConstant()
                 && UInt32.TryParse( Text, out natural ) )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid natural : " + GetText() );

                natural = 0;

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out ulong natural
            )
        {
            if ( IsValidConstant()
                 && UInt64.TryParse( Text, out natural ) )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid natural : " + GetText() );

                natural = 0;

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out int integer
            )
        {
            if ( IsValidConstant()
                 && Int32.TryParse( Text, out integer ) )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid integer : " + GetText() );

                integer = 0;

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out long integer
            )
        {
            if ( IsValidConstant()
                 && Int64.TryParse( Text, out integer ) )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid integer : " + GetText() );

                integer = 0;

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out float real
            )
        {
            if ( IsValidConstant()
                 && float.TryParse(
                        Text,
                        System.Globalization.NumberStyles.AllowDecimalPoint
                        | System.Globalization.NumberStyles.AllowExponent,
                        CultureInfo.InvariantCulture,
                        out real
                        ) )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid real : " + GetText() );

                real = 0.0f;

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out double real
            )
        {
            if ( IsValidConstant()
                 && Double.TryParse(
                        Text,
                        System.Globalization.NumberStyles.AllowDecimalPoint
                        | System.Globalization.NumberStyles.AllowExponent,
                        CultureInfo.InvariantCulture,
                        out real
                        ) )
            {
                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid real : " + GetText() );

                real = 0.0;

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out String text
            )
        {
            if ( IsValidString() )
            {
                text = Text;

                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid string : " + GetText() );

                text = "";

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out UUID uuid
            )
        {
            #if NET_4_6
                if ( IsValidString()
                     && Guid.TryParse( Text, out uuid ) )
                {
                    return true;
                }
                else
                {
                    Debug.LogWarning( "Invalid UUID : " + GetText() );

                    uuid = default( UUID );

                    return false;
                }
            #else
                if ( IsValidString() )
                {
                    uuid = new UUID( Text );
                    return true;
                }
                else
                {
                    Debug.LogWarning( "Invalid UUID : " + GetText() );

                    uuid = default( UUID );

                    return false;
                }
            #endif
        }

        // ~~

        public bool ReadValue(
            out DateTime date_time
            )
        {
            long
                nanosecond_count,
                tick_count;

            if ( ReadValue( out nanosecond_count ) )
            {
                tick_count = nanosecond_count / 100 + EpochDateTime.Ticks;

                date_time = new DateTime( tick_count, DateTimeKind.Utc );

                return true;
            }
            else
            {
                Debug.LogWarning( "Invalid date time : " + GetText() );

                date_time = new DateTime();

                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out List< String > text_list
            )
        {
            String
                text;

            text_list = new List< String >();

            if ( IsValidList() )
            {
                foreach ( var value in ValueList )
                {
                    if ( value.ReadValue( out text ) )
                    {
                        text_list.Add( text );
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out List< UUID > uuid_list
            )
        {
            UUID
                uuid;

            uuid_list = new List< UUID >();

            if ( IsValidList() )
            {
                foreach ( var value in ValueList )
                {
                    if ( value.ReadValue( out uuid ) )
                    {
                        uuid_list.Add( uuid );
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out Dictionary< UUID, uint > natural_dictionary
            )
        {
            uint
                natural;
            UUID
                uuid_key;

            natural_dictionary = new Dictionary< UUID, uint >();

            if ( IsValidDictionary() )
            {
                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_entry.Key.ReadValue( out uuid_key )
                         && value_entry.Value.ReadValue( out natural ) )
                    {
                        natural_dictionary[ uuid_key ] = natural;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out Dictionary< UUID, ulong > natural_dictionary
            )
        {
            ulong
                natural;
            UUID
                uuid_key;

            natural_dictionary = new Dictionary< UUID, ulong >();

            if ( IsValidDictionary() )
            {
                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_entry.Key.ReadValue( out uuid_key )
                         && value_entry.Value.ReadValue( out natural ) )
                    {
                        natural_dictionary[ uuid_key ] = natural;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out Dictionary< UUID, int > integer_dictionary
            )
        {
            int
                integer;
            UUID
                uuid_key;

            integer_dictionary = new Dictionary< UUID, int >();

            if ( IsValidDictionary() )
            {
                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_entry.Key.ReadValue( out uuid_key )
                         && value_entry.Value.ReadValue( out integer ) )
                    {
                        integer_dictionary[ uuid_key ] = integer;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out Dictionary< UUID, long > integer_dictionary
            )
        {
            int
                integer;
            UUID
                uuid_key;

            integer_dictionary = new Dictionary< UUID, long >();

            if ( IsValidDictionary() )
            {
                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_entry.Key.ReadValue( out uuid_key )
                         && value_entry.Value.ReadValue( out integer ) )
                    {
                        integer_dictionary[ uuid_key ] = integer;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out Dictionary< UUID, String > string_dictionary
            )
        {
            String
                string_;
            UUID
                uuid_key;

            string_dictionary = new Dictionary< UUID, String >();

            if ( IsValidDictionary() )
            {
                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_entry.Key.ReadValue( out uuid_key )
                         && value_entry.Value.ReadValue( out string_ ) )
                    {
                        string_dictionary[ uuid_key ] = string_;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool ReadValue(
            out Dictionary< long, int > integer_dictionary
            )
        {
            int
                integer;
            long
                integer_key;

            integer_dictionary = new Dictionary< long, int >();

            if ( IsValidDictionary() )
            {
                foreach ( var value_entry in ValueDictionary )
                {
                    if ( value_entry.Key.ReadValue( out integer_key )
                         && value_entry.Value.ReadValue( out integer ) )
                    {
                        integer_dictionary[ integer_key ] = integer;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // ~~

        public bool FindFieldValue(
            String field_name,
            out JSON_VALUE field_json_value
            )
        {
            foreach ( var value_entry in ValueDictionary )
            {
                if ( value_entry.Key.IsValidString()
                     && value_entry.Key.Text == field_name )
                {
                    field_json_value = value_entry.Value;

                    return true;
                }
            }

            Debug.LogWarning( "Missing field : " + field_name );

            field_json_value = null;

            return false;
        }

        // ~~

        public void ReadField(
            String field_name,
            out bool boolean
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out boolean );
            }
            else
            {
                boolean = false;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out char character
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out character );
            }
            else
            {
                character = '\0';
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out uint natural
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out natural );
            }
            else
            {
                natural = 0;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out ulong natural
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out natural );
            }
            else
            {
                natural = 0;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out int integer
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out integer );
            }
            else
            {
                integer = 0;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out long integer
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out integer );
            }
            else
            {
                integer = 0;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out float real
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out real );
            }
            else
            {
                real = 0;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out double real
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out real );
            }
            else
            {
                real = 0;
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out String text
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out text );
            }
            else
            {
                text = "";
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out UUID uuid
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out uuid );
            }
            else
            {
                uuid = default( UUID );
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out DateTime date_time
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out date_time );
            }
            else
            {
                date_time = default( DateTime );
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out List< String > text_list
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out text_list );
            }
            else
            {
                text_list = new List< String >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out List< UUID > uuid_list
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out uuid_list );
            }
            else
            {
                uuid_list = new List< UUID >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out Dictionary< UUID, uint > natural_dictionary
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out natural_dictionary );
            }
            else
            {
                natural_dictionary = new Dictionary< UUID, uint >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out Dictionary< UUID, ulong > natural_dictionary
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out natural_dictionary );
            }
            else
            {
                natural_dictionary = new Dictionary< UUID, ulong >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out Dictionary< UUID, int > integer_dictionary
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out integer_dictionary );
            }
            else
            {
                integer_dictionary = new Dictionary< UUID, int >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out Dictionary< UUID, long > integer_dictionary
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out integer_dictionary );
            }
            else
            {
                integer_dictionary = new Dictionary< UUID, long >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out Dictionary< UUID, String > string_dictionary
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out string_dictionary );
            }
            else
            {
                string_dictionary = new Dictionary< UUID, String >();
            }
        }

        // ~~

        public void ReadField(
            String field_name,
            out Dictionary< long, int > integer_dictionary
            )
        {
            JSON_VALUE
                field_json_value;

            if ( FindFieldValue( field_name, out field_json_value ) )
            {
                field_json_value.ReadValue( out integer_dictionary );
            }
            else
            {
                integer_dictionary = new Dictionary< long, int >();
            }
        }
    }
}

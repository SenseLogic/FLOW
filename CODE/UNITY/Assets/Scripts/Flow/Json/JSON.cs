// -- IMPORTS

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UUID = System.Guid;
using FLOW;

// -- TYPES

namespace FLOW
{
    public class JSON
    {
        // -- INQUIRIES

        public static String GetQuotedText(
            String text
            )
        {
            char
                character;
            int
                character_index;
            StringBuilder
                string_builder;

            string_builder = new StringBuilder();
            string_builder.Append( '\"' );

            for ( character_index = 0;
                  character_index < text.Length;
                  ++character_index )
            {
                character = text[ character_index ];

                if ( character == '\b' )
                {
                    string_builder.Append( "\\b" );
                }
                else if ( character == '\f' )
                {
                    string_builder.Append( "\\f" );
                }
                else if ( character == '\n' )
                {
                    string_builder.Append( "\\n" );
                }
                else if ( character == '\r' )
                {
                    string_builder.Append( "\\r" );
                }
                else if ( character == '\t' )
                {
                    string_builder.Append( "\\t" );
                }
                else if ( character == '\\' )
                {
                    string_builder.Append( "\\\\" );
                }
                else if ( character == '"' )
                {
                    string_builder.Append( "\\\"" );
                }
                else
                {
                    string_builder.Append( character );
                }
            }

            string_builder.Append( '\"' );

            return string_builder.ToString();
        }

        // ~~

        public static bool IsSeparatorCharacter(
            char character
            )
        {
            return
                character == '{'
                || character == '}'
                || character == '['
                || character == ']'
                || character == ':'
                || character == ',';
        }

        // ~~

        public static void DumpTokenList(
            List<JSON_TOKEN> json_token_list
            )
        {
            int
                json_token_index;
            JSON_TOKEN
                json_token;

            for ( json_token_index = 0;
                  json_token_index < json_token_list.Count;
                  ++json_token_index )
            {
                json_token = json_token_list[ json_token_index ];

                Debug.Log( "[ " + json_token_index.ToString() + " ] " + json_token.Text );
            }
        }

        // ~~

        public static List<JSON_TOKEN> GetTokenList(
            String text
            )
        {
            char
                character;
            int
                character_index;
            List<JSON_TOKEN>
                json_token_list;
            StringBuilder
                string_builder;
            JSON_TOKEN
                json_token;

            json_token_list = new List<JSON_TOKEN>();

            character_index = 0;

            while ( character_index < text.Length )
            {
                character = text[ character_index ];

                json_token = new JSON_TOKEN();

                string_builder = new StringBuilder();

                if ( IsSeparatorCharacter( character ) )
                {
                    string_builder.Append( character );
                    ++character_index;

                    json_token.Type = JSON_TOKEN_TYPE.Separator;
                }
                else if ( character == '"' )
                {
                    ++character_index;

                    json_token.Type = JSON_TOKEN_TYPE.String;

                    while ( character_index < text.Length )
                    {
                        character = text[ character_index ];

                        if ( character == '\\'
                             && character_index + 1 < text.Length )
                        {
                            if ( character == 'b' )
                            {
                                string_builder.Append( '\b' );
                            }
                            else if ( character == 'f' )
                            {
                                string_builder.Append( '\f' );
                            }
                            else if ( character == 'n' )
                            {
                                string_builder.Append( '\n' );
                            }
                            else if ( character == 'r' )
                            {
                                string_builder.Append( '\r' );
                            }
                            else if ( character == 't' )
                            {
                                string_builder.Append( '\t' );
                            }
                            else
                            {
                                string_builder.Append( text[ character_index + 1 ] );
                            }

                            character_index += 2;
                        }
                        else if ( character == '"' )
                        {
                            ++character_index;

                            break;
                        }
                        else
                        {
                            string_builder.Append( character );

                            ++character_index;
                        }
                    }
                }
                else
                {
                    string_builder.Append( character );
                    ++character_index;

                    json_token.Type = JSON_TOKEN_TYPE.Constant;

                    while ( character_index < text.Length )
                    {
                        character = text[ character_index ];

                        if ( IsSeparatorCharacter( character ) )
                        {
                            break;
                        }
                        else
                        {
                            string_builder.Append( character );

                            ++character_index;
                        }
                    }
                }

                json_token.Text = string_builder.ToString();
                json_token_list.Add( json_token );
            }

            return json_token_list;
        }

        // ~~

        public static bool GetValue(
            out JSON_VALUE json_value,
            List<JSON_TOKEN> json_token_list,
            ref int json_token_index
            )
        {
            JSON_TOKEN
                json_token;
            JSON_VALUE
                element_json_value,
                key_json_value;

            json_value = new JSON_VALUE();

            if ( json_token_index < json_token_list.Count )
            {
                json_token = json_token_list[ json_token_index ];

                if ( json_token.IsConstant() )
                {
                    json_value.Type = JSON_VALUE_TYPE.Constant;
                    json_value.Text = json_token.Text;

                    ++json_token_index;
                }
                else if ( json_token.IsString() )
                {
                    json_value.Type = JSON_VALUE_TYPE.String;
                    json_value.Text = json_token.Text;

                    ++json_token_index;
                }
                else if ( json_token.IsSeparator() )
                {
                    if ( json_token.Text == "[" )
                    {
                        json_value.Type = JSON_VALUE_TYPE.List;
                        json_value.ValueList = new List< JSON_VALUE >();

                        ++json_token_index;

                        while ( json_token_index < json_token_list.Count )
                        {
                            json_token = json_token_list[ json_token_index ];

                            if ( json_token.IsSeparator( "]" ) )
                            {
                               ++json_token_index;

                               break;
                            }
                            else if ( json_token.IsSeparator( "," ) )
                            {
                               ++json_token_index;
                            }
                            else
                            {
                                if ( GetValue( out element_json_value, json_token_list, ref json_token_index ) )
                                {
                                    json_value.ValueList.Add( element_json_value );
                                }
                                else
                                {
                                    Debug.LogWarning( "Bad list token" );

                                    return false;
                                }
                            }
                        }
                    }
                    else if ( json_token.Text == "{" )
                    {
                        json_value.Type = JSON_VALUE_TYPE.Dictionary;
                        json_value.ValueDictionary = new Dictionary< JSON_VALUE, JSON_VALUE >();

                        ++json_token_index;

                        while ( json_token_index < json_token_list.Count )
                        {
                            json_token = json_token_list[ json_token_index ];

                            if ( json_token.IsSeparator( "}" ) )
                            {
                               ++json_token_index;

                               break;
                            }
                            else if ( json_token.IsSeparator( "," ) )
                            {
                               ++json_token_index;
                            }
                            else
                            {
                                if ( GetValue( out key_json_value, json_token_list, ref json_token_index )
                                     && json_token_index < json_token_list.Count
                                     && json_token_list[ json_token_index ].IsSeparator( ":" ) )
                                {
                                    ++json_token_index;

                                    if ( GetValue( out element_json_value, json_token_list, ref json_token_index ) )
                                    {
                                        json_value.ValueDictionary[ key_json_value ] = element_json_value;
                                    }
                                    else
                                    {
                                        Debug.LogWarning( "Bad dictionary token" );

                                        return false;
                                    }
                                }
                                else
                                {
                                    Debug.LogWarning( "Bad dictionary token" );

                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning( "Bad token : " + json_token.Text );

                        return false;
                    }
                }
            }
            else
            {
                Debug.LogWarning( "Missing token" );

                return false;
            }

            return true;
        }

        // ~~

        public static bool GetValue(
            out JSON_VALUE json_value,
            String text
            )
        {
            int
                json_token_index;
            List<JSON_TOKEN>
                json_token_list;

            json_token_list = GetTokenList( text );
            json_token_index = 0;

            return GetValue( out json_value, json_token_list, ref json_token_index );
        }
    }
}

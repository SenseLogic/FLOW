// -- IMPORTS

using System;
using FLOW;

// -- TYPES

namespace FLOW
{
    public class JSON_TOKEN
    {
        // -- ATTRIBUTES

        public JSON_TOKEN_TYPE
            Type;
        public String
            Text;

        // -- INQUIRIES

        public bool IsString(
            )
        {
            return Type == JSON_TOKEN_TYPE.String;
        }

        // ~~

        public bool IsConstant(
            )
        {
            return Type == JSON_TOKEN_TYPE.Constant;
        }

        // ~~

        public bool IsSeparator(
            )
        {
            return Type == JSON_TOKEN_TYPE.Separator;
        }

        // ~~

        public bool IsSeparator(
            String separator
            )
        {
            return
                Type == JSON_TOKEN_TYPE.Separator
                && Text == separator;
        }
    }
}

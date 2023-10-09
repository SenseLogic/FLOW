// -- IMPORTS

import 'package:flutter/material.dart';

// -- FUNCTIONS

Color getShadeColor(
    Color color,
    int shade
    )
{
    if ( shade < 500 )
    {
        double ratio = 1 + ( shade - 500 ) / 500;

        return Color.fromARGB(
            color.alpha,
            ( color.red * ratio ).toInt(),
            ( color.green * ratio ).toInt(),
            ( color.blue * ratio ).toInt()
            );
    }
    else if ( shade > 500 )
    {
        double ratio = ( shade - 500 ) / 500;

        return Color.fromARGB(
            color.alpha,
            ( color.red + ( 255 - color.red ) * ratio ).toInt(),
            ( color.green + ( 255 - color.green ) * ratio ).toInt(),
            ( color.blue + ( 255 - color.blue ) * ratio ).toInt()
            );
    }
    else
    {
        return color;
    }
}

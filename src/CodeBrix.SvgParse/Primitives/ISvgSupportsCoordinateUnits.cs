using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

[Obsolete("ISvgSupportsCoordinateUnits will be removed.")]
internal interface ISvgSupportsCoordinateUnits
{
    SvgCoordinateUnits GetUnits();
}

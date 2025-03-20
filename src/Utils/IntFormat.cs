using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stakeholder.Utils;

public static class IntFormat
{
    public static string ToString(this int number, string suffix, int maxNumberWidthForPadding)
    {
        var text = $"{number}{suffix}";
        return text.PadRight(maxNumberWidthForPadding + suffix.Length);
    }
}

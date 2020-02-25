using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mirea
{
    public class TextSplitter
    {
        private static readonly IList<String> DefaultSeparators = new List<String>() {"[ ;]+"};
        private readonly IList<Regex> _separators;

        TextSplitter(IList<String> separators)
        {
            this._separators = separators
                .Select((sep) => new Regex(sep))
                .ToList();
        }

        public static TextSplitter Default => new TextSplitter(DefaultSeparators);

        public IList<String> Split(String text) => _separators.Aggregate(new List<String>() {text}, (acc, cur) =>
            acc.SelectMany((subText) => cur.Split(subText))
                .Where((word) => word.Length != 0)
                .ToList()
        );
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mirea
{
    interface ITextModifier
    {
        String Apply(String input);
    }

    public class MoveLastLetterToBeginning : ITextModifier
    {
        public String Apply(String input)
        {
            if (input.Length == 0)
            {
                return "";
            }
            return input.Last() + input.Substring(0, Math.Clamp(input.Length - 1, 0, Int32.MaxValue));
        }
    }

    public class RemoveRepeatingLetters : ITextModifier
    {
        public String Apply(String input) => input.Distinct().Aggregate("", (acc, cur) => acc + cur);
    }
}
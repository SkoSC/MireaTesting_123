using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mirea
{
    public class PrimaryTaskInteractor
    {
        private Transformer<String, String> transformer = TransformerUtils.Chain<String>(
            new MoveLastLetterToBeginning().Apply,
            new RemoveRepeatingLetters().Apply
        );

        private TextSplitter splitter = TextSplitter.Default;

        public IList<String> Apply(String text) => splitter.Split(text)
            .Select((word) => transformer.Invoke(word))
            .ToList();
    }
}
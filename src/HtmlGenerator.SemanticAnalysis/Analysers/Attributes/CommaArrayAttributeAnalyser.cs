﻿namespace HtmlGenerator.SemanticAnalysis.Analysers
{
    public class CommaArrayAttributeAnalyser : IAttributeAnalyser
    {
        public IAttributeAnalyser Analyser { get; }

        public CommaArrayAttributeAnalyser(IAttributeAnalyser analyser)
        {
            Analyser = analyser;
        }

        private static char[] s_separator = new char[] { ',' };

        public bool IsValid(string name, string value)
        {
            string[] values = value.Split(s_separator);
            foreach (string individualValue in values)
            {
                if (!Analyser.IsValid(name, individualValue))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
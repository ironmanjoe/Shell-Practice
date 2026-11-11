using System;
using System.Collections.Generic;
using System.Text;

namespace CustomShell
{
    public static class Parser
    {
        public static List<string> Tokenize(string input)
        {
            List<string> tokens = [];
            StringBuilder currentToken = new();
            bool inQuotes = false;

            foreach (char c in input)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    continue;
                }

                if (char.IsWhiteSpace(c) && !inQuotes)
                {
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                }
                else
                {
                    currentToken.Append(c);
                }
            }

            if (currentToken.Length > 0)
            {
                tokens.Add(currentToken.ToString());
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                tokens[i] = Expand(tokens[i]);
            }

            return tokens;
        }
        private static string Expand(string token)
        {
            //eliminating possible memory waste by checking if the token contains at least two '%' characters
            int percentIndex = token.IndexOf('%');
            if(percentIndex == -1 || token.IndexOf('%', percentIndex + 1) == -1)
            {
                return token;
            }

            StringBuilder? expandedToken = null; //memory saving :P

            int i = 0;
            while (i < token.Length)
            {
                if (token[i] == '%')
                {
                    int endPercentIndex = token.IndexOf('%', i + 1);

                    if (endPercentIndex != -1)
                    {
                        string name = token.Substring(i + 1, endPercentIndex - i - 1);
                        string? value = Environment.GetEnvironmentVariable(name);

                        if (value != null)
                        {
                            if(expandedToken == null)
                            {
                                expandedToken = new StringBuilder(token[..i]);
                            }

                            expandedToken.Append(value);
                            i = endPercentIndex + 1;
                            continue;
                        }
                    }
                }

                if (expandedToken != null)
                {
                    expandedToken.Append(token[i]);
                }
                i++;
            }
            
            return expandedToken != null ? expandedToken.ToString() : token;
        }

    }
}
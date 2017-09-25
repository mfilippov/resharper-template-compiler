﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CitizenMatt.ReSharper.TemplateCompiler
{
    public enum TemplateType
    {
        Live,
        Surround,
        File
    }

    public class Template
    {
        public Guid Guid;
        public TemplateType Type;
        public string Shortcut;
        public string Description;
        public string Text;
        public bool Reformat;
        public bool ShortenQualifiedReferences;
        public IDictionary<string, string> CustomProperties = new Dictionary<string, string>();
        public IList<string> Categories = new List<string>();
        public IList<Scope> Scopes = new List<Scope>(); 
        public IList<Field> Fields = new List<Field>();
        public string InputFile;
    }

    public class Scope
    {
        public Guid Guid;
        public string Type;
        public IDictionary<string, string> Parameters = new Dictionary<string, string>();

        public Scope()
        {
            Guid = Guid.NewGuid();
        }

        public override string ToString()
        {
            if (Parameters.Count > 0)
            {
                var parameters = string.Join(", ", Parameters.Select(p => $"{p.Key}={p.Value}"));
                return $"{Type}({parameters})";
            }
            return $"{Type}";
        }
    }

    public class Field
    {
        public string Name;
        public bool Editable = true;
        public string Expression;
    }
}

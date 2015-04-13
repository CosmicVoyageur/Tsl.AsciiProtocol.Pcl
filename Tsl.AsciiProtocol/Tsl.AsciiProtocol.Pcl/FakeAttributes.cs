using System;

namespace PortableAscii2
{
    // these are fake attributes, created when porting library from full .NET to PCL
    public class BrowsableAttribute : Attribute
    {
        public bool Browsable { get; private set; }

        public BrowsableAttribute(bool browsable)
        {
            Browsable = browsable;
        }
    }

    public class DescriptionAttribute : Attribute
    {
        
        public string Description { get; private set; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }

    public class CategoryAttribute : Attribute
    {
        public string Response { get; private set; }

        public CategoryAttribute(string response)
        {
            Response = response;
        }
    }
}
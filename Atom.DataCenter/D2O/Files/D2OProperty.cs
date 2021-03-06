﻿using Atom.Core.Extensions;
using Atom.DataCenter.D2O.Enums;
using Atom.IO.Interfaces;

namespace Atom.DataCenter.D2O.Files
{
   public class D2OProperty
   {
       public string PropertyName { get; }
       public D2ODataType PropertyType { get; set; }
       public D2OProperty InnerProperty { get; set; }

       public D2OProperty(IReader reader)
       {
           PropertyName = reader.ReadValue<string>().Capitalize();

           ReadType(reader);
       }

       public void ReadType(IReader reader)
       {
           var fieldType = (D2ODataType)reader.ReadValue<int>();

           if (fieldType == D2ODataType.Vector)
               InnerProperty = new D2OProperty(reader);

           PropertyType = fieldType;
        }
    }
}

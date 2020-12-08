using Shape_Como_Interface.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shape_Como_Interface.Model.Entities
{
    abstract class AbstractShape : IShape
    {

        public Color Color { get; set; }

        public abstract double Area();
    }
}

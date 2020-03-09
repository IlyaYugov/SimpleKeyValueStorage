using System;

namespace Domain
{
    public class ValueModel
    {
        public int ValuePart1 { get; set; }
        public string ValuePart2 { get; set; }
        
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
            {
                return false;
            }
            else { 
                ValueModel p = (ValueModel) obj; 
                return (ValuePart1 == p.ValuePart1) && (ValuePart2 == p.ValuePart2);
            }   
        }

        public override int GetHashCode()
        {
            return ValuePart1 ^ ValuePart2.GetHashCode();
        }
    }
}
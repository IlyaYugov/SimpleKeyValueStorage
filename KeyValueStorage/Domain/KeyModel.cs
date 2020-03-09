using System;
using System.Drawing;

namespace Domain
{
    public class KeyModel
    {
        public int KeyPart1 { get; set; }
        public string KeyPart2 { get; set; }
        
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
            {
                return false;
            }
            else { 
                KeyModel p = (KeyModel) obj; 
                return (KeyPart1 == p.KeyPart1) && (KeyPart2 == p.KeyPart2);
            }   
        }

        public override int GetHashCode()
        {
            return KeyPart1 ^ KeyPart2.GetHashCode();
        }
    }
}
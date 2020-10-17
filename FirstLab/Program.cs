using System;

namespace FirstLab
{
    
    class Program
    {
        public static void Main(String[] args)
        {
            Vector firstVector = new Vector(3),
                  secondVector = new Vector(3),
                  expected = new Vector(3);
            firstVector.ScalarProduct(secondVector);
        }
    }
}




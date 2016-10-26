using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle.info
{
    class Triangle
    {
        private double sideA { get; set; }
        private double sideB { get; set; }
        private double sideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public Triangle(string stringSideA, string stringSideB, string stringSideC)
        {
            this.sideA = Convert.ToDouble(stringSideA);
            this.sideB = Convert.ToDouble(stringSideB);
            this.sideC = Convert.ToDouble(stringSideC);
        }

        internal void updateSides(string stringSideA, string stringSideB, string stringSideC)
        {
            this.sideA = Convert.ToDouble(stringSideA);
            this.sideB = Convert.ToDouble(stringSideB);
            this.sideC = Convert.ToDouble(stringSideC);
        }

        public bool isValidTriangle()
        {
            double[] sideArray = new double[] { sideA, sideB, sideC };
            Array.Sort<double>(sideArray);

            bool returnMe = false;

            if(sideArray[0] + sideArray[1] > sideArray[2])
            {
                returnMe = true;
            }
            else
            {
                returnMe = false;
            }

            return returnMe;
        }

        
    }
}

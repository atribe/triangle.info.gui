using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle.info
{
    class Triangle
    {
        public enum TriangleState
        {
            Invalid,
            Equilateral,
            Isoscelese,
            Right,
            NotSpecial
        };

        private double sideA;
        private double sideB;
        private double sideC;

        private TriangleState triState = TriangleState.Invalid;

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

        public TriangleState getTriangleState()
        {
            if(!isValidTriangle())
            {
                triState = TriangleState.Invalid;
            }
            else if(isRightTriangle())
            {
                triState = TriangleState.Right;
            }
            else if(isEquilateral())
            {
                triState = TriangleState.Equilateral;
            }
            else if(isIsosceles())
            {
                triState = TriangleState.Isoscelese;
            }
            else
            {
                triState = TriangleState.NotSpecial;
            }

            return triState;
        }

        private bool isValidTriangle()
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

        private bool isRightTriangle()
        {
            double[] sideArray = new double[] { sideA, sideB, sideC };
            Array.Sort<double>(sideArray);

            bool returnMe = false;

            if (sideArray[0]* sideArray[0] + sideArray[1]* sideArray[1] == sideArray[2]* sideArray[2])
            {
                returnMe = true;
            }
            else
            {
                returnMe = false;
            }

            return returnMe;
        }

        private bool isEquilateral()
        {
            bool returnMe;

            if(sideA == sideB && sideA == sideC)
            {
                returnMe = true;
            }
            else
            {
                returnMe = false;
            }

            return returnMe;
        }

        private bool isIsosceles()
        {
            bool returnMe;

            if (sideA == sideB || sideA == sideC || sideB == sideC)
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

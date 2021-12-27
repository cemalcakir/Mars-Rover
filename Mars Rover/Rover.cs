using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class Rover
    {
        private int LocationX;
        private int LocationY;
        private char Direction;
        private Plateau Plateau;

        public Rover(int x, int y, char direction, Plateau plateau)
        {
            LocationX = x;
            LocationY = y;
            Direction = direction;
            Plateau = plateau;
        }

        public void Move(List<char> MovementInput)
        {
            foreach (char c in MovementInput)
            {
                switch (c)
                {
                    case 'r': ChangeDirectionToRight(); break;
                    case 'l': ChangeDirectionToLeft(); break;
                    case 'm': MoveOneTile(); break;
                }
            }
        }

        private void ChangeDirectionToRight()
        {
            switch (Direction)
            {
                case ('n') : Direction = 'e'; break;
                case ('e') : Direction = 's'; break;
                case ('s') : Direction = 'w'; break;
                case ('w') : Direction = 'n'; break;
                default : break;
            }
        }

        private void ChangeDirectionToLeft()
        {
            switch (Direction)
            {
                case ('n'): Direction = 'w'; break;
                case ('w'): Direction = 's'; break;
                case ('s'): Direction = 'e'; break;
                case ('e'): Direction = 'n'; break;
                default: break;
            }
        }

        private void MoveOneTile()
        {
            switch (Direction)
            {
                case ('n'): 
                    if (LocationX < Plateau.BorderX) LocationX += 1; 
                    break;
                case ('s'):
                    if( LocationX > 0) LocationX -= 1; 
                    break;
                case ('w'):
                    if (LocationY > 0) LocationY -= 1; 
                    break;
                case ('e'):
                    if (LocationY < Plateau.BorderY) LocationY += 1; 
                    break;
            }
        }

        public override string ToString()
        {
            return $"{LocationX} {LocationY} {Direction}";
        }
    }
}

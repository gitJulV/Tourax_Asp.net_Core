using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourax.Models
{
    public class SimulatorModel
    {
        public BobineModel Bobine { get; set; }
        public CableModel Cable { get; set; }

        public double NbDeSpires()
        {
            return Bobine.LargeurInt / Cable.Diametre;
        }

        public double NbDeCouches()
        {
            return (Bobine.DiametreExt - Bobine.DiametreInt) / 2 / Cable.Diametre;
        }

        public double LongParCouche(int i = 1)
        {
            return Math.Round(Math.Sqrt(Math.Pow(Cable.Diametre, 2) + Math.Pow(Math.PI * (Bobine.DiametreInt + Cable.Diametre * (i - 1)), 2)) * NbDeSpires(), 2);
        }

        public double LongTotal(double coef = 1)
        {
            double LongTotal = 0;
            for (int i = 1; i <= NbDeCouches(); i++)
            {
                LongTotal += LongParCouche(i);
            }
            return Math.Round((LongTotal / 1000) * coef, 2);
        }

        public double PoidsNet()
        {
            return Math.Round((LongTotal() * Cable.PoidsCable) / 100, 2);
        }

        public double PoidsBrut()
        {
            return PoidsNet() + Bobine.PoidsAVide;
        }

        public double NbDeBobine()
        {
            return Math.Ceiling(PoidsBrut() / Bobine.PoidsMaxAutorise);
        }
    }
}

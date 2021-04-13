using Reisefradragtjeneste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reisefradragtjeneste.Services
{
    public class Reisefradrag : IReisefradrag
    {
        private const int Egenandel = 22000;
        private const int BomFergeGrense = 3400;
        private const int MaxKm = 75000;
        private const int StandardKmGrense = 50000;
        private const double StandardKmPris = 1.5;
        private const double OverstegetKmPris = 0.7;

        public ReisefradagBelop BeregnReisefradrag(ReiseInfo reiseInfo)
        {
            double km = BeregnTotalKm(reiseInfo.Arbeidsreise, reiseInfo.Besoksreise);
            double reisefradrag = BeregnReisefradragBelop(km, reiseInfo.UtgifterBomFergeEtc);

            return new ReisefradagBelop { Reisefradrag = reisefradrag };
        }

        private double BeregnTotalKm(Reise[] arbeidsreise, Reise[] besoksreise)
        {
            double km = 0;

            foreach (var reise in arbeidsreise)
            {
                km += reise.Km * reise.Antall;
            }

            foreach (var reise in besoksreise)
            {
                km += reise.Km * reise.Antall;
            }

            return km;
        }

        private double BeregnReisefradragBelop(double km, double utgifterBomFergeEtc)
        {
            double sum = 0;
            if (km > StandardKmGrense)
            {
                double overstegetKm = km > MaxKm ? MaxKm - StandardKmGrense : km - StandardKmGrense;
                sum += overstegetKm * OverstegetKmPris;
                sum += StandardKmGrense * StandardKmPris;
            }
            else
            {
                sum = km * StandardKmPris;
            }

            if (utgifterBomFergeEtc > BomFergeGrense)
            {
                sum += utgifterBomFergeEtc;
            }

            sum -= Egenandel;

            return sum > 0 ? sum : 0;
        }
    }
}

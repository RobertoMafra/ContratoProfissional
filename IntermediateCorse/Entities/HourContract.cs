using System;

namespace IntermediateCorse.Entities
{
    class HourContract
    {
        //Atributos
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        //Construtores
        public HourContract()
        {

        }

        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        //Metodos
        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
    }
}

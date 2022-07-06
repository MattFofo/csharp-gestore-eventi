using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        private string title;

        private DateTime date;

        private uint maxNumberOfSeat;

        private uint numberOfSeatsReserved;

        public Event(string title, DateTime date, uint maxNumberOfSeat, uint numberOfSeatsReserved = 0)
        {
            if (title == "")
            {
                Console.WriteLine("il titolo non puo essere vuoto, inseriscilo");
                string newTitle = Console.ReadLine();
                this.title = newTitle;
            } else
            {
                this.title = title;

            }
            this.date = date;
            this.maxNumberOfSeat = maxNumberOfSeat;
            this.numberOfSeatsReserved = numberOfSeatsReserved;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string title)
        {
            if (title == "")
            {
                Console.WriteLine("Il titolo non può essere vuoto");
            } else
            {
                this.title = title;
            }
        }

        public DateTime GetDate()
        {
            return this.date;
        }

        public void SetDate()
        {

            Console.WriteLine("inserisci la data in formato dd/MM/yyyy");
            string date = Console.ReadLine();

            try
            {
                DateTime formattedDate = Convert.ToDateTime(date);
                this.date = formattedDate;
            }
            catch (Exception)
            {

                Console.WriteLine("Data non valida");
            }
            
        }

        public uint GetMaxNumberOfSeat()
        {
            return this.maxNumberOfSeat;
        }


        public void SetMaxNumberOfSeat()
        {
            Console.WriteLine("Inserisci numero di posti");
            uint nSeats = uint.Parse(Console.ReadLine());
            try
            {
                this.maxNumberOfSeat -= nSeats;
            }
            catch (Exception)
            {

                Console.WriteLine("Numero errato");
                this.SetMaxNumberOfSeat();
            }
            
        }





        public string ToString(DateTime date)
        {
            string formattedDate = date.ToString("dd/MM/yyyy");

            return formattedDate + " - "  + this.title;
        }

        public void Booking(uint seats)
        {
            
            try
            {
                uint SeatsLeft = this.maxNumberOfSeat - this.numberOfSeatsReserved;

                this.numberOfSeatsReserved += seats;
            }
            catch (Exception)
            {
                Console.WriteLine("posti esauriti");
            }
        }

        public void CancelBooking(uint seats)
        {
            try
            {
                this.numberOfSeatsReserved -= seats;
            }
            catch (Exception)
            {

                Console.WriteLine("Non ci sono posti da eliminare");
            }
        }
    }
}

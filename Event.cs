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

        private int maxNumberOfSeat;

        private int numberOfSeatsReserved;

        public Event(string title, DateTime date, int maxNumberOfSeat, int numberOfSeatsReserved = 0)
        {

            if (title == "")

            {
                while (title == "")
                {
                    Console.WriteLine("il titolo non puo essere vuoto, inseriscilo");
                    string newTitle = Console.ReadLine();
                    title = newTitle;
                    this.title = title;

                }

            } else
            {
                this.title = title;

            }

            if (date < DateTime.Now)
            {
                while (date < DateTime.Now)
                {
                    Console.WriteLine("La data {0} non è valida", date);
                    Console.WriteLine("inserisci la data in formato dd/MM/yyyy");
                    string newDate = Console.ReadLine();
                    DateTime formattedDate = Convert.ToDateTime(newDate);
                    date = formattedDate;
                    this.date = date;

                }

            } else
            {

                this.date = date;
            }
            try
            {
                if (maxNumberOfSeat == 0)
                {
                    while (maxNumberOfSeat == 0)
                    {
                        Console.WriteLine("il numero dei posti non può essere 0");
                        Console.WriteLine("inserisci il numero di posti");
                        int NewMaxNumberOfSeat = int.Parse(Console.ReadLine());
                        maxNumberOfSeat = NewMaxNumberOfSeat;
                        this.maxNumberOfSeat = maxNumberOfSeat;
                    }
                } else
                {
                    this.maxNumberOfSeat = maxNumberOfSeat;
                }

            } catch
            {
                Console.WriteLine("Numero errato");
                this.SetMaxNumberOfSeat();
            }

            
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

        public int GetMaxNumberOfSeat()
        {
            return this.maxNumberOfSeat;
        }


        public void SetMaxNumberOfSeat()
        {
            Console.WriteLine("Inserisci numero di posti");
            int nSeats = int.Parse(Console.ReadLine());
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


        public int GetNumberOfSeatsReserved()
        {
            return this.numberOfSeatsReserved;
        }



        public string ToString(DateTime date)
        {
            string formattedDate = date.ToString("dd/MM/yyyy");

            return formattedDate + " - "  + this.title;
        }

        public void Booking(int seats)
        {
            
            try
            {
                int SeatsLeft = this.maxNumberOfSeat - seats;

                this.numberOfSeatsReserved += seats;
            }
            catch (Exception)
            {
                Console.WriteLine("posti esauriti");
            }
        }

        public void CancelBooking(int seats)
        {
            int reserved = this.numberOfSeatsReserved; 

            if ((reserved -= seats) <= 0)
            {

                Console.WriteLine("Si possono disdire al massimo {0} prenotazioni", this.numberOfSeatsReserved);
   
            } else
            {

                try
                {
                    this.numberOfSeatsReserved -= seats;
                }
                catch (Exception)
                {

                    Console.WriteLine("valore errato");
                }
            }
        }
    }
}

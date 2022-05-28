using Airlines.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines
{
    internal class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            var mauAirline = context.Airlines.Add(new Airline()
            {
                Name = "MAU"
            });
            var britishAirline = context.Airlines.Add(new Airline()
            {
                Name = "British airlines"
            });

            context.SaveChanges();

            var boryspilAirport = context.Airports.Add(new Airport()
            {
                Name = "Boryspil airport"
            });

            var britishAirport = context.Airports.Add(new Airport()
            {
                Name = "British airport"
            });

            context.SaveChanges();

            mauAirline.Airports.Add(boryspilAirport);
            britishAirline.Airports.Add(britishAirport);

            context.SaveChanges();

            #region MAU

            var plane1 = context.Planes.Add(new Plane()
            {
                Model = "Airbus A220",
                PlacesCount = 160
            });
            var plane2 = context.Planes.Add(new Plane()
            {
                Model = "Airbus A320",
                PlacesCount = 230
            });
            var plane3 = context.Planes.Add(new Plane()
            {
                Model = "Boeing 777",
                PlacesCount = 368
            });
            var plane4 = context.Planes.Add(new Plane()
            {
                Model = "Airbus A350",
                PlacesCount = 285
            });
            var plane5 = context.Planes.Add(new Plane()
            {
                Model = "Boeing 747",
                PlacesCount = 366
            });

            context.SaveChanges();

            var flight1 = context.Flights.Add(new Flight()
            {
                Number = "GC5433",
                Plane = plane1,
                StartTown = "Hong Kong",
                DestinationTown = "Oslo",
                Date = DateTime.Now.AddDays(4),
            });

            var flight2 = context.Flights.Add(new Flight()
            {
                Number = "BD9032",
                Plane = plane2,
                StartTown = "Sydney",
                DestinationTown = "Berlin",
                Date = DateTime.Now.AddDays(10),
            });

            var flight3 = context.Flights.Add(new Flight()
            {
                Number = "FB5610",
                Plane = plane2,
                StartTown = "Paris",
                DestinationTown = "Kyiv",
                Date = DateTime.Now.AddDays(7),
            });

            var flight4 = context.Flights.Add(new Flight()
            {
                Number = "EN4276",
                Plane = plane4,
                StartTown = "Rome",
                DestinationTown = "Vienna",
                Date = DateTime.Now.AddDays(5),
            });

            var flight5 = context.Flights.Add(new Flight()
            {
                Number = "LY4488",
                Plane = plane4,
                StartTown = "Tokyo",
                DestinationTown = "Madrid",
                Date = DateTime.Now.AddDays(2),
            });

            context.SaveChanges();

            var delay1 = context.Delays.Add(new Delay()
            {
                Flight = flight3,
                DelayReason = "Погані погодні умови",
                DelayTime = new TimeSpan(4,20,0)
            });
            context.SaveChanges();

            flight3.Delay = delay1;

            context.SaveChanges();

            var ticket0 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight1,
                Price = 130
            });

            var ticket1 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight1,
                Price = 90
            });

            var ticket2 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight1,
                Price = 285
            });

            var ticket3 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight2,
                Price = 310
            });

            var ticket4 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight2,
                Price = 140
            });

            var ticket5 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight3,
                Price = 185
            });

            var ticket6 = context.BusinessTickets.Add(new BusinessTicket()
            {
                Flight = flight3,
                Price = 320,
                HasOwnBedroom = true
            });

            var ticket7 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight3,
                Price = 120
            });

            var ticket8 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight4,
                Price = 160
            });

            var ticket9 = context.BusinessTickets.Add(new BusinessTicket()
            {
                Flight = flight4,
                Price = 320,
                HasOwnBedroom = true
            });

            var ticket10 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight5,
                Price = 135
            });

            context.SaveChanges();

            flight1.Tickets.Add(ticket0);
            flight1.Tickets.Add(ticket1);
            flight1.Tickets.Add(ticket2);

            flight2.Tickets.Add(ticket3);
            flight2.Tickets.Add(ticket4);

            flight3.Tickets.Add(ticket5);
            flight3.Tickets.Add(ticket6);
            flight3.Tickets.Add(ticket7);

            flight4.Tickets.Add(ticket8);
            flight4.Tickets.Add(ticket9);

            flight5.Tickets.Add(ticket10);

            context.SaveChanges();

            boryspilAirport.Flights.Add(flight1);
            boryspilAirport.Flights.Add(flight2);
            boryspilAirport.Flights.Add(flight3);
            boryspilAirport.Flights.Add(flight4);
            boryspilAirport.Flights.Add(flight5);

            boryspilAirport.Tickets.Add(ticket1);
            boryspilAirport.Tickets.Add(ticket2);
            boryspilAirport.Tickets.Add(ticket3);
            boryspilAirport.Tickets.Add(ticket4);
            boryspilAirport.Tickets.Add(ticket6);
            boryspilAirport.Tickets.Add(ticket7);
            boryspilAirport.Tickets.Add(ticket8);
            boryspilAirport.Tickets.Add(ticket9);
            boryspilAirport.Tickets.Add(ticket10);

            boryspilAirport.Planes.Add(plane1);
            boryspilAirport.Planes.Add(plane2);
            boryspilAirport.Planes.Add(plane3);
            boryspilAirport.Planes.Add(plane4);
            boryspilAirport.Planes.Add(plane5);

            context.SaveChanges();

            #endregion

            #region BritishAirlines
            var plane6 = context.Planes.Add(new Plane()
            {
                Model = "Antonov An-148",
                PlacesCount = 80
            });
            var plane7 = context.Planes.Add(new Plane()
            {
                Model = "Comac ARJ21",
                PlacesCount = 90
            });
            var plane8 = context.Planes.Add(new Plane()
            {
                Model = "Embraer E-Jet",
                PlacesCount = 124
            });
            var plane9 = context.Planes.Add(new Plane()
            {
                Model = "Tupolev Tu-204 A220",
                PlacesCount = 210
            });
            var plane10 = context.Planes.Add(new Plane()
            {
                Model = "Mitsubishi SpaceJet",
                PlacesCount = 96
            });

            context.SaveChanges();

            var flight10 = context.Flights.Add(new Flight()
            {
                Number = "DF2753",
                Plane = plane10,
                StartTown = "New York",
                DestinationTown = "London",
                Date = DateTime.Now.AddDays(7),
            });

            var flight6 = context.Flights.Add(new Flight()
            {
                Number = "LN3211",
                Plane = plane6,
                StartTown = "Frankfurt",
                DestinationTown = "Las Vegas",
                Date = DateTime.Now.AddDays(2),
            });

            var flight7 = context.Flights.Add(new Flight()
            {
                Number = "GT4638",
                Plane = plane7,
                StartTown = "Toronto",
                DestinationTown = "Bangkok",
                Date = DateTime.Now.AddDays(5),
            });

            var flight8 = context.Flights.Add(new Flight()
            {
                Number = "KV3323",
                Plane = plane8,
                StartTown = "Washington",
                DestinationTown = "Dallas",
                Date = DateTime.Now.AddDays(2),
            });

            var flight9 = context.Flights.Add(new Flight()
            {
                Number = "LV2317",
                Plane = plane9,
                StartTown = "London",
                DestinationTown = "Glasgow",
                Date = DateTime.Now.AddDays(8),
            });

            context.SaveChanges();

            var delay2 = context.Delays.Add(new Delay()
            {
                Flight = flight7,
                DelayReason = "Заміна двигуна",
                DelayTime = new TimeSpan(9, 10, 0)
            });
            context.SaveChanges();

            flight7.Delay = delay2;

            context.SaveChanges();

            var ticket11 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight6,
                Price = 130
            });

            var ticket12 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight6,
                Price = 90
            });

            var ticket13 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight6,
                Price = 285
            });

            var ticket14 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight7,
                Price = 310
            });

            var ticket15 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight7,
                Price = 140
            });

            var ticket16 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight7,
                Price = 185
            });

            var ticket17 = context.BusinessTickets.Add(new BusinessTicket()
            {
                Flight = flight8,
                Price = 320,
                HasOwnBedroom = true
            });

            var ticket18 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight9,
                Price = 120
            });

            var ticket19 = context.StandartTickets.Add(new StandartTicket()
            {
                Flight = flight9,
                Price = 130
            });

            var ticket20 = context.BusinessTickets.Add(new BusinessTicket()
            {
                Flight = flight10,
                Price = 300,
                HasOwnBedroom = true
            });

            context.SaveChanges();

            britishAirport.Flights.Add(flight6);
            britishAirport.Flights.Add(flight7);
            britishAirport.Flights.Add(flight8);
            britishAirport.Flights.Add(flight9);
            britishAirport.Flights.Add(flight10);

            britishAirport.Tickets.Add(ticket11);
            britishAirport.Tickets.Add(ticket12);
            britishAirport.Tickets.Add(ticket13);
            britishAirport.Tickets.Add(ticket14);
            britishAirport.Tickets.Add(ticket15);
            britishAirport.Tickets.Add(ticket16);
            britishAirport.Tickets.Add(ticket17);
            britishAirport.Tickets.Add(ticket18);
            britishAirport.Tickets.Add(ticket19);
            britishAirport.Tickets.Add(ticket20);

            britishAirport.Planes.Add(plane6);
            britishAirport.Planes.Add(plane7);
            britishAirport.Planes.Add(plane8);
            britishAirport.Planes.Add(plane9);
            britishAirport.Planes.Add(plane10);

            context.SaveChanges();
            #endregion
        }
    }
}

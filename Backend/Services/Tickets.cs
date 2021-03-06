using BookMyShow.Models;
using PetaPoco;
using PetaPoco.Providers;
using System.Web.Mvc;

namespace BookMyShow.Services
{
    public class Tickets : ITickets
    {
        private readonly IDatabase db;
        public Tickets()
        {
            db = new DataBaseService.Database().getDb();
        }

        /// <summary>
        /// get the no of tickets for the movie and respective show
        /// </summary>
        /// <param name="movieId">movie id</param>
        /// <param name="TheaterId"> theater id</param>
        /// <param name="ShowId"> show id</param>
        /// <returns> no of tickets</returns>
        public IEnumerable<int> GetTickets(int movieId, int TheaterId, int ShowId)
        {
            var a = db.Query<int>("select tickets from shows where theaterID = @0 and movieID=@1 and showID =@2 and isdeleted=0", TheaterId, movieId, ShowId);
            return a;
        }

        /// <summary>
        /// deducts the no of tickets booked
        /// </summary>
        /// <param name="movieId">movie id</param>
        /// <param name="TheaterId">theater id</param>
        /// <param name="showId">show id</param>
        /// <param name="tickets">no of tickets</param>
        /// <returns></returns>
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets)
        {
            db.Update<Show>("SET tickets = tickets-@0 WHERE movieID=@1 and theaterID=@2 and showID=@3", tickets, movieId, TheaterId, showId);

            return null;
        }
    }
}

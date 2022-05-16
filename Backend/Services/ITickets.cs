using System.Web.Mvc;

namespace BookMyShow.Services
{
    public interface ITickets
    {
        public IEnumerable<int> GetTickets(int movieId, int TheaterId, int ShowId);
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets);
    }
}

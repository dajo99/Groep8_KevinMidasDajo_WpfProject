using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public static class DatabaseOperations
    {
        public static List<Event> GetEvents()
        {
            using (var entities = new ArtminEntities())
            {
                return entities.Events
                            .OrderByDescending(e => e.Date)
                            .Include(e => e.EventType)
                            .ToList();
            }
        }

        public static List<Artist> GetArtists(Event e)
        {
            using (var entities = new ArtminEntities())
            {
                return entities.Artists
                    .Where(x => x.EventID == e.EventID)
                    .ToList();
            }
        }

        public static int DeleteArtist(Artist a)
        {
            try
            {
                using (ArtminEntities entities = new ArtminEntities())
                {
                    entities.Entry(a).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
    }
}

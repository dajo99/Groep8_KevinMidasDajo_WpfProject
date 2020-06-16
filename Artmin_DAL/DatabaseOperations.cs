﻿using System;
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
    }
}

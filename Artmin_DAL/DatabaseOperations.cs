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

        public static int DeleteEvent(Event e)
        {
            try
            {
                using (var entities = new ArtminEntities())
                {
                    entities.Entry(e).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        //AUTHOR Kevin
        public static List<Artist> GetArtists(Event e)
        {
            using (var entities = new ArtminEntities())
            {
                return entities.Artists
                    .Where(x => x.EventID == e.EventID)
                    .ToList();
            }
        }

        //AUTHOR Kevin
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

        //AUTHOR Kevin
        public static int UpdateArtist(Artist a)
        {
            try
            {
                using (ArtminEntities entities = new ArtminEntities())
                {
                    entities.Entry(a).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        //AUTHOR Kevin
        public static int AddArtist(Artist a)
        {
            try
            {
                using (ArtminEntities entities = new ArtminEntities())
                {
                    entities.Artists.Add(a);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static List<Note> GetNotes(int id)
        {
            using (var entities = new ArtminEntities())
            {
                return entities.Notes
                            .OrderBy(e => e.NoteID)
                            .Include(e => e.Event)
                            .Where(e => e.Event.EventID == id)
                            .ToList();
            }
        }

        public static int DeleteNote(Note n)
        {
            try
            {
                using (ArtminEntities entities = new ArtminEntities())
                {
                    entities.Entry(n).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;

            }
        }

        public static int AanpassenNote(Note n)
        {
            try
            {
                using (ArtminEntities entities = new ArtminEntities())
                {
                    entities.Entry(n).State = EntityState.Modified;
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

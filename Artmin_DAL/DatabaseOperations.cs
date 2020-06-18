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
        //AUTHOR Midas
        public static int CountNotes(Event e)
        {
            using (var entities = new ArtminEntities())
            {
                return entities.Notes.Where(n => n.EventID == e.EventID).Count();
            }
        }

        //AUTHOR Midas
        public static int CountArtists(Event e)
        {
            using (var entities = new ArtminEntities())
            {
                return entities.Artists.Where(a => a.EventID == e.EventID).Count();
            }
        }

        //AUTHOR Midas
        public static List<EventType> GetEventTypes()
        {
            using (var entities = new ArtminEntities())
            {
                return entities.EventTypes
                            .OrderBy(e => e.Name)
                            .ToList();
            }
        }

        //AUTHOR Midas
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

        //AUTHOR Midas
        public static int AddEvent(Event e)
        {
            try
            {
                using (var entities = new ArtminEntities())
                {
                    entities.Events.Add(e);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        //AUTHOR Midas
        public static int UpdateEvent(Event e)
        {
            //try
            {
                using (var entities = new ArtminEntities())
                {
                    entities.Entry(e).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
            }
            //catch (Exception ex)
            //{
            //    FileOperations.Foutloggen(ex);
            //    return 0;
            //}
        }

        //AUTHOR Midas
        public static int DeleteEvent(Event e)
        {
            try
            {
                using (var entities = new ArtminEntities())
                {
                    entities.Entry(e).State = EntityState.Deleted;

                    entities.Notes.RemoveRange(entities.Notes.Where(n => n.EventID == e.EventID));
                    entities.Artists.RemoveRange(entities.Artists.Where(a => a.EventID == e.EventID));

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

        //AUTHOR Dajo Vandoninck
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

        //AUTHOR Dajo Vandoninck
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

        //AUTHOR Dajo Vandoninck
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

        //AUTHOR Dajo Vandoninck
        public static int AddNote(Note n)
        {
            try
            {
                using (ArtminEntities entities = new ArtminEntities())
                {
                    entities.Notes.Add(n);
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

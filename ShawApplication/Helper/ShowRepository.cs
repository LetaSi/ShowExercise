using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ShawApplication.API.Models
{
    public class ShowRepository : IShowRepository
    {
        static ConcurrentDictionary<int, Show> _shows = new ConcurrentDictionary<int, Show>();

        public ShowRepository()
        {
            // set default testing data 
            DefaultShows();
        }

        #region Methods
        public void DefaultShows()
        {

            #region prepare testing default show data
            Show item1 = new Show
            {
                Id = 1,
                Name = "16x9",
                Description = "",
                ImageUrl = "http://media.globaltv.com/uploadedimages/pages/shows/16x9/16x9_smartforms/16x9-tv-show-resized.jpg",
                ImageLink = "http://globalnews.ca/national/program/16x9",
                VisitShowPageUrl = "http://globalnews.ca/national/program/16x9",
                WatchVideoUrl = ""
            };
            _shows[item1.Id] = item1;

            Show item2 = new Show
            {
                Id = 2,
                Name = "Angel from Hell",
                Description = "",
                ImageUrl = "http://media.globaltv.com/uploadedimages/pages/shows/angel_from_hell/angel_from_hell_-_show_smartforms/angel from hell thumbnail.jpg",
                ImageLink = "http://www.globaltv.com/angelfromhell/",
                VisitShowPageUrl = "http://www.globaltv.com/angelfromhell/",
                WatchVideoUrl = "http://www.globaltv.com/angelfromhell/video/"
            };
            _shows[item2.Id] = item2;

            Show item3 = new Show
            {
                Id = 3,
                Name = "Big Brother",
                Description = "",
                ImageUrl = "http://media.globaltv.com/uploadedimages/pages/shows/big_brother/big_brother_smartforms/big-brother-tv-show.jpg",
                ImageLink = "https://bigbrothercanada.globaltv.com/",
                VisitShowPageUrl = "https://bigbrothercanada.globaltv.com/",
                WatchVideoUrl = ""
            };
            _shows[item3.Id] = item3;

            Show item4 = new Show
            {
                Id = 4,
                Name = "Big Brother Canada",
                Description = "",
                ImageUrl = "http://media.globaltv.com/uploadedimages/pages/shows/big_brother_canada/big_brother_canada_smartforms/big-brother-canada-tv-show(1).jpg",
                ImageLink = "http://www.bigbrothercanada.ca/",
                VisitShowPageUrl = "http://www.bigbrothercanada.ca/",
                WatchVideoUrl = ""
            };
            _shows[item4.Id] = item4;

            Show item5 = new Show
            {
                Id = 5,
                Name = "The Blacklist",
                Description = "",
                ImageUrl = "http://media.globaltv.com/uploadedimages/pages/shows/the_blacklist/the_blacklist_smartform/the-blackist-thumbnail.jpg",
                ImageLink = "http://www.globaltv.com/theblacklist/",
                VisitShowPageUrl = "http://www.globaltv.com/theblacklist/",
                WatchVideoUrl = "http://www.globaltv.com/theblacklist/video/"
            };
            _shows[item5.Id] = item5;
            #endregion
        }
        
        public IEnumerable<Show> GetAll()
        {
            return _shows.Values;
        }

        public void Add(Show item)
        {
            item.Id = _shows.Count + 1;
            _shows[item.Id] = item;
        }

        public Show Find(int key)
        {
            Show item;
            _shows.TryGetValue(key, out item);
            return item;
        }

        public Show Remove(int key)
        {
            Show item;
            _shows.TryGetValue(key, out item);
            _shows.TryRemove(key, out item);
            return item;
        }

        public void Update(Show item)
        {
            _shows[item.Id] = item;
        }
        #endregion

    }
}


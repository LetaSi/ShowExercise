using System;

namespace ShawApplication.API.Models
{
    [Serializable]
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageLink { get; set; }
        public string VisitShowPageUrl { get; set; }
        public string WatchVideoUrl { get; set; }
    }
}
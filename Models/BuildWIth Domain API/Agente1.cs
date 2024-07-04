using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeguridad.Models.BuildWIth_Domain_API
{
    public class Script
    {
        public string id { get; set; }
    }

    public class Categories
    {
        public List<string> category { get; set; }
    }

    public class Technology
    {
        public Categories categories { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string tag { get; set; }
        public long firstDetected { get; set; }
        public long lastDetected { get; set; }
        public string isPremium { get; set; }
        public string parent { get; set; }
    }

    public class Technologies
    {
        public List<Technology> technology { get; set; }
    }

    public class PathCategoryV10
    {
        public Technologies technologies { get; set; }
        public long firstIndexed { get; set; }
        public long lastIndexed { get; set; }
        public string domain { get; set; }
        public string url { get; set; }
        public string subDomain { get; set; }
    }

    public class Paths
    {
        public PathCategoryV10 pathCategoryV10 { get; set; }
    }

    public class Result
    {
        public bool isDB { get; set; }
        public int spend { get; set; }
        public Paths paths { get; set; }
    }

    public class Meta
    {
        public object companyName { get; set; }
        public object emails { get; set; }
        public object country { get; set; }
        public int aRank { get; set; }
        public int qRank { get; set; }
        public object vertical { get; set; }
        public int majestic { get; set; }
        public int umbrella { get; set; }
    }

    public class Attributes
    {
        public int employees { get; set; }
        public int mjRank { get; set; }
        public int mjTldRank { get; set; }
        public int refSN { get; set; }
        public int refIP { get; set; }
        public int followers { get; set; }
        public int sitemap { get; set; }
        public int gtmTags { get; set; }
        public int qubitTags { get; set; }
        public int tealiumTags { get; set; }
        public int adobeTags { get; set; }
        public int cDimensions { get; set; }
        public int cGoals { get; set; }
        public int cMetrics { get; set; }
        public int productCount { get; set; }
    }

    public class APIResultWithMetaV16
    {
        public Result result { get; set; }
        public Meta meta { get; set; }
        public Attributes attributes { get; set; }
        public long firstIndexed { get; set; }
        public long lastIndexed { get; set; }
        public string lookup { get; set; }
        public int salesRevenue { get; set; }
    }

    public class Results
    {
        public APIResultWithMetaV16 apiResultWithMetaV16 { get; set; }
    }

    public class Api20
    {
        public List<Script> script { get; set; }
        public Results results { get; set; }
        public object errors { get; set; }
    }
}

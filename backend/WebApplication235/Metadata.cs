using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication235
{
    public class Metadata
    {
        public string Standard { get; set; }
        public string Subject { get; set; }
        public string  Lecture { get; set; }
    }

    public class Root
    {
        public Dictionary<string, standard> standards { get; set; }
        public Root()
        {
            standards = new Dictionary<string, standard>();
        }
    }

    public class standard
    {
        public string name { get; set; }
        public Dictionary<string,subject> subjects { get; set; }
        public standard()
        {
            subjects = new Dictionary<string,subject>();
        }

    }

    public class subject
    {
        public string name { get; set; }
        public Dictionary<string,lecture> lectures { get; set; }
        public subject()
        {
            lectures = new Dictionary<string, lecture>();
        }
    }

    public class lecture
    {
        public string lectureid { get; set; }
    }

    public class LRoot
    {
        public List<LRoot> standards { get; set; }
        public LRoot()
        {
            standards = new List<LRoot>();
        }
    }

    public class Lstandard
    {
        public string name { get; set; }
        public List<subject> subjects { get; set; }
        public Lstandard()
        {
            subjects = new List<subject>();
        }

    }

    public class Lsubject
    {
        public string name { get; set; }
        public List<Llecture> lectures { get; set; }
        public Lsubject()
        {
            lectures = new List<Llecture>();
        }
    }

    public class Llecture
    {
        public string lectureid { get; set; }
    }




}

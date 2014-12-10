using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public class WarriorTemplate
    {
        
    }
    public class Warrior
    {
        public string name;
        WarriorTemplate template;
        public int x;
        public string path;
        public int guardingDistance;
        public int level;
        
    }
    public class Adornment
    {
        public string name;
        public string image;
        public int x;
        public int y;
        public int width;
        public int height;
        public Adornment()
        {
            width = 100;
            height = 100;
        }
    }
}

﻿using System.Collections.Generic;

namespace eWolfPixelStandard.Services
{
    public class OptionsHolder
    {
        // create a path object that also has a name
        private readonly List<string> _pathsToSearch = new List<string>();

        public OptionsHolder()
        {
            _pathsToSearch.Add(@"D:\OffLine\Music\1991 Final Fantasy IV\");
        }

        public List<string> PathsToSearch => _pathsToSearch;
    }
}

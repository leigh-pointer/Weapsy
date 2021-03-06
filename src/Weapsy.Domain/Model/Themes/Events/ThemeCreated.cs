﻿using Weapsy.Core.Domain;

namespace Weapsy.Domain.Model.Themes.Events
{
    public class ThemeCreated : Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Folder { get; set; }
        public ThemeStatus Status { get; set; }
        public int SortOrder { get; set; }
    }
}

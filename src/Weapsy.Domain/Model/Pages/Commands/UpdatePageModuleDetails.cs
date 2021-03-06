﻿using System;
using System.Collections.Generic;
using Weapsy.Core.Domain;

namespace Weapsy.Domain.Model.Pages.Commands
{
    public class UpdatePageModuleDetails : ICommand
    {
        public Guid SiteId { get; set; }
        public Guid PageId { get; set; }
        public Guid ModuleId { get; set; }
        public string Title { get; set; }
        public bool InheritPermissions { get; set; }
        public List<PageModuleLocalisation> PageModuleLocalisations { get; set; } = new List<PageModuleLocalisation>();
        public IList<PageModulePermission> PageModulePermissions { get; set; } = new List<PageModulePermission>();
    }
}

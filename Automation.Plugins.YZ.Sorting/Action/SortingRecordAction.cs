﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Core;

namespace Automation.Plugins.YZ.Sorting.Action
{
    public class SortingRecordAction : AbstractAction
    {
        public override void Initialize()
        {
            IsPreload = false;
        }
    }
}

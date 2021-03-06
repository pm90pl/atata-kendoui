﻿using System;
using System.Linq;

namespace Atata.KendoUI.Tests
{
    using _ = SnippetPage;

    public class SnippetPage : Page<_>
    {
        public TControl Get<TControl>(params Attribute[] attributes)
            where TControl : Control<_>
        {
            if (!attributes.Any(x => x is FindAttribute))
                attributes = new[] { new FindFirstAttribute() }.Concat(attributes).ToArray();

            var control = Controls.Create<TControl>("Test", attributes);

            control.WaitTo.Within(45).Exist();

            return control;
        }

        public TControl GetByIndex<TControl>(int index, params Attribute[] attributes)
            where TControl : Control<_>
        {
            attributes = new[] { new FindByIndexAttribute(index) }.Concat(attributes).ToArray();

            return Get<TControl>(attributes);
        }

        public _ SwitchToFirstFrame()
        {
            var frame = Controls.Create<Frame<_>>("Test");
            Driver.SwitchTo().Frame(frame.Scope);

            return this;
        }
    }
}

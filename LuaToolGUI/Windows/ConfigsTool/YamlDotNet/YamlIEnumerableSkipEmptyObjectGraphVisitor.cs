// Zro

using YamlDotNet.Core;
using YamlDotNet.Serialization.ObjectGraphVisitors;
using YamlDotNet.Serialization;
using System.Collections;

namespace ToolStationGUI.Windows.ConfigsTool.YamlDotNet
{
    public sealed class YamlIEnumerableSkipEmptyObjectGraphVisitor : ChainedObjectGraphVisitor
    {
        public YamlIEnumerableSkipEmptyObjectGraphVisitor(IObjectGraphVisitor<IEmitter> nextVisitor)
            : base(nextVisitor)
        {
        }

        public override bool EnterMapping(IPropertyDescriptor key, IObjectDescriptor value, IEmitter context)
        {
            bool retVal = false;

            if (value.Value == null)
                return retVal;

            retVal = base.EnterMapping(key, value, context);
            if (typeof(IEnumerable).IsAssignableFrom(value.Value.GetType()))
            {
                var enumerableObject = (IEnumerable)value.Value;
                if (enumerableObject.GetEnumerator().MoveNext())
                {
                    retVal = base.EnterMapping(key, value, context);
                }
            }

            return retVal;
        }
    }
}
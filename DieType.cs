using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal class DieSizeAttr : Attribute
    {
        internal DieSizeAttr(int size)
        {
            this.Size = size;
        }
        internal int Size { get; private set; }
    }

    internal enum DieType
    {
        [DieSizeAttr(1)] d1, // Used to implement flat damage rolls with no randomness
        [DieSizeAttr(2)] d2,
        [DieSizeAttr(3)] d3,
        [DieSizeAttr(4)] d4,
        [DieSizeAttr(6)] d6,
        [DieSizeAttr(8)] d8,
        [DieSizeAttr(10)] d10,
        [DieSizeAttr(12)] d12,
        [DieSizeAttr(20)] d20,
        [DieSizeAttr(100)] d100
    }

    internal static class DieTypes
    {
        private static Random random = new Random();

        internal static int roll(this DieType dieType)
        {
            DieSizeAttr attr = GetAttr(dieType);
            return random.Next(1, attr.Size + 1);
        }

        private static DieSizeAttr GetAttr(DieType dieType)
        {
            return (DieSizeAttr)Attribute.GetCustomAttribute(ForValue(dieType), typeof(DieSizeAttr));
        }

        private static MemberInfo ForValue(DieType dieType)
        {
            return typeof(DieType).GetField(Enum.GetName(typeof(DieType), dieType));
        }
    }
}

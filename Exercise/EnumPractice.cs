using System.ComponentModel;

namespace Exercise
{
    public enum EnumPractice
    {
        /// <summary>
        /// 家长测评
        /// </summary>
        [Description("家长测评")]
        Parent = 1,
        /// <summary>
        /// 孩子测评
        /// </summary>
        [Description("孩子测评")]
        Child = 2
    }
}

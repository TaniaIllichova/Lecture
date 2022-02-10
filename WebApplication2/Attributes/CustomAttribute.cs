using System;

namespace WebApplication2.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
    public class CustomAttribute : Attribute
    {
    }
}
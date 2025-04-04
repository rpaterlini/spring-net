/*
 * Copyright � 2002-2011 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Reflection;

namespace Spring.Objects.Factory.Support;

/// <summary>
/// An <see cref="Spring.Objects.Factory.Support.IMethodReplacer"/>
/// implementation that delegates to an
/// <see cref="Spring.Objects.Factory.Support.IMethodReplacer"/> that is
/// obtained as the result of a lookup in an associated IoC container.
/// </summary>
/// <remarks>
/// <p>
/// This class is reserved for internal use within the framework; it is
/// not intended to be used by application developers using Spring.NET.
/// </p>
/// </remarks>
/// <author>Rick Evans</author>
public sealed class DelegatingMethodReplacer : AbstractMethodReplacer
{
    /// <summary>
    /// Creates a new instance of the
    /// <see cref="ArgumentNullException"/>
    /// class.
    /// </summary>
    /// <param name="objectDefinition">
    /// The object definition that is the target of the method replacement.
    /// </param>
    /// <param name="objectFactory">
    /// The enclosing IoC container with which the above
    /// <paramref name="objectDefinition"/> is associated.
    /// </param>
    /// <exception cref="DelegatingMethodReplacer">
    /// If either of the supplied arguments is <see langword="null"/>.
    /// </exception>
    public DelegatingMethodReplacer(IConfigurableObjectDefinition objectDefinition, IObjectFactory objectFactory)
        : base(objectDefinition, objectFactory)
    {
    }

    /// <summary>
    /// Reimplements the supplied <paramref name="method"/> by delegating to
    /// another <see cref="Spring.Objects.Factory.Support.IMethodReplacer"/>
    /// looked up in an enclosing IoC container.
    /// </summary>
    /// <param name="target">
    /// The instance whose <paramref name="method"/> is to be
    /// (re)implemented.
    /// </param>
    /// <param name="method">
    /// The method that is to be (re)implemented.
    /// </param>
    /// <param name="arguments">The target method's arguments.</param>
    /// <returns>
    /// The result of the delegated call to the looked up
    /// <see cref="Spring.Objects.Factory.Support.IMethodReplacer"/>.
    /// </returns>
    public override object Implement(object target, MethodInfo method, object[] arguments)
    {
        ReplacedMethodOverride ovr = (ReplacedMethodOverride) GetOverride(method);
        IMethodReplacer methodReplacement = (IMethodReplacer) GetObject(ovr.MethodReplacerObjectName);
        return methodReplacement.Implement(target, method, arguments);
    }
}

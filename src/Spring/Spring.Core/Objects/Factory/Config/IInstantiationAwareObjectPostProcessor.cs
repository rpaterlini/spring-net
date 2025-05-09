/*
 * Copyright © 2002-2011 the original author or authors.
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

namespace Spring.Objects.Factory.Config;

/// <summary>
/// Subinterface of
/// <see cref="Spring.Objects.Factory.Config.IObjectPostProcessor"/>
/// that adds a before-instantiation callback and a callback after instantiation but before
/// explicit properties are set or autowiring occurs.
/// </summary>
/// <remarks>
/// <para>
/// Typically used to suppress default instantiation for specific target objects,
/// for example to create proxies with special <c>Spring.Aop.ITargetSource</c>s (pooling targets,
/// lazily initializing targets, etc), or to implement additional injection strategies such as field
/// injection.
/// </para>
/// <para>
/// This interface is a special purpose interface, mainly for internal use within the framework.
/// It is recommended to implement the plain <see cref="IObjectPostProcessor"/> interface as far as
/// possible, or to derive from <see cref="IInstantiationAwareObjectPostProcessor"/> in order to be shielded
/// from extension to this interface.
/// </para>
/// </remarks>
/// <author>Juergen Hoeller</author>
/// <author>Rick Evans (.NET)</author>
public interface IInstantiationAwareObjectPostProcessor : IObjectPostProcessor
{
    /// <summary>
    /// Apply this
    /// <see cref="Spring.Objects.Factory.Config.IObjectPostProcessor"/>
    /// <i>before the target object gets instantiated</i>.
    /// </summary>
    /// <remarks>
    /// <p>
    /// The returned object may be a proxy to use instead of the target
    /// object, effectively suppressing the default instantiation of the
    /// target object.
    /// </p>
    /// <p>
    /// If the object is returned by this method is not
    /// <see langword="null"/>, the object creation process will be
    /// short-circuited. The returned object will not be processed any
    /// further; in particular, no further
    /// <see cref="Spring.Objects.Factory.Config.IObjectPostProcessor"/>
    /// callbacks will be applied to it. This mechanism is mainly intended
    /// for exposing a proxy instead of an actual target object.
    /// </p>
    /// <p>
    /// This callback will only be applied to object definitions with an
    /// object class. In particular, it will <b>not</b> be applied to
    /// objects with a "factory-method" (i.e. objects that are to be
    /// instantiated via a layer of indirection anyway).
    /// </p>
    /// </remarks>
    /// <param name="objectType">
    /// The <see cref="System.Type"/> of the target object that is to be
    /// instantiated.
    /// </param>
    /// <param name="objectName">
    /// The name of the target object.
    /// </param>
    /// <returns>
    /// The object to expose instead of a default instance of the target
    /// object.
    /// </returns>
    /// <exception cref="Spring.Objects.ObjectsException">
    /// In the case of any errors.
    /// </exception>
    /// <seealso cref="Spring.Objects.Factory.Support.AbstractObjectDefinition.HasObjectType"/>
    /// <seealso cref="Spring.Objects.Factory.Support.IConfigurableObjectDefinition.FactoryMethodName"/>
    object PostProcessBeforeInstantiation(Type objectType, string objectName);

    /// <summary>
    /// Perform operations after the object has been instantiated, via a constructor or factory method,
    /// but before Spring property population (from explicit properties or autowiring) occurs.
    /// </summary>
    /// <param name="objectInstance">The object instance created, but whose properties have not yet been set</param>
    /// <param name="objectName">Name of the object.</param>
    /// <returns>true if properties should be set on the object; false if property population
    /// should be skipped.  Normal implementations should return true.  Returning false will also
    /// prevent any subsequent InstantiationAwareObjectPostProcessor instances from being
    /// invoked on this object instance.</returns>
    bool PostProcessAfterInstantiation(object objectInstance, string objectName);

    /// <summary>
    /// Post-process the given property values before the factory applies them
    /// to the given object.
    /// </summary>
    /// <remarks>Allows for checking whether all dependencies have been
    /// satisfied, for example based on a "Required" annotation on bean property setters.
    /// <para>Also allows for replacing the property values to apply, typically through
    /// creating a new MutablePropertyValues instance based on the original PropertyValues,
    /// adding or removing specific values.
    /// </para>
    /// </remarks>
    /// <param name="pvs">The property values that the factory is about to apply (never <code>null</code>).</param>
    /// <param name="pis">he relevant property infos for the target object (with ignored
    /// dependency types - which the factory handles specifically - already filtered out)</param>
    /// <param name="objectInstance">The object instance created, but whose properties have not yet
    /// been set.</param>
    /// <param name="objectName">Name of the object.</param>
    /// <returns>The actual property values to apply to the given object (can be the
    /// passed-in PropertyValues instances0 or null to skip property population.</returns>
    IPropertyValues PostProcessPropertyValues(IPropertyValues pvs, IList<PropertyInfo> pis, object objectInstance, string objectName);
}

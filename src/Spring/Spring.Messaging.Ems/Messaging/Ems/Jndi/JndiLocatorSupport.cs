/*
 * Copyright 2002-2010 the original author or authors.
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

using Microsoft.Extensions.Logging;
using Spring.Objects.Factory;
using Spring.Util;

namespace Spring.Messaging.Ems.Jndi;

public abstract class JndiLocatorSupport : JndiAccessor
{
    protected virtual object Lookup(string jndiName)
    {
        object jndiObject = Lookup(jndiName, null);
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug("Located object with JNDI name [" + jndiName + "]");
        }

        return jndiObject;
    }

    protected virtual object Lookup(string jndiName, Type requiredType)
    {
        AssertUtils.ArgumentNotNull(jndiName, "jndiName");

        object jndiObject = JndiLookupContext.Lookup(jndiName);

        if (requiredType != null && !ObjectUtils.IsAssignable(requiredType, jndiObject))
        {
            throw new TypeMismatchNamingException(
                jndiName, requiredType, (jndiObject != null ? jndiObject.GetType() : null));
        }

        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug("Located object with JNDI name [" + jndiName + "]");
        }

        return jndiObject;
    }
}

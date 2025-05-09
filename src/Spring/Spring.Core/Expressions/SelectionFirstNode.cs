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

using System.Collections;
using System.Runtime.Serialization;

namespace Spring.Expressions;

/// <summary>
/// Represents parsed selection node in the navigation expression.
/// </summary>
/// <author>Aleksandar Seovic</author>
[Serializable]
public class SelectionFirstNode : BaseNode
{
    /// <summary>
    /// Create a new instance
    /// </summary>
    public SelectionFirstNode() : base()
    {
    }

    /// <summary>
    /// Create a new instance from SerializationInfo
    /// </summary>
    protected SelectionFirstNode(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    /// Returns the first context item that matches selection expression.
    /// </summary>
    /// <param name="context">Context to evaluate expressions against.</param>
    /// <param name="evalContext">Current expression evaluation context.</param>
    /// <returns>Node's value.</returns>
    protected override object Get(object context, EvaluationContext evalContext)
    {
        IEnumerable enumerable = context as IEnumerable;
        if (enumerable == null)
        {
            throw new ArgumentException(
                "Selection can only be used on an instance of the type that implements IEnumerable.");
        }

        BaseNode expression = (BaseNode) this.getFirstChild();
        using (evalContext.SwitchThisContext())
        {
            foreach (object o in enumerable)
            {
                evalContext.ThisContext = o;
                bool isMatch = (bool) GetValue(expression, o, evalContext);
                if (isMatch)
                {
                    return o;
                }
            }
        }

        return null;
    }
}

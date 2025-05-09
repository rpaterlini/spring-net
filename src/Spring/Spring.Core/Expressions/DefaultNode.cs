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

using System.Runtime.Serialization;

namespace Spring.Expressions;

/// <summary>
/// Represents parsed default node in the navigation expression.
/// </summary>
/// <author>Aleksandar Seovic</author>
[Serializable]
public class DefaultNode : BinaryOperator
{
    /// <summary>
    /// Create a new instance
    /// </summary>
    public DefaultNode()
    {
    }

    /// <summary>
    /// Create a new instance from SerializationInfo
    /// </summary>
    protected DefaultNode(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    /// Returns left operand if it is not null, or the right operand if it is.
    /// </summary>
    /// <param name="context">Context to evaluate expressions against.</param>
    /// <param name="evalContext">Current expression evaluation context.</param>
    /// <returns>Node's value.</returns>
    protected override object Get(object context, EvaluationContext evalContext)
    {
        object leftVal = GetValue(Left, context, evalContext);
        object rightVal = GetValue(Right, context, evalContext);

        return (leftVal != null ? leftVal : rightVal);
    }
}

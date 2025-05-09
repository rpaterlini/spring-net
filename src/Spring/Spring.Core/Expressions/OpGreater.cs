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
using Spring.Util;

namespace Spring.Expressions;

/// <summary>
/// Represents logical "greater than" operator.
/// </summary>
/// <author>Aleksandar Seovic</author>
[Serializable]
public class OpGreater : BinaryOperator
{
    /// <summary>
    /// Create a new instance
    /// </summary>
    public OpGreater() : base()
    {
    }

    /// <summary>
    /// Create a new instance from SerializationInfo
    /// </summary>
    protected OpGreater(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    /// Returns a value for the logical "greater than" operator node.
    /// </summary>
    /// <param name="context">Context to evaluate expressions against.</param>
    /// <param name="evalContext">Current expression evaluation context.</param>
    /// <returns>Node's value.</returns>
    protected override object Get(object context, EvaluationContext evalContext)
    {
        object left = GetLeftValue(context, evalContext);
        object right = GetRightValue(context, evalContext);

        return CompareUtils.Compare(left, right) > 0;
    }
}

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
using Spring.Expressions.Parser.antlr.collections;

namespace Spring.Expressions;

/// <summary>
/// Represents parsed map initializer node in the navigation expression.
/// </summary>
/// <author>Aleksandar Seovic</author>
[Serializable]
public class MapInitializerNode : BaseNode
{
    /// <summary>
    /// Creates a new instance of <see cref="MapInitializerNode"/>.
    /// </summary>
    public MapInitializerNode()
    {
    }

    /// <summary>
    /// Create a new instance from SerializationInfo
    /// </summary>
    protected MapInitializerNode(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    /// Creates new instance of the map defined by this node.
    /// </summary>
    /// <param name="context">Context to evaluate expressions against.</param>
    /// <param name="evalContext">Current expression evaluation context.</param>
    /// <returns>Node's value.</returns>
    protected override object Get(object context, EvaluationContext evalContext)
    {
        IDictionary entries = new Hashtable();
        AST entryNode = this.getFirstChild();
        while (entryNode != null)
        {
            DictionaryEntry entry = (DictionaryEntry) GetValue(((MapEntryNode) entryNode), evalContext.RootContext, evalContext);
            entries[entry.Key] = entry.Value;
            entryNode = entryNode.getNextSibling();
        }

        return entries;
    }
}

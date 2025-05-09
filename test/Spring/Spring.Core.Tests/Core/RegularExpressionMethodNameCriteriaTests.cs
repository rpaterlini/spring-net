/*
 * Copyright 2004 the original author or authors.
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
using Spring.Objects;
using NUnit.Framework;

namespace Spring.Core;

/// <summary>
/// Unit tests for the RegularExpressionMethodNameCriteria class.
/// </summary>
[TestFixture]
public class RegularExpressionMethodNameCriteriaTests
{
    [Test]
    public void IsSatisfied()
    {
        RegularExpressionMethodNameCriteria criteria = new RegularExpressionMethodNameCriteria("Click");
        MethodInfo method = typeof(TestObject).GetMethod("OnClick");
        Assert.IsTrue(criteria.IsSatisfied(method));
    }

    [Test]
    public void IsNotSatisfiedWithGarbage()
    {
        RegularExpressionMethodNameCriteria criteria = new RegularExpressionMethodNameCriteria("BingoBango");
        MethodInfo method = typeof(TestObject).GetMethod("OnClick");
        Assert.IsFalse(criteria.IsSatisfied(method));
    }

    [Test]
    public void IsNotSatisfiedWithNull()
    {
        RegularExpressionMethodNameCriteria criteria = new RegularExpressionMethodNameCriteria("OnClick");
        Assert.IsFalse(criteria.IsSatisfied(null));
    }

    [Test]
    public void IsSatisfiedWithAnythingByDefault()
    {
        RegularExpressionMethodNameCriteria criteria = new RegularExpressionMethodNameCriteria();
        MethodInfo method = typeof(TestObject).GetMethod("OnClick");
        Assert.IsTrue(criteria.IsSatisfied(method));
    }
}

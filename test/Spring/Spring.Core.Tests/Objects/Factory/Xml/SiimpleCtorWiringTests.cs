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

using NUnit.Framework;

namespace Spring.Objects.Factory.Xml;

/// <summary>
/// This class contains tests for
/// </summary>
/// <author>Mark Pollack</author>
/// <version>$Id:$</version>
[TestFixture]
public class SiimpleCtorWiringTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SimpleCtor()
    {
        XmlObjectFactory xof = new XmlObjectFactory(new ReadOnlyXmlTestResource("simple-constructor-arg.xml", GetType()));
        ConstructorDependenciesObject obj = (ConstructorDependenciesObject) xof.GetObject("rod4");
        Assert.AreEqual("Kerry2", obj.Spouse1.Name);
    }
}

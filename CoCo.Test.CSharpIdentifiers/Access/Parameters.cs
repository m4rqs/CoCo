﻿using CoCo.Test.Common;
using NUnit.Framework;

namespace CoCo.Test.CSharpIdentifiers.Access
{
    internal class Parameters : CSharpIdentifierTests
    {
        [Test]
        public void ParameterTest_DelegateParameter()
        {
            @"Tests\CSharpIdentifiers\CSharpIdentifiers\Access\Parameters\Delegate.cs".GetClassifications(ProjectInfo)
                .AssertContains(Names.ParameterName.ClassifyAt(243, 3));
        }

        [Test]
        public void ParameterTest_LambdaParameter()
        {
            @"Tests\CSharpIdentifiers\CSharpIdentifiers\Access\Parameters\Lambda.cs".GetClassifications(ProjectInfo)
                .AssertContains(
                    Names.ParameterName.ClassifyAt(196, 3),
                    Names.ParameterName.ClassifyAt(341, 3));
        }

        [Test]
        public void ParameterTest_OptionalParameter()
        {
            @"Tests\CSharpIdentifiers\CSharpIdentifiers\Access\Parameters\Optional.cs".GetClassifications(ProjectInfo)
                .AssertContains(Names.ParameterName.ClassifyAt(190, 4));
        }

        [Test]
        public void ParameterTest_RefInOutParameters()
        {
            @"Tests\CSharpIdentifiers\CSharpIdentifiers\Access\Parameters\RefInOut.cs".GetClassifications(ProjectInfo)
                .AssertContains(
                    Names.ParameterName.ClassifyAt(178, 4),
                    Names.ParameterName.ClassifyAt(185, 4),
                    Names.ParameterName.ClassifyAt(204, 4),
                    Names.ParameterName.ClassifyAt(211, 4));
        }

        [Test]
        public void ParameterTest_VariableParameter()
        {
            @"Tests\CSharpIdentifiers\CSharpIdentifiers\Access\Parameters\Variable.cs".GetClassifications(ProjectInfo)
                .AssertContains(Names.ParameterName.ClassifyAt(195, 5));
        }
    }
}
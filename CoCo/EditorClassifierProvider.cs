﻿//------------------------------------------------------------------------------
// <copyright file="EditorClassifierProvider.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace CoCo
{
    /// <summary>
    /// Classifier provider. It adds the classifier to the set of classifiers.
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    //[ContentType("text")]
    internal class EditorClassifierProvider : IClassifierProvider
    {
        // Disable "Field is never assigned to..." compiler's warning. The field is assigned by MEF.
#pragma warning disable 649

        /// <summary>
        /// Classification registry to be used for getting a reference to the custom classification
        /// type later.
        /// </summary>
        [Import]
        private IClassificationTypeRegistryService classificationRegistry;

#pragma warning restore 649

        /// <summary>
        /// Gets a classifier for the given text buffer.
        /// </summary>
        /// <param name="textBuffer">The <see cref="ITextBuffer"/> to classify.</param>
        /// <returns>
        /// A classifier for the text buffer, or null if the provider cannot do so in its current state.
        /// </returns>
        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new EditorClassifier(classificationRegistry));
        }
    }
}
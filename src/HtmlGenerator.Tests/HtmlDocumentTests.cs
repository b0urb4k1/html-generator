﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HtmlGenerator.Tests
{
    public class HtmlDocumentTests
    {
        [Fact]
        public void Ctor()
        {
            HtmlDocument document = new HtmlDocument();
            Assert.Equal("html", document.Tag);
            Assert.Null(document.InnerText);
            Assert.False(document.IsVoid);
            Assert.Equal(2, document.Elements().Count());
            Assert.Empty(document.Attributes());
            Assert.Equal(2, document.ElementsAndAttributes().Count());

            Assert.Equal("<head></head>", document.Head.ToString());
            Assert.Equal("<body></body>", document.Body.ToString());
        }

        [Fact]
        public void Doctype_Get_ReturnsExpected()
        {
            HtmlDocument document = new HtmlDocument();
            Assert.Equal("<!DOCTYPE html>", document.Doctype);
        }

        public static IEnumerable<object[]> Doctype_TestData()
        {
            yield return new object[] { "<!DOCTYPE html>" };
            yield return new object[] { "<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">" };
            yield return new object[] { " \r \t \n" };
            yield return new object[] { "" };
            yield return new object[] { null };
        }

        [Theory]
        [MemberData(nameof(Doctype_TestData))]
        public void Doctype_Set_Get_ReturnsExpected(string value)
        {
            HtmlDocument document = new HtmlDocument();
            document.Doctype = value;
            Assert.Equal(value, document.Doctype);
        }

<<<<<<< HEAD
=======
        [Fact]
        public void Head_SetExisting_NonNull_RemovesElement()
        {
            HtmlElement value = Tag.Head.WithClass("class");
            HtmlDocument document = new HtmlDocument() { Head = Tag.Head };
            document.Head = value;
            Assert.Equal(new HtmlElement[] { value }, document.Elements());
            Assert.Equal(value, document.Head);
        }

        [Fact]
        public void Head_SetExisting_Null_RemovesElement()
        {
            HtmlDocument document = new HtmlDocument() { Head = Tag.Head };
            document.Head = null;
            Assert.True(document.IsEmpty);
            Assert.Null(document.Head);
        }

        [Fact]
        public void Head_SetNonExisting_Null_RemovesElement()
        {
            HtmlDocument document = new HtmlDocument() { Head = null };
            document.Head = null;
            Assert.True(document.IsEmpty);
            Assert.Null(document.Head);
        }
        
        [Fact]
        public void AddHead_DocumentHasBody_ThrowsInvalidOperationException()
        {
            HtmlDocument document = new HtmlDocument() { Head = Tag.Head };
            Assert.Throws<InvalidOperationException>(() => document.AddHead());
        }

        [Fact]
        public void Body_SetExisting_NonNull_RemovesElement()
        {
            HtmlElement value = Tag.Body.WithClass("class");
            HtmlDocument document = new HtmlDocument() { Body = Tag.Body };
            document.Body = value;
            Assert.Equal(new HtmlElement[] { value }, document.Elements());
            Assert.Equal(value, document.Body);
        }

        [Fact]
        public void Body_SetExisting_Null_RemovesElement()
        {
            HtmlDocument document = new HtmlDocument() { Body = Tag.Body };
            document.Body = null;
            Assert.True(document.IsEmpty);
            Assert.Null(document.Body);
        }

        [Fact]
        public void Body_SetNonExisting_Null_RemovesElement()
        {
            HtmlDocument document = new HtmlDocument() { Body = null };
            document.Body = null;
            Assert.True(document.IsEmpty);
            Assert.Null(document.Body);
        }

        [Fact]
        public void AddBody_DocumentHasBody_ThrowsInvalidOperationException()
        {
            HtmlDocument document = new HtmlDocument() { Body = Tag.Body };
            Assert.Throws<InvalidOperationException>(() => document.AddBody());
        }

        public static IEnumerable<object[]> Equals_TestData()
        {
            yield return new object[] { new HtmlDocument(), new HtmlDocument(), true };
            yield return new object[] { new HtmlDocument(), new HtmlDocument().WithClass("class"), false };

            yield return new object[] { new HtmlDocument() { Doctype = null }, new HtmlDocument() { Doctype = null }, true };
            yield return new object[] { new HtmlDocument() { Doctype = null }, new HtmlDocument() { Doctype = new HtmlDoctype(HtmlDoctypeType.Html5) }, false };
            yield return new object[] { new HtmlDocument() { Doctype = new HtmlDoctype(HtmlDoctypeType.Html5) }, new HtmlDocument() { Doctype = null }, false };
            yield return new object[] { new HtmlDocument() { Doctype = new HtmlDoctype(HtmlDoctypeType.Html5) }, new HtmlDocument() { Doctype = new HtmlDoctype(HtmlDoctypeType.Html401Frameset) }, false };
        }

        [Theory]
        [MemberData(nameof(Equals_TestData))]
        public void Equals(HtmlDocument document, object other, bool expected)
        {
            if (other is HtmlDocument || other == null)
            {
                if (expected)
                {
                    Assert.Equal(expected, document.GetHashCode().Equals(other?.GetHashCode()));
                }
                Assert.Equal(expected, document.Equals((HtmlDocument)other));
            }
            Assert.Equal(expected, document.Equals(other));
        }

>>>>>>> a8516e4... Cleanup meta project (#46)
        [Theory]
        [MemberData(nameof(Doctype_TestData))]
        public void Serialize_NullDoctype_NotIncluded(string doctype)
        {
            HtmlDocument document = new HtmlDocument();
            document.Doctype = doctype;

            string expectedDocType = string.IsNullOrEmpty(doctype) ? string.Empty : doctype + Environment.NewLine;
            Helpers.SerializeIgnoringFormatting(document, string.Format(@"{0}<html>
<head></head>
<body></body>
</html>", expectedDocType));
        }

        [Fact]
        public void Serialize_EmptyHtmlDocument()
        {
            HtmlDocument document = new HtmlDocument();
            Helpers.SerializeIgnoringFormatting(document, @"<!DOCTYPE html>
<html>
<head></head>
<body></body>
</html>");
        }

        [Fact]
        public void Serialize_Complex()
        {
            HtmlDocument document = new HtmlDocument();
            document.Head.Add(Tag.Title.WithInnerText("Title"));
            document.Body.Add(Tag.Header1("Header1").WithClass("aClass"));
            document.Body.Add(Tag.Br);
            document.Body.Add(Tag.Paragraph("Paragraph").WithAttribute(Attribute.AllowFullScreen));

            Helpers.SerializeIgnoringFormatting(document, @"<!DOCTYPE html>
<html>
<head>
  <title>Title</title>
</head>
<body>
  <h1 class=""aClass"">Header1</h1>
  <br />
  <p allowfullscreen>Paragraph</p>
</body>
</html>");
        }
    }
}
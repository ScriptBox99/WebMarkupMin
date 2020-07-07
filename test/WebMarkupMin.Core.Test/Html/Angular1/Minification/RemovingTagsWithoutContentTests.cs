﻿using Xunit;

namespace WebMarkupMin.Core.Test.Html.Angular1.Minification
{
	public class RemovingTagsWithoutContentTests
	{
		[Fact]
		public void RemovingTagsWithoutContentIsCorrect()
		{
			// Arrange
			var removingTagsWithoutContentMinifier = new HtmlMinifier(
				new HtmlMinificationSettings(true) { RemoveTagsWithoutContent = true });

			const string input = "<div ng-app></div>";

			// Act
			string output = removingTagsWithoutContentMinifier.Minify(input).MinifiedContent;

			// Assert
			Assert.Equal(input, output);
		}
	}
}
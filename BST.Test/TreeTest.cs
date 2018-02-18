using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace BST.Test
{
    public class TreeTest
    {
        [Fact]
        public void Insert_value_to_empty_tree_returns_true()
        {
            var testValue = 1;
            var tree = new Tree();

            var insertResult = tree.Insert(testValue);

            Assert.True(insertResult);
        }

        [Theory]
        [InlineData(new[] { 1, 2, -5, 56, 34, 76, 4 }, 3)]
        public void Insert_new_value_returns_true(int[] bstValues, int testValue)
        {
            var tree = new Tree();
            foreach (var bstValue in bstValues)
            {
                tree.Insert(bstValue);
            }

            var insertResult = tree.Insert(testValue);

            Assert.True(insertResult);
        }

        [Fact]
        public void Insert_duplicated_value_returns_false()
        {
            var testValue = 1;
            var tree = new Tree();

            tree.Insert(testValue);
            var insertResult = tree.Insert(testValue);

            Assert.False(insertResult);
        }

        [Theory]
        [InlineData(new[] { 11, 3, 54, 6, 42, 95, 2, 45, 24, 23, 34 }, 45, 42)]
        [InlineData(new[] { 11, 3, 54, 6, 42, 95, 2, 45, 24, 23, 34 }, 5, 3)]
        public void FindMaxValueWithThreshold_returns_expected_value(int[] bstValues, int maxValue, int expectedValue)
        {
            var tree = new Tree();
            foreach (var bstValue in bstValues)
                tree.Insert(bstValue);

            var result = tree.FindMaxValueWithThreshold(maxValue);

            Assert.NotNull(result);
            Assert.Equal(expectedValue, result.Value);
        }

        [Fact]
        public void FindMaxValueWithThreshold_returns_null_on_lack_of_value_below_treashold()
        {
            var tree = new Tree();
            foreach (var bstValue in new[] { 11, 3, 54, 6, 42, 95, 2, 45, 24, 23, 34 })
                tree.Insert(bstValue);

            var result = tree.FindMaxValueWithThreshold(-1);

            Assert.Null(result);
        }

        [Fact]
        public void FindMaxValueWithThreshold_returns_null_on_empty_tree()
        {
            var tree = new Tree();

            var result = tree.FindMaxValueWithThreshold(1);

            Assert.Null(result);
        }
    }
}
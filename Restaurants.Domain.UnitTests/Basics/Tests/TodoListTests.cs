using Restaurants.Domain.UnitTests.Basics.Units;

namespace Restaurants.Domain.UnitTests.Basics.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Add_SavesTodoItem()
        {
            TodoList list = new();

            list.Add(new("Test content"));

            TodoList.TodoItem savedItem = Assert.Single(list.All);
            Assert.NotNull(savedItem);
            Assert.Equal(1, savedItem.Id);
            Assert.Equal("Test content", savedItem.Content);
            Assert.False(savedItem.Complete);
        }

        [Fact]
        public void TodoItemIdIncrementEverytimeWeAdd()
        {
            TodoList list = new();

            list.Add(new("Test 1"));
            list.Add(new("Test 2"));

            TodoList.TodoItem[] items = list.All.ToArray();
            Assert.Equal(1, items[0].Id);
            Assert.Equal(2, items[1].Id);
        }

        [Fact]
        public void Complete_SetsTodoItemCompleteFlagToTrue()
        {
            TodoList list = new();
            list.Add(new("Test 1"));

            list.Complete(1);

            TodoList.TodoItem completedItem = Assert.Single(list.All);
            Assert.NotNull(completedItem);
            Assert.Equal(1, completedItem.Id);
            Assert.True(completedItem.Complete);
        }
    }
}

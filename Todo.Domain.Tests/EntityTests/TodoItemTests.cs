using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void DadoUmNovoTodoOMesmoNaoPodeSerConcluido()
        {
            var todo = new TodoItem("Nova atividade", DateTime.Now, "André Motta");
            Assert.AreEqual(todo.Done, false);
        }
    }
}
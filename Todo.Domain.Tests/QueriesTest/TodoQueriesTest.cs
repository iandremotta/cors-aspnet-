
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.Repositories;

[TestClass]
public class TodoQueriesTest
{
    private List<TodoItem> _items;
    public TodoQueriesTest()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "UsuarioA"));
        _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "UsuarioA"));
        _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "andremotta"));
        _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "andremotta"));
    }
    [TestMethod]
    public void DadoAConsultaDeveRetornarTarefasApenasDoUsuarioAndre()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("andremotta"));
        Console.WriteLine(result);
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void DadoUmUsuarioDeveRetornarAsTarefasNaoFeitas()
    {
        var result = _items.Where(x => x.User == "andremotta" && x.Done);
        Assert.AreEqual(2, result.Count());
    }
}

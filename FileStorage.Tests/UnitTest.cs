using FileStorage.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FileStorage.Tests;

[TestFixture]
public abstract class UnitTest
{
    protected TestServices services;

    [TearDown]
    public async virtual Task TearDown()
    {
        await ClearDb();
    }

    [SetUp]
    public async virtual Task SetUp()
    {
        await ClearDb();
    }


    protected async virtual Task ClearDb()
    {
        // Nothing to do
    }

    [OneTimeSetUp]
    public async virtual Task OneTimeSetUp()
    {
        services = new TestServices();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        //
    }
}

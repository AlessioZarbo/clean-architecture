using API.Controllers;
using Application.DTO.Book;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Internal;

namespace API.Test;

/// <summary>
/// Unit tests for the <see cref="BookController"/> class.
/// </summary>
[TestFixture, Category("Class_Controller")]
public class BookControllerTest {

	/// <summary>
	/// The randomizer used for generating test data.
	/// </summary>
	private Randomizer _randomizer;

	/// <summary>
	/// The Mock of the <see cref="IBookService"/> used for testing.
	/// </summary>
	private Mock<IBookService> _svcMock;

	/// <summary>
	/// The instance of the <see cref="BookController"/> being tested.
	/// </summary>
	private BookController _sut; // System Under Test

	/// <summary>
	/// Sets up the test environment before each test is run.
	/// </summary>
	[SetUp]
	public void Setup() {

		_svcMock = new Mock<IBookService>(MockBehavior.Strict);
		_randomizer = new Randomizer();
		_sut = new BookController(_svcMock.Object) {
			ControllerContext = new ControllerContext() {
				HttpContext = new DefaultHttpContext()
			}
		};
	}

	/// <summary>
	/// Cleans up the test environment after each test is run.
	/// </summary>
	[TearDown]
	public void TearDown() {

		_svcMock.Verify();
	}

	/// <summary>
	/// Tests that the GetBook method returns an Ok result with the expected book when the book is found.
	/// </summary>
	[Test]
	public async Task GetById_Found_ReturnsOk() {

		var id = _randomizer.Next(1, int.MaxValue);

		var book = new BookDto() { Id = id, Title = "Test Book" };

		_svcMock
			.Setup(s => s.GetBookByIdAsync(id))
			.ReturnsAsync(book)
			.Verifiable();

		var result = await _sut.GetBook(id);

		var ok = result as OkObjectResult;
		Assert.That(ok, Is.Not.Null);
		Assert.That(ok.StatusCode, Is.EqualTo(200));

		var dto = ok.Value as BookDto;
		Assert.That(dto, Is.Not.Null);
		Assert.That(book, Is.EqualTo(dto));
	}

	[Test]
	public async Task GetById_NotFound_Returns404() {

		var id = _randomizer.Next(1, int.MaxValue);
		_svcMock
			.Setup(s => s.GetBookByIdAsync(id))!
			.ReturnsAsync((BookDto?) null)
			.Verifiable();

		var result = await _sut.GetBook(id);

		var notFound = result as NotFoundResult;
		Assert.That(notFound, Is.Not.Null);
		Assert.That(notFound.StatusCode, Is.EqualTo(404));
	}

	/// <summary>
	/// Tests that the GetBook method throws an exception when the book does not exist.
	/// </summary>
	[Test]
	public async Task When_Product_Dont_Exist_Then_GetById_Thrown_Exception() {

		throw new NotImplementedException();
	}
}

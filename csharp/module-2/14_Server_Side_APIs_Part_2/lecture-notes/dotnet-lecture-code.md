# Server-Side APIs: Part 2 - C# Lecture Notes

In this lecture, you'll continue working with the hotel reservation API. You'll focus on validating data, informing the client when an error occurs, and adding the ability to update and delete a reservation.

When you've completed the changes for this application, you can run the command-line client that you've used throughout the week. You don't need to change any client code because the API you've built out over the past two days follows the same contract as the fake one.

## Running the application

First, open the `ServersideAPIsPart2Lecture.sln` solution in Visual Studio, and have the students do this with you. Remind them to run the application to make sure everything works before adding any new code.

## Dependency injection

Before making any modifications, you can take the opportunity to point out a change that has been made to the lecture code from the day before. Point out that the `HotelsController` constructor is accepting an `IHotelDao` and the `ReservationsController` constructor is accepting an `IHotelDao` and an `IReservationDao` as parameters instead of creating instances directly. Ask the students where the instances of these DAOs are coming from as a way to spur discussion of the Dependency Injection feature of the ASP.NET framework.

Open up `Startup.cs` to point out the two following lines in the `ConfigureServices()` method:

```csharp
// Dependency Injection configuration
services.AddTransient<IHotelDao>(sp => new HotelMemoryDao());
services.AddTransient<IReservationDao>(sp => new ReservationMemoryDao());
```

This may look very foreign to the students, but point out that the code is basically saying "when an `IHotelDao`/`IReservationDao` parameter is in a constructor, return a `new HotelMemoryDao()`/`new ReservationMemoryDao()`.

It can also be a good idea to reassure students that Dependency Injection can seem complicated at first, even to experienced programmers, but that they'll continue to see examples of it and it'll become more intuitive over time.

## Reservation data validation

As the students saw in the previous lecture, you can create a new reservation from the command-line client application. If you didn't fill in all the required data, the command-line application didn't call the server. This is called **client-side validation**. Although this is a good practice, you must also validate the data on the server.

While the server runs, open Postman and show the students an example of sending a `POST` request with blank data. Point out that the new reservation is still created even though you sent empty values. You can copy and paste this JSON into the Body tab. Remember to set type to "raw" and change "text" to "JSON":

```json
{
	"hotelId": 1,
	"fullName": "",
	"checkinDate": "",
	"checkoutDate": "",
	"guests": 2
}
```

![Bad POST Request](./img/postman-create-bad-data-dotnet.png)

To fix this, you can add in some data validation by adding validation attributes to your model.

Begin by walking through how to add the correct validation attributes to the `Reservation` model. Additionally, even though you won't use the custom messages in the front-end application, it's good practice to start using them now.

This might be a good time to look at the [MSDN page on model validation](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1#validation-attributes-1) to explore the different types of attributes:

```csharp
public class Reservation
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The field `HotelId` is required.")]
    public int HotelId { get; set; }

    [Required(ErrorMessage = "The field `FullName` is required.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "The field `CheckinDate` is required.")]
    public DateTime CheckinDate { get; set; }

    [Range(1, 14, ErrorMessage = "Number of nights must be between 1 and 14.")]
    public int Nights { get; set; }

    [Range(1, 5, ErrorMessage = "The minimum number of guests is 1 and the maximum number is 5.")]
    public int Guests { get; set; }

    // ...
}
```

Now, go back to Postman. Right-click the tab and choose "Duplicate Tab"—you want to hold on to the "successful" request to show the `201` response code in a moment:

![Postman duplicate tab](./img/postman-duplicate-tab.png)

In the new request tab, click the "Body" tab to confirm the data is still there. Make a request and show the error messages returned when you send invalid data. Let the students know that the data validation automatically applies to the `Reservation` class anywhere you use it:

![Validation on bad POST data](./img/postman-validate-bad-data-dotnet.png)

### RESTful response codes

Show the students that the response code is `400 Bad Request` for this request. Take some time to reiterate that using HTTP response codes is a way for the server to let the client know what happened to the request. Responding with HTTP status codes is one part of what makes an API "RESTful." Some points to highlight:

- `2xx` codes are success codes. Show the Postman tab where the `POST` request succeeded. The server returned `201 Created` when the validation wasn't in place.
  - You'll show how the server returned that response code in a moment.
- `4xx` codes are client error codes. `400 Bad Request` is for when the server can't or won't process the request due to an apparent client error. In this case, the data was invalid based on the validation rules.
  - The server responding with a `400 Bad Request` due to validation errors is a built-in feature of ASP.NET Core. The controller must have the `[ApiController]` attribute for it to work.

## Create reservation method

After describing the response codes, show the `AddReservation()` method in `ReservationsController.cs`. Show that the return value is the `Created()` method, and if you hover over it to get the description, you can see that it produces a `201 Created` response:

![Created()](./img/dotnet-created.png)

### ActionResult

Also, point out that the return type for the method is `ActionResult<Reservation>`. An `ActionResult` is a result for action methods, hence the name. Using `ActionResult` with or without the type parameter is necessary to return a status code method like `Created()`. The students may see in real-world code that it's also acceptable to use `IActionResult` as the return type, but you can't use a type parameter with it.

## CRUD

As mentioned in earlier days and content, CRUD stands for "**C**reate **R**etrieve **U**pdate **D**elete"—the four basic data operations. So far, the students have seen the "Create" and "Retrieve" parts in the `POST` and `GET` HTTP methods, respectively. You'll add the "Update" and "Delete" parts so the application provides full CRUD capabilities.

### Update reservation

With data validation in place, you can move on to the update method. There are a few things to point out about this method.

First, you want to check that the reservation exists before trying to update it. If it doesn't exist, you want to return a `NotFound()` `ActionResult` which is a `404` response status code. After checking that the reservation exists, update it, and return the updated record in an `Ok()` result which is a `200` response status code.

Here are several other points to discuss:

- The use of the `HttpPut` attribute: a RESTful server should respond to update requests using the `PUT` HTTP method.
- RESTful `PUT` URLs are typically in the `reservations/{id}` format, where `{id}` is the unique identifier for the record being updated.
- `PUT` requests typically require the full object record.

```csharp
[HttpPut("{id}")]
public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
{
    Reservation existingReservation = reservationDao.Get(id);
    if (existingReservation == null)
    {
        return NotFound();
    }

    Reservation result = reservationDao.Update(id, reservation);
    return Ok(result);
}
```

Test this method in Postman with both a valid reservation ID (1-4 are hardcoded in on application start) and an invalid reservation ID. Again, performing all of your testing in Postman gets the students in the habit of doing the same.

### Delete reservation

The delete method starts off similar to the update method—check for the record first and return `NotFound()` if it doesn't exist.

Instead of responding with `200 Ok`, the method responds with `204 NoContent` when successful. A `204` response is typical for a `DELETE` request, since there's no data to return. The `NoContent()` method returns a `204` response.

Finally, there's `StatusCode(500)` at the end. Reiterate that `5xx` codes are server errors, meaning the server is aware that it has encountered an error or is otherwise incapable of performing the request. `500` means "Internal Server Error", which is a generic error message when an unexpected condition was encountered. The `StatusCode()` method can be used when there's no suitable method like `Ok()` and `NotFound()`:

```csharp
[HttpDelete("{id}")]
public ActionResult DeleteReservation(int id)
{
    Reservation existingReservation = reservationDao.Get(id);
    if (existingReservation == null)
    {
        return NotFound();
    }

    bool result = reservationDao.Delete(id);
    if (result)
    {
        return NoContent();
    }
    return StatusCode(500); //in case DAO has an error in deleting
}
```

Test both a valid reservation ID (1-4) and an invalid reservation ID in Postman. You can also try deleting the same reservation a second time to show the `404` response.

## Command-line console application

Now that the API works, it's time to use the command-line client again. This is the same console application you've been using.

Now that the API is running, start the command-line client and test each of the menu options.

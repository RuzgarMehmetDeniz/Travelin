using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.TourServices;
using System.Drawing;

namespace Project3Travelin.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;

        public AdminBookingController(IBookingService bookingService, ITourService tourService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
        }

        public async Task<IActionResult> BookingList()
        {
            var bookings = await _bookingService.GetAllBookingAsync();
            var tours = await _tourService.GetAllTourAsync();
            var tourDict = tours.ToDictionary(t => t.TourId, t => t.Title);

            foreach (var booking in bookings)
                booking.TourTitle = tourDict.TryGetValue(booking.TourId, out var t) ? t : "Belirtilmemiş";

            return View(bookings);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            ViewBag.Tours = await _tourService.GetAllTourAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
            return RedirectToAction("BookingList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            ViewBag.Tours = await _tourService.GetAllTourAsync();
            return View(new UpdateBookingDto
            {
                BookingId = booking.BookingId,
                Name = booking.Name,
                Surname = booking.Surname,
                Email = booking.Email,
                Phone = booking.Phone,
                TourId = booking.TourId,
                BookingDate = booking.BookingDate
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            await _bookingService.UpdateBookingAsync(dto);
            return RedirectToAction("BookingList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction("BookingList");
        }

        [HttpPost]
        public async Task<IActionResult> ApproveBooking(string id)
        {
            TempData["Success"] = "Rezervasyon başarıyla onaylandı.";
            return RedirectToAction("BookingList");
        }

        public async Task<IActionResult> ExportToExcel()
        {
            var bookings = await _bookingService.GetAllBookingAsync();
            var tours = await _tourService.GetAllTourAsync();
            var tourDict = tours.ToDictionary(t => t.TourId, t => t.Title);

            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Rezervasyonlar");

            ws.Cell(1, 1).Value = "Ad";
            ws.Cell(1, 2).Value = "Soyad";
            ws.Cell(1, 3).Value = "E-posta";
            ws.Cell(1, 4).Value = "Telefon";
            ws.Cell(1, 5).Value = "Tur";
            ws.Cell(1, 6).Value = "Rezervasyon Tarihi";
            ws.Cell(1, 7).Value = "Booking ID";

            var headerRow = ws.Range("A1:G1");
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#2563eb");
            headerRow.Style.Font.FontColor = XLColor.White;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            int row = 2;
            foreach (var item in bookings)
            {
                ws.Cell(row, 1).Value = item.Name;
                ws.Cell(row, 2).Value = item.Surname;
                ws.Cell(row, 3).Value = item.Email;
                ws.Cell(row, 4).Value = item.Phone;
                ws.Cell(row, 5).Value = tourDict.TryGetValue(item.TourId, out var t) ? t : "Belirtilmemiş";
                ws.Cell(row, 6).Value = item.BookingDate.ToString("dd.MM.yyyy");
                ws.Cell(row, 7).Value = item.BookingId;
                row++;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Rezervasyonlar_{DateTime.Now:yyyyMMdd}.xlsx");
        }
    }
}
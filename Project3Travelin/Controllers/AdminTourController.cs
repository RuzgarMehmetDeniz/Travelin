using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminTourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IBookingService _bookingService;

        public AdminTourController(ITourService tourService, IBookingService bookingService)
        {
            _tourService = tourService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> TourList()
        {
            var values = await _tourService.GetAllTourAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTour()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour(CreateTourDto createTourDto)
        {
            await _tourService.CreateTourAsync(createTourDto);
            return RedirectToAction("TourList");
        }

        public async Task<IActionResult> DeleteTour(string id)
        {
            await _tourService.DeleteTourAsync(id);
            return RedirectToAction("TourList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTour(string id)
        {
            var value = await _tourService.GetTourByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTour(UpdateTourDto updateTourDto)
        {
            await _tourService.UpdateTourAsync(updateTourDto);
            return RedirectToAction("TourList");
        }

        // Tura ait rezervasyonları listele
        public async Task<IActionResult> TourReservations(string id)
        {
            var bookings = await _bookingService.GetBookingsByTourIdAsync(id);
            ViewBag.TourId = id;
            return View(bookings);
        }

        // Excel export
        public async Task<IActionResult> ExportReservationsExcel(string id)
        {
            var bookings = await _bookingService.GetBookingsByTourIdAsync(id);
            var tour = await _tourService.GetTourByIdAsync(id);
            string tourName = tour?.Title ?? id;

            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Rezervasyonlar");

            // Başlıklar
            ws.Cell(1, 1).Value = "Rezervasyon ID";
            ws.Cell(1, 2).Value = "Ad";
            ws.Cell(1, 3).Value = "Soyad";
            ws.Cell(1, 4).Value = "E-posta";
            ws.Cell(1, 5).Value = "Telefon";
            ws.Cell(1, 6).Value = "Tur Adı";
            ws.Cell(1, 7).Value = "Rezervasyon Tarihi";

            // Başlık stili
            var headerRow = ws.Range("A1:G1");
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#2563eb");
            headerRow.Style.Font.FontColor = XLColor.White;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Veri satırları
            for (int i = 0; i < bookings.Count; i++)
            {
                var b = bookings[i];
                int row = i + 2;
                ws.Cell(row, 1).Value = b.BookingId;
                ws.Cell(row, 2).Value = b.Name;
                ws.Cell(row, 3).Value = b.Surname;
                ws.Cell(row, 4).Value = b.Email;
                ws.Cell(row, 5).Value = b.Phone;
                ws.Cell(row, 6).Value = tourName;
                ws.Cell(row, 7).Value = b.BookingDate.ToString("dd.MM.yyyy");

                // Zebra renklendirme
                if (i % 2 == 1)
                    ws.Row(row).Style.Fill.BackgroundColor = XLColor.FromHtml("#f8fafc");
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            string fileName = $"Rezervasyonlar_{tourName}_{DateTime.Now:yyyyMMdd}.xlsx";
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
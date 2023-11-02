using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using System.Text;
using WebEmployeeSystem.Data;
using WebEmployeeSystem.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;


namespace WebEmployeeSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _db.Employees.ToList();
            return View(objEmployeeList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Add(Employee obj)
		{
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
         public IActionResult Edit(int? EmployeeId)
        {
            if(EmployeeId == null || EmployeeId == 0)
            {
                return NotFound();
            }
            Employee employeefromDb = _db.Employees.Find(EmployeeId);
            if(employeefromDb == null) 
            {
                return NotFound();
            }
            return View(employeefromDb);
        }
        [HttpPost]
		public IActionResult Edit(Employee obj)
		{
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
		public IActionResult Delete(int? EmployeeId)
		{
			if (EmployeeId == null || EmployeeId == 0)
			{
				return NotFound();
			}
			Employee employeefromDb = _db.Employees.Find(EmployeeId);

			if (employeefromDb == null)
			{
				return NotFound();
			}
			return View(employeefromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? EmployeeId)
		{
            Employee obj = _db.Employees.Find(EmployeeId);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index"); 
			
		}

        public IActionResult Details(int? EmployeeId)
        {
            if (EmployeeId == null || EmployeeId == 0)
            {
                return NotFound();
            }

            Employee employeeFromDb = _db.Employees.Find(EmployeeId);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            
            employeeFromDb.Currency = "USD"; 

            return View(employeeFromDb);
        }



        ///EXEL  

        public IActionResult ExportToExcel()
        {
            var employees = _db.Employees.ToList();

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Employees");

               
                workSheet.Cells[1, 1].Value = "First Name";
                workSheet.Cells[1, 2].Value = "Last Name";
                workSheet.Cells[1, 3].Value = "Address";
                workSheet.Cells[1, 4].Value = "Net Salary";
                workSheet.Cells[1, 5].Value = "Position";

                int row = 2;
                foreach (var employee in employees)
                {
                    workSheet.Cells[row, 1].Value = employee.FirstName;
                    workSheet.Cells[row, 2].Value = employee.LastName;
                    workSheet.Cells[row, 3].Value = employee.Address;
                    workSheet.Cells[row, 4].Value = employee.NetSalary;
                    workSheet.Cells[row, 5].Value = employee.Position;
                    row++;
                }

                
                byte[] fileBytes = package.GetAsByteArray();
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
            }
        }
        ///CSV
        public IActionResult ExportToCsv()
        {
            var employees = _db.Employees.ToList();

            var csvData = new StringBuilder();
            csvData.AppendLine("First Name,Last Name,Address,Net Salary,Position");

            foreach (var employee in employees)
            {
                csvData.AppendLine($"{employee.FirstName},{employee.LastName},{employee.Address},{employee.NetSalary},{employee.Position}");
            }

            byte[] fileBytes = Encoding.UTF8.GetBytes(csvData.ToString());
            return File(fileBytes, "text/csv", "Employees.csv");
        }

        public IActionResult CalculateGrossSalary(int employeeId)
        {
            var employee = _db.Employees.Find(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            decimal netSalary = (decimal)employee.NetSalary;

            decimal grossSalary = CalculateGrossSalaryFromNetSalary(netSalary);

            employee.GrossSalary = grossSalary;

            _db.SaveChanges();

            return RedirectToAction("Details", new { employeeId });
        }

        private decimal CalculateGrossSalaryFromNetSalary(decimal netSalary)
        {

            decimal taxRate = 0.20m;
            decimal grossSalary = netSalary / (1 - taxRate);

            return grossSalary;
        }
        private decimal CalculateTax(decimal netSalary)
        {
            decimal taxRate = 0.20m;  

            decimal tax = netSalary * taxRate;

            return tax;
        }

        private decimal CalculatePensionContribution(decimal netSalary)
        {
            decimal pensionRate = 0.15m;  

            decimal pensionContribution = netSalary * pensionRate;

            return pensionContribution;
        }

        private decimal CalculateHealthContribution(decimal netSalary)
        {
            decimal healthRate = 0.10m; 

            decimal healthContribution = netSalary * healthRate;

            return healthContribution;
        }

        private decimal CalculateUnemploymentContribution(decimal netSalary)
        {
            decimal unemploymentRate = 0.05m; 

            decimal unemploymentContribution = netSalary * unemploymentRate;

            return unemploymentContribution;
        }

        private decimal CalculateTotalTaxesAndContributions(decimal netSalary)
        {
            decimal tax = CalculateTax(netSalary);
            decimal pensionContribution = CalculatePensionContribution(netSalary);
            decimal healthContribution = CalculateHealthContribution(netSalary);
            decimal unemploymentContribution = CalculateUnemploymentContribution(netSalary);

            decimal totalTaxesAndContributions = tax + pensionContribution + healthContribution + unemploymentContribution;

            return totalTaxesAndContributions;
        }
        public IActionResult CalculateAll(int employeeId)
        {
            var employee = _db.Employees.Find(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            decimal netSalary = (decimal)employee.NetSalary;

            employee.GrossSalary = CalculateGrossSalaryFromNetSalary(netSalary);
            employee.Tax = CalculateTax(netSalary);
            employee.PensionContribution = CalculatePensionContribution(netSalary);
            employee.HealthContribution = CalculateHealthContribution(netSalary);
            employee.UnemploymentContribution = CalculateUnemploymentContribution(netSalary);
            employee.TotalTaxesAndContributions = CalculateTotalTaxesAndContributions(netSalary);

            _db.SaveChanges();

            return RedirectToAction("Details", new { employeeId });
        }


        public IActionResult GeneratePdf(int employeeId)
        {
            var employee = _db.Employees.Find(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            using (var memoryStream = new MemoryStream())
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                document.Add(new Paragraph("Employee Details"));
                document.Add(new Paragraph($"First Name: {employee.FirstName}"));
                document.Add(new Paragraph($"Last Name: {employee.LastName}"));
                document.Add(new Paragraph($"Address: {employee.Address}"));
                document.Add(new Paragraph($"Email: {employee.Email}"));
                document.Add(new Paragraph($"Net Salary: {employee.NetSalary}"));
                document.Add(new Paragraph($"Position: {employee.Position}"));
                document.Add(new Paragraph($"Gross Salary: {employee.GrossSalary}"));
                document.Add(new Paragraph($"Tax: {employee.Tax}"));
                document.Add(new Paragraph($"PensionContribution: {employee.PensionContribution}"));
                document.Add(new Paragraph($"HealthContribution: {employee.HealthContribution}"));
                document.Add(new Paragraph($"UnemploymentContribution: {employee.UnemploymentContribution}"));
                document.Add(new Paragraph($"TotalTaxesAndContributions: {employee.TotalTaxesAndContributions}"));


                document.Close();

                var newMemoryStream = new MemoryStream(memoryStream.ToArray());

                return File(newMemoryStream, "application/pdf", $"Employee_{employeeId}.pdf");
            }
        }
        public IActionResult ConvertToPdfAndSendEmail(int employeeId)
        {
            var employee = _db.Employees.Find(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            byte[] pdfData = ConvertEmployeeToPdf(employee);

            SendEmailWithPdf(employee, pdfData);

            return RedirectToAction("Details", new { employeeId });
        }

        private byte[] ConvertEmployeeToPdf(Employee employee)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                document.Add(new Paragraph("Employee Details"));
                document.Add(new Paragraph($"First Name: {employee.FirstName}"));
                document.Add(new Paragraph($"Last Name: {employee.LastName}"));
                document.Add(new Paragraph($"Net Address: {employee.Address}"));
                document.Add(new Paragraph($"Email: {employee.Email}"));
                document.Add(new Paragraph($"Net Salary: {employee.NetSalary}"));
                document.Add(new Paragraph($"Position: {employee.Position}"));
                document.Add(new Paragraph($"Gross Salary: {employee.GrossSalary}"));
                document.Add(new Paragraph($"PensionContribution: {employee.PensionContribution}"));
                document.Add(new Paragraph($"HealthContribution: {employee.HealthContribution}"));
                document.Add(new Paragraph($"UnemploymentContribution: {employee.UnemploymentContribution}"));
                document.Add(new Paragraph($"TotalTaxesAndContributions: {employee.TotalTaxesAndContributions}"));


                document.Close();

                return memoryStream.ToArray();
            }
        }

        private void SendEmailWithPdf(Employee employee, byte[] pdfData)
        {
            var smtpClient = new SmtpClient("smtp.youremailprovider.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("yourusername", "yourpassword"),
                EnableSsl = true,
            };

            var message = new MailMessage
            {
                From = new MailAddress("your@email.com"),
                Subject = "Employee Details",
                Body = "Pogledajte prilog za detalje zaposlenog.",
            };

            message.To.Add(new MailAddress(employee.Email));
            message.Attachments.Add(new Attachment(new MemoryStream(pdfData), "EmployeeDetails.pdf"));

            smtpClient.Send(message);
        }


    }


}

    



using DinkToPdf;
using DinkToPdf.Contracts;

namespace Rezervation.Services
{
    public class PdfReport : IPdfReport
    {

        private readonly IConverter _converter;
        private readonly IUserService _userService;
        private readonly IOrganizerService _organizerService;
        private readonly ITripService _tripService;
        private readonly ITypeOfTransportService _typeoftransportService;
        private readonly IRoleService _roleService;

        public PdfReport(IRoleService roleService,
                        IOrganizerService organizerService,
                        ITripService tripService,
                        ITypeOfTransportService typeoftransportService,
                        IUserService userService,
                        IConverter converter)
        {
            _roleService = roleService;
            _organizerService = organizerService;
            _tripService = tripService;
            _typeoftransportService = typeoftransportService;
            _userService = userService;
            _converter = converter;
        }
        public void ExportPdf()
        {
            GlobalSettings globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = "PdfReport.pdf"
            };

            ObjectSettings objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetPdfContent(),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial" },
                FooterSettings = { FontName = "Arial" }
            };
            HtmlToPdfDocument pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);
        }

        private string GetPdfContent()
        {
            return

$@"<html>
    <head>
        <style>
            .header {{
                text-align: center;
                color: black;
                padding-bottom: 35px;
            }}

            table {{
                width: 80%;
                border-collapse: collapse;
                margin: 0 auto; }}

            td, th {{
                border: 1px solid gray;
                padding: 15px;
                font-size: 22px;
                text-align: center;
            }}

            table th {{
                background-color: #ffccee;
                color: black;
            }}
        </style>
    </head>
    <body>
        <div class='header'>
            <h1>PDF Report</h1>
        </div>
        <table>
            <thead>
                <th>Entity Name</th>
                <th>Count</th>
            </thead>
            <tr>
                <td>Users</td>
                <td>{_userService.GetCount()}</td>
            </tr>
            <tr>
                <td>Organizers</td>
                <td>{_organizerService.GetCount()}</td>
            </tr>
            <tr>
                <td>Trips</td>
                <td>{_tripService.GetCount()}</td>
            </tr>
            <tr><td>Types of transport</td>
                <td>{_typeoftransportService.GetCount()}</td>
            </tr>
            <tr>
                <td>Roles</td>
                <td>{_roleService.GetCount()}</td>
            </tr>
        </table>
    </body>
</html>";

        }
    }
}

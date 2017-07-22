using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cbDevPGAtools.Models;
using cbDevPGAtools.ViewModels;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using cbDevPGAtools.Data;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cbDevPGAtools.Controllers
{
    public class ImportExportSalariesController : Controller
    {
        private  cbDevPGAtoolsDbContext context;

        
        private  IHostingEnvironment _environment;

        public ImportExportSalariesController(IHostingEnvironment environment, cbDevPGAtoolsDbContext dbContext)
        {
            _environment = environment;

            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadDKcsv()
        {
           
            return View("UploadDKcsv");

        }

        [HttpPost]
        public async Task<IActionResult> DKimport(ICollection<IFormFile> DKfiles, string uploadName)
        {

            long size = 0;

            foreach (var file in DKfiles)
            {
                if (file.Length > 0)
                {
                    if (!string.IsNullOrEmpty(uploadName))
                    {
                        var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                       
                        var DKuploads = System.IO.Path.Combine(_environment.ContentRootPath, "DKuploads");
                      
                        string UPLOADname = uploadName;


                        using (FileStream fstream = new FileStream(Path.Combine(DKuploads, UPLOADname), FileMode.Create))
                        {

                            await file.CopyToAsync(fstream);
                        
                            fstream.Flush();
                        }
          

                        size += file.Length;
                        //TempData["fileUpload"] = UPLOADname;
                        // ViewBag.Message = $"{DKfiles.Count} file(s) / {file.FileName}, {size} bytes uploaded sucessfully!";
                        // return View("UploadDKcsv");
                        return RedirectToAction("DKcreate", "ImportExportSalaries", new { Uname = $"{UPLOADname}" });

                        
                    }
                    else
                    {
                        ViewBag.Message = "Name your file please";
                        return View("UploadDKcsv");
                    }

                }


            }

            ViewBag.Message = "Select a file please";
            return View("UploadDKcsv");




        }

        public IActionResult DKcreate(string Uname)
        {
            
          
                if (!string.IsNullOrWhiteSpace(Uname))
                {
                    List<Golfer> theseGolfers = new List<Golfer>();

                    theseGolfers = PGAuploads.WeeksGolfers(Uname);

                    string GameInfo = PGAuploads.WeeksGameInfo(Uname);

                    var isDuplicate = context.DKT.Any(a => a.Name == GameInfo);

                    if (isDuplicate)
                    {
                        ViewBag.Message = "You've already uploaded this tournament";
                        return View("UploadDKcsv");
                    }
                    else
                    {
                        foreach (Golfer golfer in theseGolfers)
                        {
                            context.GOLFER.Add(golfer);

                        }

                        DKtourney dkTOURNEY = new DKtourney(theseGolfers)
                        {
                            Name = GameInfo,

                        };

                        context.DKT.Add(dkTOURNEY);
                        context.SaveChanges();

                        ViewBag.Game = GameInfo;
                        ViewBag.Golfers = theseGolfers;
                        return View("SalariesCreated");
                    }


                }

                ViewBag.Message = "Upload a file please";
                return View("UploadDKcsv");

         
           
        }
    }


}

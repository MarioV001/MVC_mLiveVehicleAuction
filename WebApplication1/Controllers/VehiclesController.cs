
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mVehAuction.Data;
using mVehAuction.Models;

namespace mVehAuction.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public VehiclesController(ApplicationDbContext context, IWebHostEnvironment weben)
        {
            _context = context;
            _environment = weben;
        }
        // Post UploadImg function
        [Authorize]
        [HttpPost]
        [RequestSizeLimit(85_100_000)]//rougly 80mb
        //[AcceptVerbs(HttpVerbs.Post)]
        public async Task<IActionResult> UploadFile(List<IFormFile> FormFile, string ReqKey)
        {
            if (FormFile.Count < 4) return Json(new { success = false, message = "Minimum 4 Files!" });
            if (FormFile == null) return Json(new { success = false, message = "no files Attached" });

            long size = FormFile.Sum(f => f.Length);
            var asdas = _context.Vehicle.ToListAsync();
            int fileCounter = 0;//to add to the URL
            string WWRoot = _environment.WebRootPath + @"\TempUPL_FLD\" + ReqKey;
            foreach (var formFile in FormFile)
            {
                if (formFile.Length > 0)
                {
                    if(!Directory.Exists(WWRoot)) Directory.CreateDirectory(WWRoot);//creat TempDir if not existant
                    var filePath = Path.Combine(WWRoot, fileCounter.ToString() +"T" + FileUpload.GetFileType(formFile.FileName));

                    using (var stream = System.IO.File.Create(filePath))//add handle for individual images
                    {
                        await formFile.CopyToAsync(stream );
                        fileCounter++;
                    }
                }
            }
            return Json(new { success = true, message = "("+fileCounter + ") Files Uplaoded" });
        }

        [HttpPost]
        public JsonResult ReOrderImageList(List<string> ImgList)
        {
            string ReqKey = ImgList[0].Split('/').Reverse().Take(2).Last();
            string WWRoot = _environment.WebRootPath + @"\TempUPL_FLD\" + ReqKey + @"\";
            for (int i=0; i<ImgList.Count; i++)
            {
                string OldFile = FileUpload.GetFileName(ImgList[i], true, false);
                System.IO.File.Move(WWRoot + OldFile, WWRoot + i.ToString() + "." + OldFile.Split(".")[1]);//Finish

            }
            return Json(new { success = true, message = "List Re-Ordered" });
        }
        public async Task<IActionResult> GetAllVeh()
        {
            try
            {
                return Ok(await _context.Vehicle.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error In Data");
            }
            
        }
        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }
        // GET: Search
        public IActionResult SeachForm()
        {
            return View();
        }
        // POST: Show Search results
        public async Task<IActionResult> SeachFormResult(string SearchString)
        {
            return View("Index",await _context.Vehicle.Where(v => v.Make.Contains(SearchString)).ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        [Authorize]
        public IActionResult Create()
        {
            var asdas = new LotLocation();
            foreach(var ttstr in LotLocation){

            }
            asdas.Where(v => v.Make.Contains(SearchString)).ToListAsync());
            var newVehTeamplate = new Vehicle
            {
                
                Make = "",
                Model = "",
                Odometer = 0,
                Year = Convert.ToInt32(DateTime.Now.Year),
                ImageURL = FileUpload.ReturnNewUniqueKey(),
                Category = "All Damage Types",
                TimeCreated = DateTime.Now,
                AuctionStartDate = DateTime.Now.AddDays(8),//finish date
                Location = "Samokov",
                LotLocation = 3301,
                VIN = "",
                AdditionalDescription = "NA"
            };
            return View(newVehTeamplate);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Odometer,Year,Category,ImageURL,DamageType," +
            "TimeCreated,AuctionStartDate,LotLocation,CurrentBid,BuyNow,Location,VIN,BodyStyle," +
            "EngineCC,TransGears,Transmision,AdditionalDescription,Drive,Keys,VehDocuments," +
            "FuelType,RetailValue")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                FileUpload.SaveImagesPermenantly(vehicle.ImageURL);
                return Json(Url.Action("Index", "Vehicles"));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicle'  is null.");
            }
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
               FileUpload.RemoveImgDir(vehicle.ImageURL);
                _context.Vehicle.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     
        
        private bool VehicleExists(int id)
        {
          return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
